/* 
 * Project:    B&G H2000 SerialPort Terminal
 * Company:    Lafleur Designs
 * Author:     Tom Lafleur
 * Created:    November 2006
 * 
 * Notes:      This was created to monitor Brook and Gatehouse B&G H2000 system traffic
 *             via a network interface box to a USB Serial Port interface
 *             Allows a PC to receive and send data on the B&G network
 *              Note: VS 2005 has a problem with a file name with a "&" inside... 
 *                      ie: we can't name any files on this project "B&G"
 */

#region Namespace Inclusions
using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using BGSerialLib;
using BGSerialLib.Properties;

#endregion

namespace BGTerminal
{
    #region Public Enumerations
    public enum DataMode { Text, Hex }
    public enum LogMsgType { Incoming,   Outgoing,    Normal,      Warning,      Error };
    //                       Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red
    #endregion

    
    public partial class Terminal : Form
    {
        #region Local Variables

        // user to check for UI finish
        IAsyncResult ar, deAR, ceAR;

        // Various colors for logging info
        private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

        // Temp holder for whether a key was pressed
        private bool KeyHandled = false;

        // RichTextBox display size
        int maxTextSize = 60000;
        int minTextSize = 45000;

        #endregion

        #region Constructor

        public BGSerialPort bgPort = null;

        public Terminal()
        {
            // Build the form
            InitializeComponent();

            // Build the print dialog box
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            this.menuPrintPreview.Click += new System.EventHandler(this.menuPrintPreview_Click);
            this.menuPageSetup.Click += new System.EventHandler(this.menuPageSetup_Click);

            // Restore the users settings
            InitializeControlValues();

            // Enable controls
            gbPortSettings.Enabled = true;
            btnSend.Enabled = false;
            btnOpenPort.Text = "&Open Port";
        }

        /// <summary>
        /// Compute the TX Checksum over a number of bytes
        /// </summary>
        /// <param name="array">byte array</param>
        /// <param name="start">int start</param>
        /// <param name="last">int end</param>
        /// <returns>True if ok</returns>
        private byte txtCheckSum(byte[] array, int start, int end)
        {
            byte cs = 0;    // Clear checksum  
            byte cs1 = 0;
            while (start < end)
            {
                cs += array[start];
                start++;
            }
            cs1 = ((byte)(cs & 0xff));
            cs1 = (byte)~cs1;
            cs1++;
            return (((byte)cs1));
        }

        public void ExitApp()
        {
            bgPort.Dispose();  //Closes serial port and cleans up
            Application.Exit();
        }

        #endregion


        #region Local Methods

        #region print methods

