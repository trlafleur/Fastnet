/* 
 * Project:    B&G H2000 Network SerialPort class
 * Company:    Lafleur Designs
 * Author:     Tom Lafleur
 * Created:    November 2006
 * 
 * Notes:      This class was created to control the serial port on the Brook and Gatehouse 
 *             B&G H2000 via a network interface box to a USB Serial Port interface
 *             Allows a PC to receive and send data on the B&G network bus
 *              Note: VS 2005 has a known bug with a file name with a "&" inside... 
 *                      ie: we can't name any of the files on this project "B&G"
 */

#region Namespace Inclusions

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace BGSerialLib
{

    // <summary>
    /// Class for handling communications with the B&G H2000 USB Interface
    /// </summary>
    public class BGSerialPort : IDisposable
    {
        #region Local Variables

        // Create a byte array buffer to hold the incoming data
        byte[] sBuffer = new byte[65000];

        int startBuffer = 0;
        int endBuffer = 0;
        bool reScanFlag = false;

        // Let look at error that we see...
        int csHeaderErrors = 0;
        int csFrameErrors = 0;

        private int _TimeOut = 10; //Set receive default timeout to 10 seconds
        private long TimeSinceLastEvent;
        private bool HasTimedOut;
        private string serialPort = String.Empty;
       
        private const int _receivedBytesThreshold = 30;

        private SerialPort comport = null;
        
        /// <summary>
        /// Delegate type for hooking up change notifications.
        /// </summary>
        public delegate void NewBGDataHandler(object sender, BGEventArgs e);

        /// <summary>
        /// Event fired whenever new GPS data is acquired from the receiver.
        /// </summary>
        public event NewBGDataHandler NewBGData;

        /// <summary>
        /// Eventtype parsed when B&G sends a frame
        /// </summary>
        public class BGEventArgs : EventArgs
        {
            /// <summary>
            /// Type of event that occured, specied by BG type (Valid, Checksum, Timeout, ect...)
            /// </summary>
            public BGEventType TypeOfEvent;
            /// <summary>
            /// The complete Frame that we received
            /// </summary>
            public byte[] Sentence;
        }

        #endregion


       #region Local Methods

        /// <summary>
        /// Cancatenates 2 byte arrays together into one
        /// </summary>
        /// <param name="a">1st byte array</param>
        /// <param name="b">2nd byte array</param>
        /// <returns>Concatenated a into b, byte array</returns>
        private byte[] ConcatBytes(byte[] a, byte[] b)
        {
            byte[] bytes = new byte[a.Length + b.Length];
            Array.Copy(a, bytes, a.Length);
            Array.Copy(b, 0, bytes, a.Length, b.Length);
            return bytes;
        }

        /// <summary> Check Buffer for end of buffer and adjust pointer if needed</summary>
        /// <param name="a">size of new data</param>
        /// <returns>Boolean</returns>
        private Boolean checkBuffer(int numChar)
        {     // This routine will manage the sBuffer pointers

            if (endBuffer + numChar >= sBuffer.Length)
            {
                // Build temp buffer
                byte[] xBuffer = new byte[sBuffer.Length];
                // copy the current data to beginning of temp buffer
                Array.Copy(sBuffer, startBuffer, xBuffer, 0, endBuffer - startBuffer);
                sBuffer = xBuffer;
                endBuffer = endBuffer - startBuffer;
                startBuffer = 0;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Search a byte arrays for data, starting a C, for B until end
        /// </summary>
        /// <param name="a">byte array</param>
        /// <param name="b">int</param>
        /// <param name="c">int</param>
        /// <returns>Search a for b, int index, start</returns>
        private int SearchBytes(byte[] a, byte b, int c, int end)
        {
            while (c < end)
            {
                if (a[c] != b)
                { c++; } // No match
                else
                { return c; } // We have a match
            }
            return -1;
        }


        /// <summary>
        /// Compute the Rx Checksum over a number of bytes
        /// </summary>
        /// <param name="array">byte array</param>
        /// <param name="start">int start</param>
        /// <param name="last">int end</param>
        /// <returns>True if ok</returns>
        private bool checkSum(byte[] array, int start, int end)
        {
            byte cs = 0;    // Clear checksum           
            // Lets do CS for all data and its checksum
            // B&G H2000 checksum is a zero sum of all bytes + CS
            while (start < end)
            {
                cs += array[start];
                start++;
            }
            if (cs == 0) { return true; }
            else { return false; }
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

        #endregion 
        
        /// <summary>
        /// Initilializes the serialport
        /// </summary>
        public BGSerialPort()
        {
        }
        
        public BGSerialPort(string SerialPort)
        {
            serialPort = SerialPort;
           
        }

        public void Dispose()
        {
            if (comport != null)
            {
                this.Stop();
                comport = null;
            }
            
            // Take yourself off the Finalization queue 
            // to prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets or sets the timeout in seconds.
        /// <remarks>5 second default</remarks>
        /// </summary>
        public int TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }
        
        /// <summary>
        /// Gets or sets the CheckSum Header Errors
        /// </summary>
        public int HeaderErrors
        {
            get { return csHeaderErrors; }
            set { csHeaderErrors = value; }
        }

        /// <summary>
        /// Gets or Sets the CheckSum Frame Errors
        /// </summary>
        public int FrameErrors
        {
            get { return csFrameErrors; }
            set { csFrameErrors = value; }
        }

        /// <summary>
        /// Serial port
        /// </summary>
        public string Port
        {
            get { return comport.PortName; }
            set { comport.PortName = value; }
        }

        /// <summary>
        /// Serial port CTS status
        /// </summary>
        public bool CtsStatus
        {
            get { return comport.CtsHolding; }
        }

        /// <summary>
        /// Opens the B&G serial port and starts parsing data
        /// </summary>
        private void Open()
        {
            if (comport == null)
            {
                if (serialPort != String.Empty)
                {
                    comport = new SerialPort(serialPort);
                    // We need to force these options for the B&G interface
                    comport.Parity = Parity.Odd;
                    comport.StopBits = StopBits.Two;
                    comport.DataBits = 8;
                    comport.BaudRate = 28800;
                    comport.ReceivedBytesThreshold = _receivedBytesThreshold;
                    comport.RtsEnable = true;
                    comport.DtrEnable = true;
                    comport.DiscardNull = false;

                    // Set up timer values
                    TimeSinceLastEvent = DateTime.Now.Ticks;
                    HasTimedOut = false;

                    // When data is recieved through the port, call this method
                    comport.DataReceived += new SerialDataReceivedEventHandler(BGport_DataReceived);

                    try
                    {
                        comport.Open();
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("\n Can't Opend Port");
                    }
                    // Flush out any buffers
                    comport.DiscardInBuffer();
                    comport.DiscardOutBuffer();
                }
                else
                {
                    throw new NullReferenceException("Comm Port Not Set");
                }
            }
            else
            {
                throw new IOException("Serial Port Is Already Open");
            }
        }

        /// <summary>
        /// Species whether the serialport is open or not
        /// </summary>
        public bool IsPortOpen
        {
            get 
            {
                if (comport != null)
                {
                    return comport.IsOpen;
                }

                return false;
            }
        }

        /// <summary>
        /// Sends data to serial port.
        /// </summary>
        /// <param name="BufBytes">Data to write to serial port</param>
        public void WriteData(byte[] BufBytes, int x, int length)
        {
            comport.Write(BufBytes, x, length);
        }

        /// <summary>
        /// Fires a NewBG event
        /// </summary>
        /// <param name="type">Type of BG event (Valid, CheckSum, ect...)</param>
        /// <param name="sentence">Frame </param>
        private void FireEvent(BGEventType type, byte[] sentence)
        {
            if (NewBGData != null)
            {
                BGEventArgs e = new BGEventArgs();
                e.TypeOfEvent = type;
                e.Sentence = sentence;

                try
                {
                    Control cnt = NewBGData.Target as Control;
                    if (cnt != null && cnt.InvokeRequired)
                    {
                        cnt.BeginInvoke(new NewBGDataHandler(NewBGData), new object[] { this, e });
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                              
                NewBGData(this, e);
            }
        }
        

        /// <summary>
        /// Closes the port and ends the thread.
        /// </summary>
        public void Stop()
        {
            if (comport != null)
                if (comport.IsOpen)
                {
                   comport.DataReceived -= new SerialDataReceivedEventHandler(BGport_DataReceived);
                    
                   comport.DiscardInBuffer();
                   comport.DiscardOutBuffer();
                   Application.DoEvents();
                   comport.Dispose();
                   //comport.Close();
                   comport = null;
                }
        }

        /// <summary>
        /// Opens the serial port and starts parsing B&G data. Returns when the port is closed.
        /// </summary>
        public void Start()
        {
            Open();
        }


        ////  <---------------------------- need some work here ---------------------------------------
        ///// <summary> 
        ///// Check the serial port for data. If data is available, data is read and parsed.
        ///// This is a loop the keeps running until the port is closed.
        ///// </summary>
        //private void Read()
        //{
        //    int MilliSecondsWait = 10;
        //    string strData = "";
        //    this.Open();

        //    while (com.IsOpen)
        //    {
        //        int nBytes = com.BytesToRead;
        //        byte[] BufBytes;
        //        BufBytes = new byte[nBytes];

        //        com.Read(BufBytes, 0, nBytes);

        //        strData += Encoding.GetEncoding("ASCII").GetString(BufBytes, 0, nBytes);

        //        string temp = "";
        //        while (strData != temp)
        //        {
        //            temp = strData;
        //            strData = GetNmeaString(strData);
        //        }

        //        Thread.Sleep(MilliSecondsWait);

        //        if (DateTime.Now.Ticks - TimeSinceLastEvent > 10000000 * _TimeOut && !HasTimedOut)
        //        {
        //            HasTimedOut = true;
        //            FireEvent(GPSEventType.TimeOut, "");
        //        }
        //    }
        //}

  

        #region BG Frame Builder
      
        private void BGport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // This method will be called when there is data waiting in the port's buffer
            // Obtain the number of bytes waiting in the port's buffer

            int bytes = comport.BytesToRead;

            // Read the data from the serial-port and store it in our private buffer
            // Make sure we are not near the end of our private buffer

            //checkBuffer(bytes);
            //byte[] xxBuffer = new byte[bytes];
            //comport.Read(xxBuffer, 0, bytes);

            comport.Read(sBuffer, endBuffer, bytes);
            endBuffer = endBuffer + bytes;

            // sBuffer now has all of the bytes that we have from the serial port
            // startBuffer is a pointer to the start of real data, 
            // endBuffer is a pointer to the last location + 1 of data
            // We need to build a frame to give to the parser

            // The do-While loop will force a re-scan of the buffer if needed

            reScanFlag = false;

            do 
            { 
                buildFrame(); 
            }while (reScanFlag);
        }

        private void buildFrame()
        {
            if (endBuffer - startBuffer > 0)  // Ok, lets make sure that we have data in sBuffer
            {
                // Now, lets see if we have a full frame
                // Minimum valid header size is 5 bytes
                // Format is:  ff  tt ll cc cs
                // ff is FROM addr, tt is TO device address, ll length of data field (can be zero)
                // cc is command, cs is checksum for header

                if ((endBuffer - startBuffer) >= 5)
                {
                    // Lets see if we have a valid command header
                    // Its possible to have a good header with bad data, this is
                    // due to the type of CS that B&G has selected
                    if (checkSum(sBuffer, startBuffer, startBuffer + 5))
                    {
                        // Yes, we have a good header, lets see if we have a full frame
                        // 5 bytes for header + data size + CS
                        // A cmdLength of zero is valid

                        // Let's get the cmdLength from header
                        int cmdLength = (sBuffer[startBuffer + 2]);

                        if (cmdLength == 0)
                        {
                            // Then we have short, header only frame
                            // Copy frame 
                            byte[] parseBuffer = new byte[5];
                            Array.Copy(sBuffer, startBuffer, parseBuffer, 0, 5);
                            // Adjust sBuffer pointers
                            startBuffer += 5;
                            // Give it to the event Parser
                            parser(parseBuffer);
                            reScanFlag = true; // Force a re-scan, we may have more frames in buffer
                        }
                        else
                        {
                            if ((endBuffer - startBuffer) >= cmdLength + 6)
                            {
                                // Then we may have a full frame with data
                                // Copy frame with header and CS               
                                byte[] parseBuffer = new byte[cmdLength + 6];
                                Array.Copy(sBuffer, startBuffer, parseBuffer, 0, cmdLength + 6);
                                // Adjust sBuffer pointers
                                startBuffer += (cmdLength + 6);
                                // Give it to the event Parser
                                parser(parseBuffer);
                                reScanFlag = true; // Force a re-scan, we may have more full frames in buffer
                            }
                            else
                            // No, we do not have a full frame yet, wait for more data
                            { reScanFlag = false; }
                        }
                    }
                    else
                    {
                        // No, we have a bad header checksum, so we need to sync up with data stream

                        csHeaderErrors++;

                        if (startBuffer + 5 < endBuffer)
                        {
                            startBuffer++;      // Adjust buffer by 1 to try a re-sync
                            reScanFlag = true;  // Force a re-scan
                        }
                        else { reScanFlag = false; }
                    }
                }
                else
                // We do not have enought data for a header yet, so lets wait for more
                { reScanFlag = false; }
            }
            else
            // No data, buffer is empty, wait for more, we should never get here!!!
            { reScanFlag = false; }

            return;
        }

        private void parser(byte[] ppData)
        {
            // Command header size is 5 bytes
            // Format is:  ff  aa ll cc cs
            // ff is from address
            // tt is to address
            // ll length of data field (can be zero)
            // cc is command
            // cs is checksum for header

            // Some devices, like the processor send the CheckSum twice, so lets filter it out
            // This is not ideal, it may be good data, but its all we can do for now

            if (sBuffer[startBuffer - 1] == sBuffer[startBuffer])
            {
                startBuffer++;
            }

            //byte[] xBuffer = new byte[ppData.Length - 5];
            //Array.Copy(ppData, 5, xBuffer, 0, ppData.Length - 5);

            HasTimedOut = false;
            TimeSinceLastEvent = DateTime.Now.Ticks;  // Set current time of this event

            // Let check to see if we have a valid frame
            if (checkSum(ppData, 0, ppData.Length))
            {
                // Yes, we have a good frame
                FireEvent(BGEventType.Valid, ppData);
            }
            else
            {
                // No, we have a frame error
                csFrameErrors++;

                /// we may need to fix this.... header did pas a CS to get here??
                // We maybe out of sync, so lets adjust startBuffer pointers back
                // to the begining of the frame +1 to try a re-sync of the data, re scan
                startBuffer = (startBuffer - ppData.Length + 1);

                // lets send it with a checksum error
                FireEvent(BGEventType.CheckSum, ppData);
            }
        }
#endregion

    }
}