        private int checkPrint;
        private void menuPageSetup_Click(object sender, System.EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void menuPrintPreview_Click(object sender, System.EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void menuPrint_Click(object sender, System.EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            checkPrint = rtfTerminal.Print(checkPrint, rtfTerminal.TextLength, e);

            // Check for more pages
            if (checkPrint < rtfTerminal.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        #endregion

        /// <summary> Save the user's settings. </summary>
        private void SaveSettings()
        {
            // Reference only
            //Settings.Default.BaudRate = 28800;
            //Settings.Default.DataBits = 8;
            //Settings.Default.DataMode = CurrentDataMode;
            //Settings.Default.Parity = 1;
            //Settings.Default.StopBits = 2;

            Settings.Default.PortName = cmbPortName.Text;

            Settings.Default.SendData = txtSendData.Text;
            Settings.Default.SendAddr = txtSendAddr.Text;
            Settings.Default.SendCmd = txtSendCmd.Text;
            Settings.Default.SendFrom = txtSendFrom.Text;

            Settings.Default.RxFilter1 = addrFilter1.Text;
            Settings.Default.RxFilter2 = addrFilter2.Text;
            Settings.Default.RxFilter3 = addrFilter3.Text;

            Settings.Default.Save();
        }

        /// <summary> Populate the form's controls with default settings. </summary>
        private void InitializeControlValues()
        {
            cmbParity.Items.Clear(); cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.Clear(); cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            // Most serial port information is defaulted
            cmbParity.Text = Settings.Default.Parity.ToString();
            cmbStopBits.Text = Settings.Default.StopBits.ToString();
            cmbDataBits.Text = Settings.Default.DataBits.ToString();
            cmbBaudRate.Text = Settings.Default.BaudRate.ToString();

            txtSendData.Text = Settings.Default.SendData.ToString();
            txtSendAddr.Text = Settings.Default.SendAddr.ToString();
            txtSendCmd.Text = Settings.Default.SendCmd.ToString();
            txtSendFrom.Text = Settings.Default.SendFrom.ToString();

            addrFilter1.Text = Settings.Default.RxFilter1.ToString();
            addrFilter2.Text = Settings.Default.RxFilter2.ToString();
            addrFilter3.Text = Settings.Default.RxFilter3.ToString();

            CurrentDataMode = Settings.Default.DataMode;

            cmbPortName.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                cmbPortName.Items.Add(s);

            if (cmbPortName.Items.Contains(Settings.Default.PortName)) cmbPortName.Text = Settings.Default.PortName;
            else if (cmbPortName.Items.Count > 0) cmbPortName.SelectedIndex = 0;
            else
            {
                MessageBox.Show(this, "There are no COM Ports detected.\n", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary> Enable/disable controls based on the app's current state. </summary>
        private void EnableControls()
        {
            // Enable/disable controls based on whether the port is open or not

            if (bgPort != null)
            {
                gbPortSettings.Enabled = !bgPort.IsPortOpen;
                btnSend.Enabled = bgPort.IsPortOpen;

                if (bgPort.IsPortOpen) btnOpenPort.Text = "&Close Port";
                else btnOpenPort.Text = "&Open Port";
            }
            else
            {
                btnOpenPort.Text = "&Open Port";
            }

        }

        /// <summary> Send the user's data currently entered in the 'send' box.</summary>
        private void SendData()
        {
            if (txtSendData.Text.Length == 0)
                try
                {
                    byte[] sendBuffer = new byte[5];
                    sendBuffer[0] = byte.Parse(txtSendAddr.Text, NumberStyles.HexNumber);
                    sendBuffer[1] = byte.Parse(txtSendFrom.Text, NumberStyles.HexNumber);
                    sendBuffer[2] = 0;
                    sendBuffer[3] = byte.Parse(txtSendCmd.Text, NumberStyles.HexNumber);
                    sendBuffer[4] = (byte)txtCheckSum(sendBuffer, 0, 4);
                    bgPort.WriteData(sendBuffer, 0, sendBuffer.Length);
                    Log(LogMsgType.Outgoing, "\n" + ByteArrayToHexString(sendBuffer));
                }
                catch (FormatException)
                {
                    // Inform the user if the hex string was not properly formatted
                    Log(LogMsgType.Error, "\nNot a hex string: " + txtSendData.Text);
                }
            else
            {
                try
                {
                    byte[] data2 = HexStringToByteArray(txtSendData.Text);
                    byte[] sendBuffer = new byte[data2.Length + 6];
                    sendBuffer[0] = byte.Parse(txtSendAddr.Text, NumberStyles.HexNumber);
                    sendBuffer[1] = byte.Parse(txtSendFrom.Text, NumberStyles.HexNumber);
                    sendBuffer[2] = (byte)data2.Length;
                    sendBuffer[3] = byte.Parse(txtSendCmd.Text, NumberStyles.HexNumber);
                    sendBuffer[4] = (byte)txtCheckSum(sendBuffer, 0, 4);
                    Array.Copy(data2, 0, sendBuffer, 5, data2.Length);
                    sendBuffer[data2.Length + 5] = (byte)txtCheckSum(sendBuffer, 0, data2.Length + 5);

                    bgPort.WriteData(sendBuffer, 0, sendBuffer.Length);
                    Log(LogMsgType.Outgoing, "\n" + ByteArrayToHexString(sendBuffer));
                }
                catch (FormatException)
                {
                    // Inform the user if the hex string was not properly formatted
                    Log(LogMsgType.Error, "\nNot a hex string: " + txtSendData.Text);
                }
            }
            txtSendData.SelectAll();
        }

        /// <summary> Log data to the terminal window. </summary>
        /// <param name="msgtype"> The type of message to be written. </param>
        /// <param name="msg"> The string containing the message to be shown. </param>
        private void Log(LogMsgType msgtype, string msg)
        {
            ar = rtfTerminal.BeginInvoke(new EventHandler(delegate
            {
                if ((msg.Length + rtfTerminal.Text.Length) > maxTextSize)
                {
                    rtfTerminal.Select(0, rtfTerminal.Text.Length - minTextSize);
                }
                rtfTerminal.SelectedText = string.Empty;
                //rtfTerminal.SelectionFont = new Font(rtfTerminal.SelectionFont, FontStyle.Bold);
                rtfTerminal.SelectionColor = LogMsgTypeColor[(int)msgtype];
                rtfTerminal.Select(rtfTerminal.Text.Length, 0);
                rtfTerminal.AppendText(msg);
                rtfTerminal.ScrollToCaret();

            }));
            EndInvoke(ar);
        }

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 4);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
        #endregion

        #region Local Properties
        private DataMode CurrentDataMode
        {
            get
            {
                if (rbHex.Checked) return DataMode.Hex;
                else return DataMode.Text;
            }
            set
            {
                if (value == DataMode.Text) rbText.Checked = true;
                else rbHex.Checked = true;
            }
        }
        #endregion

        #region Local Event Handlers
        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show the user the about dialog
            (new frmAbout()).ShowDialog(this);
        }

        private void frmTerminal_Shown(object sender, EventArgs e)
        {
            // Log(LogMsgType.Normal, String.Format("Application Started at {0}\n"));
        }

        private void frmTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            exitProgram();
        }

        public void SaveMyFile()
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "txt files (*.txt)|*.txt|RTF Files|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                rtfTerminal.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        { if (rbText.Checked) CurrentDataMode = DataMode.Text; }

        private void rbHex_CheckedChanged(object sender, EventArgs e)
        { if (rbHex.Checked) CurrentDataMode = DataMode.Hex; }

        private void cmbBaudRate_Validating(object sender, CancelEventArgs e)
        { int x; e.Cancel = !int.TryParse(cmbBaudRate.Text, out x); }

        private void cmbDataBits_Validating(object sender, CancelEventArgs e)
        { int x; e.Cancel = !int.TryParse(cmbDataBits.Text, out x); }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            btnOpenPort.Enabled = false;

            try
            {
                btnOpenPort.Text = "Closing2...";
                btnOpenPort.Update();

                // If the port is open, close it.
                if (bgPort != null && bgPort.IsPortOpen)
                {
                    bgPort.Dispose();
                    bgPort = null;
                    //BG.Stop();
                }
                else
                {
                    // Open the port
                    try
                    {
                        //Initialize BG handler
                        bgPort = new BGSerialPort(this.cmbPortName.Text);
                        //Hook up B&G data events to a handler
                        bgPort.NewBGData += new BGSerialPort.NewBGDataHandler(this.BGEventHandler);
                        bgPort.TimeOut = 10; // Timeout on no frames received
                        bgPort.Start();
                    }
                    catch
                    {
                        Log(LogMsgType.Error, String.Format("\nCan't Open Serial Port\n"));
                    }
                }

                // Change the state of the form's controls
                EnableControls();

                // If the port is open, send focus to the send data box
                if (bgPort != null && bgPort.IsPortOpen) txtSendData.Focus();
            }
            finally
            {
                btnOpenPort.Enabled = true;
            }
        }


        private void displayErrors()
        {
            deAR = tbCSData.BeginInvoke(new EventHandler(delegate
            {
                tbCSData.Text = Convert.ToString(bgPort.FrameErrors);
                tbCSHeader.Text = Convert.ToString(bgPort.FrameErrors);
            }));
            EndInvoke(deAR);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // We need to wait on "CTS" before we send any data
            while (! bgPort.CtsStatus)  
            {
                Thread.Sleep(0);
            }
            SendData();
        }

        private void BGEventHandler(object sender, BGSerialPort.BGEventArgs e)
        {
            switch (e.TypeOfEvent)
            {
                case BGSerialLib.BGEventType.Valid:
                    {
                        parse_data(e.Sentence);
                    }
                    break;
                case BGSerialLib.BGEventType.CheckSum:
                    {
                        parser_checksum(e.Sentence);
                    }
                    break;
                case BGSerialLib.BGEventType.TimeOut:
                    {
                        Log(LogMsgType.Error, "\n Time Out");
                    }
                    break;
                case BGSerialLib.BGEventType.Unknown:
                    {
                        Log(LogMsgType.Error, "\n Unknown");
                    }
                    break;
            }
            displayErrors();
        }

        // When we get here we have a full frame of valid data
        private void parse_data(byte[] a)
        {
            if (cbFromFilter1.Checked == true || cbFromFilter2.Checked == true || cbFromFilter3.Checked == true ||
                cbToFilter1.Checked == true || cbToFilter2.Checked == true || cbToFilter3.Checked == true)
            {
                // From Filters 1 2 3

                if ((cbFromFilter1.Checked == true) && (addrFilter1.Text.Length > 0))
                {
                    if (a[1] == byte.Parse(addrFilter1.Text, NumberStyles.HexNumber))
                    {
                        if (cmdFilter1.Text.Length > 0)

                            if (a[3] == byte.Parse(cmdFilter1.Text, NumberStyles.HexNumber))
                            { parser_display(a); }
                            else { }
                        else
                        { parser_display(a); }
                    }
                }

                if ((cbFromFilter2.Checked == true) && (addrFilter2.Text.Length > 0))
                {
                    if (a[1] == byte.Parse(addrFilter2.Text, NumberStyles.HexNumber))
                    {
                        if (cmdFilter2.Text.Length > 0)

                            if (a[3] == byte.Parse(cmdFilter2.Text, NumberStyles.HexNumber))
                            { parser_display(a); }
                            else { }
                        else
                        { parser_display(a); }
                    }
                }

                if ((cbFromFilter3.Checked == true) && (addrFilter3.Text.Length > 0))
                {
                    if (a[1] == byte.Parse(addrFilter3.Text, NumberStyles.HexNumber))
                    {
                        if (cmdFilter3.Text.Length > 0)

                            if (a[3] == byte.Parse(cmdFilter3.Text, NumberStyles.HexNumber))
                            { parser_display(a); }
                            else { }
                        else
                        { parser_display(a); }
                    }
                }

                //To Filters 1 2 3

                if ((cbToFilter1.Checked == true) && (addrFilter1.Text.Length > 0))
                {
                    if (a[0] == byte.Parse(addrFilter1.Text, NumberStyles.HexNumber))
                    {
                        if (cmdFilter1.Text.Length > 0)

                            if (a[3] == byte.Parse(cmdFilter1.Text, NumberStyles.HexNumber))
                            { parser_display(a); }
                            else { }
                        else
                        { parser_display(a); }
                    }
                }
                if ((cbToFilter2.Checked == true) && (addrFilter2.Text.Length > 0))
                {
                    if (a[0] == byte.Parse(addrFilter2.Text, NumberStyles.HexNumber))
                    {
                        if (cmdFilter2.Text.Length > 0)

                            if (a[3] == byte.Parse(cmdFilter2.Text, NumberStyles.HexNumber))
                            { parser_display(a); }
                            else { }
                        else
                        { parser_display(a); }
                    }
                }
                if ((cbToFilter3.Checked == true) && (addrFilter3.Text.Length > 0))
                {
                    if (a[0] == byte.Parse(addrFilter3.Text, NumberStyles.HexNumber))
                    {
                        if (cmdFilter3.Text.Length > 0)

                            if (a[3] == byte.Parse(cmdFilter3.Text, NumberStyles.HexNumber))
                            { parser_display(a); }
                            else { }
                        else
                        { parser_display(a); }
                    }
                }
            }
            else
            {
                parser_display(a);
            }
        }

        private void parser_display(byte[] ppData)
        {
            // Command header size is 5 bytes
            // Format is:  ff  aa ll cc cs
            // ff is from address
            // tt is to address
            // ll length of data field (can be zero)
            // cc is command
            // cs is checksum for header

            byte[] xBuffer = new byte[ppData.Length - 5];
            Array.Copy(ppData, 5, xBuffer, 0, ppData.Length - 5);
            Log(LogMsgType.Incoming, "\n" + String.Format("{0:x2}", ppData[0]) + " " + String.Format("{0:x2}", ppData[1]) + " " + String.Format("{0:x2}", ppData[2])
                + " " + String.Format("{0:x2}", ppData[3]) + " |" + String.Format("{0:x2}", ppData[4]) + "| "
                + ByteArrayToHexString(xBuffer));
        }

        private void parser_checksum (byte[] ppData)

        {
            // No, Bad CS, let print it anyways in RED...
            byte[] xBuffer = new byte[ppData.Length - 5];
            Array.Copy(ppData, 5, xBuffer, 0, ppData.Length - 5);
            Log(LogMsgType.Incoming, "\n" + String.Format("{0:x2}", ppData[0]) + " " + String.Format("{0:x2}", ppData[1]) + " " + String.Format("{0:x2}", ppData[2])
                + " " + String.Format("{0:x2}", ppData[3]) + " |" + String.Format("{0:x2}", ppData[4]) + "| "
                + ByteArrayToHexString(xBuffer));
        }

        #endregion

        #region Events

        private void txtSendData_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user presses [ENTER], send the data now
            if (KeyHandled = e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendData();
            }
        }

        private void txtSendData_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = KeyHandled;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            exitProgram();
        }

        private void exitProgram()
        {
            // The form is closing, save the user's preferences
            SaveSettings();

            btnOpenPort.Text = "Closing...";
            btnOpenPort.Update();

            // We need to wait on GUI
            if (ar != null) ar.AsyncWaitHandle.WaitOne(10000, false);
            if (deAR != null) deAR.AsyncWaitHandle.WaitOne(10000, false);
            if (ceAR != null) ceAR.AsyncWaitHandle.WaitOne(10000, false);

            // If the port is open, close it.
            if (bgPort != null && bgPort.IsPortOpen)
            {
                bgPort.Stop();
            }
            Application.Exit();
        }

        private void menuSaveMyFile_Click(object sender, EventArgs e)
        {
            SaveMyFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // need code here
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
           ceAR = rtfTerminal.BeginInvoke(new EventHandler(delegate
            {
                rtfTerminal.Select(0, rtfTerminal.Text.Length);
                rtfTerminal.SelectedText = string.Empty;
                rtfTerminal.AppendText("\n");
                rtfTerminal.ScrollToCaret();
            }));
            EndInvoke (ceAR);
        }

        #endregion

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            Log(LogMsgType.Normal, "\n In Group Box ");
        }
    }
}