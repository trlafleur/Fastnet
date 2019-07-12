namespace BGTerminal
{
  partial class Terminal
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
        this.txtSendData = new System.Windows.Forms.TextBox();
        this.btnSend = new System.Windows.Forms.Button();
        this.cmbPortName = new System.Windows.Forms.ComboBox();
        this.cmbBaudRate = new System.Windows.Forms.ComboBox();
        this.rbHex = new System.Windows.Forms.RadioButton();
        this.rbText = new System.Windows.Forms.RadioButton();
        this.gbMode = new System.Windows.Forms.GroupBox();
        this.lblComPort = new System.Windows.Forms.Label();
        this.lblBaudRate = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.cmbParity = new System.Windows.Forms.ComboBox();
        this.lblDataBits = new System.Windows.Forms.Label();
        this.cmbDataBits = new System.Windows.Forms.ComboBox();
        this.lblStopBits = new System.Windows.Forms.Label();
        this.cmbStopBits = new System.Windows.Forms.ComboBox();
        this.btnOpenPort = new System.Windows.Forms.Button();
        this.gbPortSettings = new System.Windows.Forms.GroupBox();
        this.lnkAbout = new System.Windows.Forms.LinkLabel();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.rtfTerminal = new RichTextBoxPrintCtrl.RichTextBoxPrintCtrl();
        this.label3 = new System.Windows.Forms.Label();
        this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.printSetupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.printPreviewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.printToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.menuSaveMyFile = new System.Windows.Forms.ToolStripMenuItem();
        this.menuPageSetup = new System.Windows.Forms.ToolStripMenuItem();
        this.menuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
        this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
        this.printDialog1 = new System.Windows.Forms.PrintDialog();
        this.printDocument1 = new System.Drawing.Printing.PrintDocument();
        this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
        this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
        this.bntClear = new System.Windows.Forms.Button();
        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        this.txtSendAddr = new System.Windows.Forms.TextBox();
        this.txtSendCmd = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.addrFilter1 = new System.Windows.Forms.TextBox();
        this.addrFilter2 = new System.Windows.Forms.TextBox();
        this.addrFilter3 = new System.Windows.Forms.TextBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.label10 = new System.Windows.Forms.Label();
        this.cmdFilter3 = new System.Windows.Forms.TextBox();
        this.cmdFilter2 = new System.Windows.Forms.TextBox();
        this.cmdFilter1 = new System.Windows.Forms.TextBox();
        this.label9 = new System.Windows.Forms.Label();
        this.label8 = new System.Windows.Forms.Label();
        this.label7 = new System.Windows.Forms.Label();
        this.cbToFilter3 = new System.Windows.Forms.CheckBox();
        this.cbToFilter2 = new System.Windows.Forms.CheckBox();
        this.cbToFilter1 = new System.Windows.Forms.CheckBox();
        this.cbFromFilter3 = new System.Windows.Forms.CheckBox();
        this.cbFromFilter2 = new System.Windows.Forms.CheckBox();
        this.cbFromFilter1 = new System.Windows.Forms.CheckBox();
        this.txtSendFrom = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.tbCSData = new System.Windows.Forms.TextBox();
        this.tbCSHeader = new System.Windows.Forms.TextBox();
        this.label11 = new System.Windows.Forms.Label();
        this.label12 = new System.Windows.Forms.Label();
        this.groupBox3 = new System.Windows.Forms.GroupBox();
        this.textBox9 = new System.Windows.Forms.TextBox();
        this.label13 = new System.Windows.Forms.Label();
        this.tbBytesSec = new System.Windows.Forms.TextBox();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.groupBox4 = new System.Windows.Forms.GroupBox();
        this.label14 = new System.Windows.Forms.Label();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.label15 = new System.Windows.Forms.Label();
        this.comboBox2 = new System.Windows.Forms.ComboBox();
        this.comboBox3 = new System.Windows.Forms.ComboBox();
        this.label16 = new System.Windows.Forms.Label();
        this.label17 = new System.Windows.Forms.Label();
        this.comboBox4 = new System.Windows.Forms.ComboBox();
        this.comboBox5 = new System.Windows.Forms.ComboBox();
        this.label18 = new System.Windows.Forms.Label();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.groupBox5 = new System.Windows.Forms.GroupBox();
        this.textBox5 = new System.Windows.Forms.TextBox();
        this.textBox6 = new System.Windows.Forms.TextBox();
        this.textBox7 = new System.Windows.Forms.TextBox();
        this.textBox8 = new System.Windows.Forms.TextBox();
        this.button3 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button1 = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.textBox4 = new System.Windows.Forms.TextBox();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.gbMode.SuspendLayout();
        this.gbPortSettings.SuspendLayout();
        this.groupBox1.SuspendLayout();
        this.menuStrip1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.groupBox3.SuspendLayout();
        this.tabControl1.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.groupBox4.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.groupBox5.SuspendLayout();
        this.SuspendLayout();
        // 
        // txtSendData
        // 
        this.txtSendData.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.txtSendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtSendData.Location = new System.Drawing.Point(124, 37);
        this.txtSendData.Name = "txtSendData";
        this.txtSendData.Size = new System.Drawing.Size(223, 20);
        this.txtSendData.TabIndex = 11;
        this.txtSendData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSendData_KeyPress);
        this.txtSendData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSendData_KeyDown);
        // 
        // btnSend
        // 
        this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.btnSend.Location = new System.Drawing.Point(353, 35);
        this.btnSend.Name = "btnSend";
        this.btnSend.Size = new System.Drawing.Size(75, 23);
        this.btnSend.TabIndex = 3;
        this.btnSend.Text = "Send";
        this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
        // 
        // cmbPortName
        // 
        this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbPortName.FormattingEnabled = true;
        this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13"});
        this.cmbPortName.Location = new System.Drawing.Point(13, 35);
        this.cmbPortName.Name = "cmbPortName";
        this.cmbPortName.Size = new System.Drawing.Size(67, 21);
        this.cmbPortName.TabIndex = 1;
        // 
        // cmbBaudRate
        // 
        this.cmbBaudRate.FormattingEnabled = true;
        this.cmbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "36000",
            "38400",
            "115000"});
        this.cmbBaudRate.Location = new System.Drawing.Point(86, 35);
        this.cmbBaudRate.Name = "cmbBaudRate";
        this.cmbBaudRate.Size = new System.Drawing.Size(69, 21);
        this.cmbBaudRate.TabIndex = 3;
        this.cmbBaudRate.Validating += new System.ComponentModel.CancelEventHandler(this.cmbBaudRate_Validating);
        // 
        // rbHex
        // 
        this.rbHex.AutoSize = true;
        this.rbHex.Location = new System.Drawing.Point(12, 39);
        this.rbHex.Name = "rbHex";
        this.rbHex.Size = new System.Drawing.Size(44, 17);
        this.rbHex.TabIndex = 1;
        this.rbHex.Text = "Hex";
        this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
        // 
        // rbText
        // 
        this.rbText.AutoSize = true;
        this.rbText.Location = new System.Drawing.Point(12, 19);
        this.rbText.Name = "rbText";
        this.rbText.Size = new System.Drawing.Size(46, 17);
        this.rbText.TabIndex = 0;
        this.rbText.Text = "Text";
        this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
        // 
        // gbMode
        // 
        this.gbMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.gbMode.Controls.Add(this.rbText);
        this.gbMode.Controls.Add(this.rbHex);
        this.gbMode.Location = new System.Drawing.Point(402, 441);
        this.gbMode.Name = "gbMode";
        this.gbMode.Size = new System.Drawing.Size(76, 64);
        this.gbMode.TabIndex = 5;
        this.gbMode.TabStop = false;
        this.gbMode.Text = "Data &Mode";
        // 
        // lblComPort
        // 
        this.lblComPort.AutoSize = true;
        this.lblComPort.Location = new System.Drawing.Point(12, 16);
        this.lblComPort.Name = "lblComPort";
        this.lblComPort.Size = new System.Drawing.Size(56, 13);
        this.lblComPort.TabIndex = 0;
        this.lblComPort.Text = "COM Port:";
        // 
        // lblBaudRate
        // 
        this.lblBaudRate.AutoSize = true;
        this.lblBaudRate.Location = new System.Drawing.Point(83, 16);
        this.lblBaudRate.Name = "lblBaudRate";
        this.lblBaudRate.Size = new System.Drawing.Size(61, 13);
        this.lblBaudRate.TabIndex = 2;
        this.lblBaudRate.Text = "Baud Rate:";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(158, 16);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(36, 13);
        this.label1.TabIndex = 4;
        this.label1.Text = "Parity:";
        // 
        // cmbParity
        // 
        this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbParity.FormattingEnabled = true;
        this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
        this.cmbParity.Location = new System.Drawing.Point(161, 35);
        this.cmbParity.Name = "cmbParity";
        this.cmbParity.Size = new System.Drawing.Size(60, 21);
        this.cmbParity.TabIndex = 5;
        // 
        // lblDataBits
        // 
        this.lblDataBits.AutoSize = true;
        this.lblDataBits.Location = new System.Drawing.Point(224, 16);
        this.lblDataBits.Name = "lblDataBits";
        this.lblDataBits.Size = new System.Drawing.Size(53, 13);
        this.lblDataBits.TabIndex = 6;
        this.lblDataBits.Text = "Data Bits:";
        // 
        // cmbDataBits
        // 
        this.cmbDataBits.FormattingEnabled = true;
        this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
        this.cmbDataBits.Location = new System.Drawing.Point(227, 35);
        this.cmbDataBits.Name = "cmbDataBits";
        this.cmbDataBits.Size = new System.Drawing.Size(60, 21);
        this.cmbDataBits.TabIndex = 7;
        this.cmbDataBits.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDataBits_Validating);
        // 
        // lblStopBits
        // 
        this.lblStopBits.AutoSize = true;
        this.lblStopBits.Location = new System.Drawing.Point(290, 16);
        this.lblStopBits.Name = "lblStopBits";
        this.lblStopBits.Size = new System.Drawing.Size(52, 13);
        this.lblStopBits.TabIndex = 8;
        this.lblStopBits.Text = "Stop Bits:";
        // 
        // cmbStopBits
        // 
        this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbStopBits.FormattingEnabled = true;
        this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
        this.cmbStopBits.Location = new System.Drawing.Point(293, 35);
        this.cmbStopBits.Name = "cmbStopBits";
        this.cmbStopBits.Size = new System.Drawing.Size(65, 21);
        this.cmbStopBits.TabIndex = 9;
        // 
        // btnOpenPort
        // 
        this.btnOpenPort.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.btnOpenPort.Location = new System.Drawing.Point(434, 85);
        this.btnOpenPort.Name = "btnOpenPort";
        this.btnOpenPort.Size = new System.Drawing.Size(75, 23);
        this.btnOpenPort.TabIndex = 6;
        this.btnOpenPort.Text = "&Open Ports";
        this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
        // 
        // gbPortSettings
        // 
        this.gbPortSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.gbPortSettings.Controls.Add(this.lblComPort);
        this.gbPortSettings.Controls.Add(this.cmbPortName);
        this.gbPortSettings.Controls.Add(this.lblStopBits);
        this.gbPortSettings.Controls.Add(this.cmbBaudRate);
        this.gbPortSettings.Controls.Add(this.cmbStopBits);
        this.gbPortSettings.Controls.Add(this.lblBaudRate);
        this.gbPortSettings.Controls.Add(this.lblDataBits);
        this.gbPortSettings.Controls.Add(this.cmbParity);
        this.gbPortSettings.Controls.Add(this.cmbDataBits);
        this.gbPortSettings.Controls.Add(this.label1);
        this.gbPortSettings.Location = new System.Drawing.Point(12, 441);
        this.gbPortSettings.Name = "gbPortSettings";
        this.gbPortSettings.Size = new System.Drawing.Size(370, 64);
        this.gbPortSettings.TabIndex = 4;
        this.gbPortSettings.TabStop = false;
        this.gbPortSettings.Text = "B&&G  Port & Settings";
        // 
        // lnkAbout
        // 
        this.lnkAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.lnkAbout.AutoSize = true;
        this.lnkAbout.Location = new System.Drawing.Point(1061, 637);
        this.lnkAbout.Name = "lnkAbout";
        this.lnkAbout.Size = new System.Drawing.Size(35, 13);
        this.lnkAbout.TabIndex = 7;
        this.lnkAbout.TabStop = true;
        this.lnkAbout.Text = "&About";
        this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
        // 
        // groupBox1
        // 
        this.groupBox1.AutoSize = true;
        this.groupBox1.Controls.Add(this.rtfTerminal);
        this.groupBox1.Controls.Add(this.label3);
        this.groupBox1.Location = new System.Drawing.Point(8, 138);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(803, 395);
        this.groupBox1.TabIndex = 9;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Receive Data";
        // 
        // rtfTerminal
        // 
        this.rtfTerminal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.rtfTerminal.Location = new System.Drawing.Point(6, 32);
        this.rtfTerminal.Name = "rtfTerminal";
        this.rtfTerminal.Size = new System.Drawing.Size(777, 344);
        this.rtfTerminal.TabIndex = 2;
        this.rtfTerminal.Text = "";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(3, 16);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(175, 13);
        this.label3.TabIndex = 1;
        this.label3.Text = "To    From  Bytes  Cmd  CS      Data";
        // 
        // fileToolStripMenuItem
        // 
        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
        this.fileToolStripMenuItem.Text = "File";
        // 
        // printSetupToolStripMenuItem
        // 
        this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
        this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.printSetupToolStripMenuItem.Text = "Print Setup";
        // 
        // printPreviewToolStripMenuItem
        // 
        this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
        this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.printPreviewToolStripMenuItem.Text = "Print Preview";
        // 
        // printToolStripMenuItem
        // 
        this.printToolStripMenuItem.Name = "printToolStripMenuItem";
        this.printToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.printToolStripMenuItem.Text = "Print";
        // 
        // exitToolStripMenuItem
        // 
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.exitToolStripMenuItem.Text = "Exit";
        // 
        // fileToolStripMenuItem1
        // 
        this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
        this.fileToolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
        this.fileToolStripMenuItem1.Text = "File";
        // 
        // toolStripMenuItem1
        // 
        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
        this.toolStripMenuItem1.Text = "Menu";
        // 
        // saveToolStripMenuItem
        // 
        this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        this.saveToolStripMenuItem.Text = "Save";
        // 
        // printSetupToolStripMenuItem1
        // 
        this.printSetupToolStripMenuItem1.Name = "printSetupToolStripMenuItem1";
        this.printSetupToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
        this.printSetupToolStripMenuItem1.Text = "Print Setup";
        // 
        // printPreviewToolStripMenuItem1
        // 
        this.printPreviewToolStripMenuItem1.Name = "printPreviewToolStripMenuItem1";
        this.printPreviewToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
        this.printPreviewToolStripMenuItem1.Text = "Print Preview";
        // 
        // printToolStripMenuItem1
        // 
        this.printToolStripMenuItem1.Name = "printToolStripMenuItem1";
        this.printToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
        this.printToolStripMenuItem1.Text = "Print";
        // 
        // exitToolStripMenuItem1
        // 
        this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
        this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
        this.exitToolStripMenuItem1.Text = "Exit";
        // 
        // menuStrip1
        // 
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2});
        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(1104, 24);
        this.menuStrip1.TabIndex = 12;
        this.menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem2
        // 
        this.fileToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.menuSaveMyFile,
            this.menuPageSetup,
            this.menuPrintPreview,
            this.menuPrint,
            this.toolStripSeparator1,
            this.menuExit});
        this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
        this.fileToolStripMenuItem2.Size = new System.Drawing.Size(35, 20);
        this.fileToolStripMenuItem2.Text = "File";
        // 
        // openToolStripMenuItem
        // 
        this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
        this.openToolStripMenuItem.Text = "Open";
        this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
        // 
        // menuSaveMyFile
        // 
        this.menuSaveMyFile.Name = "menuSaveMyFile";
        this.menuSaveMyFile.Size = new System.Drawing.Size(148, 22);
        this.menuSaveMyFile.Text = "&Save";
        this.menuSaveMyFile.Click += new System.EventHandler(this.menuSaveMyFile_Click);
        // 
        // menuPageSetup
        // 
        this.menuPageSetup.Name = "menuPageSetup";
        this.menuPageSetup.Size = new System.Drawing.Size(148, 22);
        this.menuPageSetup.Text = "Print Setup";
        // 
        // menuPrintPreview
        // 
        this.menuPrintPreview.Name = "menuPrintPreview";
        this.menuPrintPreview.Size = new System.Drawing.Size(148, 22);
        this.menuPrintPreview.Text = "Print Preview";
        // 
        // menuPrint
        // 
        this.menuPrint.Name = "menuPrint";
        this.menuPrint.Size = new System.Drawing.Size(148, 22);
        this.menuPrint.Text = "&Print";
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
        // 
        // menuExit
        // 
        this.menuExit.Name = "menuExit";
        this.menuExit.Size = new System.Drawing.Size(148, 22);
        this.menuExit.Text = "E&xit";
        this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
        // 
        // printDialog1
        // 
        this.printDialog1.Document = this.printDocument1;
        this.printDialog1.UseEXDialog = true;
        // 
        // printDocument1
        // 
        this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
        this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
        // 
        // printPreviewDialog1
        // 
        this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
        this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
        this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
        this.printPreviewDialog1.Document = this.printDocument1;
        this.printPreviewDialog1.Enabled = true;
        this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
        this.printPreviewDialog1.Name = "printPreviewDialog1";
        this.printPreviewDialog1.Visible = false;
        // 
        // pageSetupDialog1
        // 
        this.pageSetupDialog1.Document = this.printDocument1;
        // 
        // bntClear
        // 
        this.bntClear.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bntClear.Location = new System.Drawing.Point(434, 34);
        this.bntClear.Name = "bntClear";
        this.bntClear.Size = new System.Drawing.Size(75, 23);
        this.bntClear.TabIndex = 7;
        this.bntClear.Text = "&Clear";
        this.bntClear.Click += new System.EventHandler(this.bntClear_Click);
        // 
        // openFileDialog1
        // 
        this.openFileDialog1.FileName = "openFileDialog1";
        // 
        // txtSendAddr
        // 
        this.txtSendAddr.Location = new System.Drawing.Point(10, 37);
        this.txtSendAddr.MaxLength = 2;
        this.txtSendAddr.Name = "txtSendAddr";
        this.txtSendAddr.Size = new System.Drawing.Size(32, 20);
        this.txtSendAddr.TabIndex = 11;
        // 
        // txtSendCmd
        // 
        this.txtSendCmd.Location = new System.Drawing.Point(86, 37);
        this.txtSendCmd.MaxLength = 2;
        this.txtSendCmd.Name = "txtSendCmd";
        this.txtSendCmd.Size = new System.Drawing.Size(32, 20);
        this.txtSendCmd.TabIndex = 11;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(7, 17);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(20, 13);
        this.label2.TabIndex = 3;
        this.label2.Text = "To";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(84, 17);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(28, 13);
        this.label4.TabIndex = 4;
        this.label4.Text = "Cmd";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(122, 17);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(30, 13);
        this.label5.TabIndex = 4;
        this.label5.Text = "Data";
        // 
        // addrFilter1
        // 
        this.addrFilter1.Location = new System.Drawing.Point(61, 36);
        this.addrFilter1.MaxLength = 2;
        this.addrFilter1.Name = "addrFilter1";
        this.addrFilter1.Size = new System.Drawing.Size(32, 20);
        this.addrFilter1.TabIndex = 14;
        // 
        // addrFilter2
        // 
        this.addrFilter2.Location = new System.Drawing.Point(61, 62);
        this.addrFilter2.MaxLength = 2;
        this.addrFilter2.Name = "addrFilter2";
        this.addrFilter2.Size = new System.Drawing.Size(32, 20);
        this.addrFilter2.TabIndex = 12;
        // 
        // addrFilter3
        // 
        this.addrFilter3.Location = new System.Drawing.Point(61, 88);
        this.addrFilter3.MaxLength = 2;
        this.addrFilter3.Name = "addrFilter3";
        this.addrFilter3.Size = new System.Drawing.Size(32, 20);
        this.addrFilter3.TabIndex = 12;
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.label10);
        this.groupBox2.Controls.Add(this.cmdFilter3);
        this.groupBox2.Controls.Add(this.cmdFilter2);
        this.groupBox2.Controls.Add(this.cmdFilter1);
        this.groupBox2.Controls.Add(this.label9);
        this.groupBox2.Controls.Add(this.label8);
        this.groupBox2.Controls.Add(this.label7);
        this.groupBox2.Controls.Add(this.cbToFilter3);
        this.groupBox2.Controls.Add(this.cbToFilter2);
        this.groupBox2.Controls.Add(this.cbToFilter1);
        this.groupBox2.Controls.Add(this.cbFromFilter3);
        this.groupBox2.Controls.Add(this.cbFromFilter2);
        this.groupBox2.Controls.Add(this.cbFromFilter1);
        this.groupBox2.Controls.Add(this.addrFilter1);
        this.groupBox2.Controls.Add(this.addrFilter3);
        this.groupBox2.Controls.Add(this.addrFilter2);
        this.groupBox2.Location = new System.Drawing.Point(8, 10);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(146, 126);
        this.groupBox2.TabIndex = 15;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Receive Filter";
        this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(96, 17);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(28, 13);
        this.label10.TabIndex = 17;
        this.label10.Text = "Cmd";
        // 
        // cmdFilter3
        // 
        this.cmdFilter3.Location = new System.Drawing.Point(99, 88);
        this.cmdFilter3.MaxLength = 2;
        this.cmdFilter3.Name = "cmdFilter3";
        this.cmdFilter3.Size = new System.Drawing.Size(32, 20);
        this.cmdFilter3.TabIndex = 16;
        // 
        // cmdFilter2
        // 
        this.cmdFilter2.Location = new System.Drawing.Point(98, 62);
        this.cmdFilter2.MaxLength = 2;
        this.cmdFilter2.Name = "cmdFilter2";
        this.cmdFilter2.Size = new System.Drawing.Size(32, 20);
        this.cmdFilter2.TabIndex = 20;
        // 
        // cmdFilter1
        // 
        this.cmdFilter1.Location = new System.Drawing.Point(99, 37);
        this.cmdFilter1.MaxLength = 2;
        this.cmdFilter1.Name = "cmdFilter1";
        this.cmdFilter1.Size = new System.Drawing.Size(32, 20);
        this.cmdFilter1.TabIndex = 16;
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(64, 16);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(29, 13);
        this.label9.TabIndex = 16;
        this.label9.Text = "Addr";
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(28, 16);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(30, 13);
        this.label8.TabIndex = 16;
        this.label8.Text = "From";
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(7, 16);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(20, 13);
        this.label7.TabIndex = 16;
        this.label7.Text = "To";
        // 
        // cbToFilter3
        // 
        this.cbToFilter3.AutoSize = true;
        this.cbToFilter3.Location = new System.Drawing.Point(12, 91);
        this.cbToFilter3.Name = "cbToFilter3";
        this.cbToFilter3.Size = new System.Drawing.Size(15, 14);
        this.cbToFilter3.TabIndex = 17;
        this.cbToFilter3.UseVisualStyleBackColor = true;
        // 
        // cbToFilter2
        // 
        this.cbToFilter2.AutoSize = true;
        this.cbToFilter2.Location = new System.Drawing.Point(12, 65);
        this.cbToFilter2.Name = "cbToFilter2";
        this.cbToFilter2.Size = new System.Drawing.Size(15, 14);
        this.cbToFilter2.TabIndex = 19;
        this.cbToFilter2.UseVisualStyleBackColor = true;
        // 
        // cbToFilter1
        // 
        this.cbToFilter1.AutoSize = true;
        this.cbToFilter1.Location = new System.Drawing.Point(12, 40);
        this.cbToFilter1.Name = "cbToFilter1";
        this.cbToFilter1.Size = new System.Drawing.Size(15, 14);
        this.cbToFilter1.TabIndex = 17;
        this.cbToFilter1.UseVisualStyleBackColor = true;
        // 
        // cbFromFilter3
        // 
        this.cbFromFilter3.AutoSize = true;
        this.cbFromFilter3.Location = new System.Drawing.Point(40, 91);
        this.cbFromFilter3.Name = "cbFromFilter3";
        this.cbFromFilter3.Size = new System.Drawing.Size(15, 14);
        this.cbFromFilter3.TabIndex = 18;
        this.cbFromFilter3.UseVisualStyleBackColor = true;
        // 
        // cbFromFilter2
        // 
        this.cbFromFilter2.AutoSize = true;
        this.cbFromFilter2.Location = new System.Drawing.Point(40, 65);
        this.cbFromFilter2.Name = "cbFromFilter2";
        this.cbFromFilter2.Size = new System.Drawing.Size(15, 14);
        this.cbFromFilter2.TabIndex = 17;
        this.cbFromFilter2.UseVisualStyleBackColor = true;
        // 
        // cbFromFilter1
        // 
        this.cbFromFilter1.AutoSize = true;
        this.cbFromFilter1.Location = new System.Drawing.Point(40, 40);
        this.cbFromFilter1.Name = "cbFromFilter1";
        this.cbFromFilter1.Size = new System.Drawing.Size(15, 14);
        this.cbFromFilter1.TabIndex = 16;
        this.cbFromFilter1.UseVisualStyleBackColor = true;
        // 
        // txtSendFrom
        // 
        this.txtSendFrom.Location = new System.Drawing.Point(48, 37);
        this.txtSendFrom.MaxLength = 2;
        this.txtSendFrom.Name = "txtSendFrom";
        this.txtSendFrom.Size = new System.Drawing.Size(32, 20);
        this.txtSendFrom.TabIndex = 11;
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(46, 17);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(30, 13);
        this.label6.TabIndex = 4;
        this.label6.Text = "From";
        // 
        // tbCSData
        // 
        this.tbCSData.Location = new System.Drawing.Point(54, 36);
        this.tbCSData.Name = "tbCSData";
        this.tbCSData.Size = new System.Drawing.Size(59, 20);
        this.tbCSData.TabIndex = 16;
        // 
        // tbCSHeader
        // 
        this.tbCSHeader.Location = new System.Drawing.Point(54, 10);
        this.tbCSHeader.Name = "tbCSHeader";
        this.tbCSHeader.Size = new System.Drawing.Size(59, 20);
        this.tbCSHeader.TabIndex = 17;
        // 
        // label11
        // 
        this.label11.AutoSize = true;
        this.label11.Location = new System.Drawing.Point(6, 16);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(42, 13);
        this.label11.TabIndex = 19;
        this.label11.Text = "Header";
        // 
        // label12
        // 
        this.label12.AutoSize = true;
        this.label12.Location = new System.Drawing.Point(6, 39);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(36, 13);
        this.label12.TabIndex = 20;
        this.label12.Text = "Frame";
        // 
        // groupBox3
        // 
        this.groupBox3.Controls.Add(this.textBox9);
        this.groupBox3.Controls.Add(this.label13);
        this.groupBox3.Controls.Add(this.tbBytesSec);
        this.groupBox3.Controls.Add(this.tbCSHeader);
        this.groupBox3.Controls.Add(this.label12);
        this.groupBox3.Controls.Add(this.tbCSData);
        this.groupBox3.Controls.Add(this.label11);
        this.groupBox3.Location = new System.Drawing.Point(681, 10);
        this.groupBox3.Name = "groupBox3";
        this.groupBox3.Size = new System.Drawing.Size(129, 126);
        this.groupBox3.TabIndex = 21;
        this.groupBox3.TabStop = false;
        this.groupBox3.Text = "Errors";
        // 
        // textBox9
        // 
        this.textBox9.Location = new System.Drawing.Point(54, 90);
        this.textBox9.Name = "textBox9";
        this.textBox9.Size = new System.Drawing.Size(59, 20);
        this.textBox9.TabIndex = 22;
        // 
        // label13
        // 
        this.label13.AutoSize = true;
        this.label13.Location = new System.Drawing.Point(6, 65);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(38, 13);
        this.label13.TabIndex = 21;
        this.label13.Text = "B/Sec";
        // 
        // tbBytesSec
        // 
        this.tbBytesSec.Location = new System.Drawing.Point(54, 62);
        this.tbBytesSec.Name = "tbBytesSec";
        this.tbBytesSec.Size = new System.Drawing.Size(59, 20);
        this.tbBytesSec.TabIndex = 17;
        // 
        // timer1
        // 
        this.timer1.Interval = 1000;
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.tabPage1);
        this.tabControl1.Controls.Add(this.tabPage2);
        this.tabControl1.Controls.Add(this.tabPage3);
        this.tabControl1.Location = new System.Drawing.Point(12, 27);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(833, 573);
        this.tabControl1.TabIndex = 22;
        // 
        // tabPage1
        // 
        this.tabPage1.Controls.Add(this.groupBox4);
        this.tabPage1.Controls.Add(this.gbPortSettings);
        this.tabPage1.Controls.Add(this.gbMode);
        this.tabPage1.Location = new System.Drawing.Point(4, 22);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(1073, 581);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "Setup";
        this.tabPage1.UseVisualStyleBackColor = true;
        // 
        // groupBox4
        // 
        this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.groupBox4.Controls.Add(this.label14);
        this.groupBox4.Controls.Add(this.comboBox1);
        this.groupBox4.Controls.Add(this.label15);
        this.groupBox4.Controls.Add(this.comboBox2);
        this.groupBox4.Controls.Add(this.comboBox3);
        this.groupBox4.Controls.Add(this.label16);
        this.groupBox4.Controls.Add(this.label17);
        this.groupBox4.Controls.Add(this.comboBox4);
        this.groupBox4.Controls.Add(this.comboBox5);
        this.groupBox4.Controls.Add(this.label18);
        this.groupBox4.Location = new System.Drawing.Point(12, 511);
        this.groupBox4.Name = "groupBox4";
        this.groupBox4.Size = new System.Drawing.Size(370, 64);
        this.groupBox4.TabIndex = 6;
        this.groupBox4.TabStop = false;
        this.groupBox4.Text = "NMEA Port & Settings";
        // 
        // label14
        // 
        this.label14.AutoSize = true;
        this.label14.Location = new System.Drawing.Point(12, 16);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(56, 13);
        this.label14.TabIndex = 0;
        this.label14.Text = "COM Port:";
        // 
        // comboBox1
        // 
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13"});
        this.comboBox1.Location = new System.Drawing.Point(13, 35);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(67, 21);
        this.comboBox1.TabIndex = 1;
        // 
        // label15
        // 
        this.label15.AutoSize = true;
        this.label15.Location = new System.Drawing.Point(290, 16);
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.Size(52, 13);
        this.label15.TabIndex = 8;
        this.label15.Text = "Stop Bits:";
        // 
        // comboBox2
        // 
        this.comboBox2.FormattingEnabled = true;
        this.comboBox2.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "36000",
            "38400",
            "115000"});
        this.comboBox2.Location = new System.Drawing.Point(86, 35);
        this.comboBox2.Name = "comboBox2";
        this.comboBox2.Size = new System.Drawing.Size(69, 21);
        this.comboBox2.TabIndex = 3;
        // 
        // comboBox3
        // 
        this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox3.FormattingEnabled = true;
        this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
        this.comboBox3.Location = new System.Drawing.Point(293, 35);
        this.comboBox3.Name = "comboBox3";
        this.comboBox3.Size = new System.Drawing.Size(65, 21);
        this.comboBox3.TabIndex = 9;
        // 
        // label16
        // 
        this.label16.AutoSize = true;
        this.label16.Location = new System.Drawing.Point(83, 16);
        this.label16.Name = "label16";
        this.label16.Size = new System.Drawing.Size(61, 13);
        this.label16.TabIndex = 2;
        this.label16.Text = "Baud Rate:";
        // 
        // label17
        // 
        this.label17.AutoSize = true;
        this.label17.Location = new System.Drawing.Point(224, 16);
        this.label17.Name = "label17";
        this.label17.Size = new System.Drawing.Size(53, 13);
        this.label17.TabIndex = 6;
        this.label17.Text = "Data Bits:";
        // 
        // comboBox4
        // 
        this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox4.FormattingEnabled = true;
        this.comboBox4.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
        this.comboBox4.Location = new System.Drawing.Point(161, 35);
        this.comboBox4.Name = "comboBox4";
        this.comboBox4.Size = new System.Drawing.Size(60, 21);
        this.comboBox4.TabIndex = 5;
        // 
        // comboBox5
        // 
        this.comboBox5.FormattingEnabled = true;
        this.comboBox5.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
        this.comboBox5.Location = new System.Drawing.Point(227, 35);
        this.comboBox5.Name = "comboBox5";
        this.comboBox5.Size = new System.Drawing.Size(60, 21);
        this.comboBox5.TabIndex = 7;
        // 
        // label18
        // 
        this.label18.AutoSize = true;
        this.label18.Location = new System.Drawing.Point(158, 16);
        this.label18.Name = "label18";
        this.label18.Size = new System.Drawing.Size(36, 13);
        this.label18.TabIndex = 4;
        this.label18.Text = "Parity:";
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.groupBox5);
        this.tabPage2.Controls.Add(this.groupBox2);
        this.tabPage2.Controls.Add(this.groupBox3);
        this.tabPage2.Controls.Add(this.groupBox1);
        this.tabPage2.Location = new System.Drawing.Point(4, 22);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(825, 547);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "B&&G Monitor";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // groupBox5
        // 
        this.groupBox5.Controls.Add(this.textBox5);
        this.groupBox5.Controls.Add(this.textBox6);
        this.groupBox5.Controls.Add(this.btnOpenPort);
        this.groupBox5.Controls.Add(this.textBox7);
        this.groupBox5.Controls.Add(this.textBox8);
        this.groupBox5.Controls.Add(this.button3);
        this.groupBox5.Controls.Add(this.button2);
        this.groupBox5.Controls.Add(this.txtSendData);
        this.groupBox5.Controls.Add(this.button1);
        this.groupBox5.Controls.Add(this.label5);
        this.groupBox5.Controls.Add(this.textBox1);
        this.groupBox5.Controls.Add(this.label4);
        this.groupBox5.Controls.Add(this.textBox2);
        this.groupBox5.Controls.Add(this.txtSendAddr);
        this.groupBox5.Controls.Add(this.textBox3);
        this.groupBox5.Controls.Add(this.txtSendCmd);
        this.groupBox5.Controls.Add(this.textBox4);
        this.groupBox5.Controls.Add(this.label2);
        this.groupBox5.Controls.Add(this.btnSend);
        this.groupBox5.Controls.Add(this.bntClear);
        this.groupBox5.Controls.Add(this.txtSendFrom);
        this.groupBox5.Controls.Add(this.label6);
        this.groupBox5.Location = new System.Drawing.Point(160, 10);
        this.groupBox5.Name = "groupBox5";
        this.groupBox5.Size = new System.Drawing.Size(515, 126);
        this.groupBox5.TabIndex = 26;
        this.groupBox5.TabStop = false;
        this.groupBox5.Text = "Send";
        // 
        // textBox5
        // 
        this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.textBox5.Location = new System.Drawing.Point(124, 88);
        this.textBox5.Name = "textBox5";
        this.textBox5.Size = new System.Drawing.Size(223, 20);
        this.textBox5.TabIndex = 29;
        // 
        // textBox6
        // 
        this.textBox6.Location = new System.Drawing.Point(48, 88);
        this.textBox6.MaxLength = 2;
        this.textBox6.Name = "textBox6";
        this.textBox6.Size = new System.Drawing.Size(32, 20);
        this.textBox6.TabIndex = 30;
        // 
        // textBox7
        // 
        this.textBox7.Location = new System.Drawing.Point(86, 88);
        this.textBox7.MaxLength = 2;
        this.textBox7.Name = "textBox7";
        this.textBox7.Size = new System.Drawing.Size(32, 20);
        this.textBox7.TabIndex = 27;
        // 
        // textBox8
        // 
        this.textBox8.Location = new System.Drawing.Point(11, 88);
        this.textBox8.MaxLength = 2;
        this.textBox8.Name = "textBox8";
        this.textBox8.Size = new System.Drawing.Size(32, 20);
        this.textBox8.TabIndex = 28;
        // 
        // button3
        // 
        this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.button3.Location = new System.Drawing.Point(353, 86);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(75, 23);
        this.button3.TabIndex = 26;
        this.button3.Text = "Send";
        // 
        // button2
        // 
        this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.button2.Location = new System.Drawing.Point(434, 60);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(75, 23);
        this.button2.TabIndex = 7;
        this.button2.Text = "&Print";
        // 
        // button1
        // 
        this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.button1.Location = new System.Drawing.Point(353, 60);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(75, 23);
        this.button1.TabIndex = 4;
        this.button1.Text = "Send";
        // 
        // textBox1
        // 
        this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.textBox1.Location = new System.Drawing.Point(124, 62);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(223, 20);
        this.textBox1.TabIndex = 24;
        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(48, 62);
        this.textBox2.MaxLength = 2;
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(32, 20);
        this.textBox2.TabIndex = 25;
        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(86, 62);
        this.textBox3.MaxLength = 2;
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(32, 20);
        this.textBox3.TabIndex = 22;
        // 
        // textBox4
        // 
        this.textBox4.Location = new System.Drawing.Point(11, 62);
        this.textBox4.MaxLength = 2;
        this.textBox4.Name = "textBox4";
        this.textBox4.Size = new System.Drawing.Size(32, 20);
        this.textBox4.TabIndex = 23;
        // 
        // tabPage3
        // 
        this.tabPage3.Location = new System.Drawing.Point(4, 22);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Size = new System.Drawing.Size(1073, 581);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "NMEA Monitor";
        this.tabPage3.UseVisualStyleBackColor = true;
        // 
        // Terminal
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1104, 659);
        this.Controls.Add(this.tabControl1);
        this.Controls.Add(this.lnkAbout);
        this.Controls.Add(this.menuStrip1);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MainMenuStrip = this.menuStrip1;
        this.MinimumSize = new System.Drawing.Size(559, 288);
        this.Name = "Terminal";
        this.Text = "B&G 2000 Command Monitor";
        this.Shown += new System.EventHandler(this.frmTerminal_Shown);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTerminal_FormClosing);
        this.gbMode.ResumeLayout(false);
        this.gbMode.PerformLayout();
        this.gbPortSettings.ResumeLayout(false);
        this.gbPortSettings.PerformLayout();
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox2.PerformLayout();
        this.groupBox3.ResumeLayout(false);
        this.groupBox3.PerformLayout();
        this.tabControl1.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.groupBox4.ResumeLayout(false);
        this.groupBox4.PerformLayout();
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        this.groupBox5.ResumeLayout(false);
        this.groupBox5.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

      private System.Windows.Forms.TextBox txtSendData;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.ComboBox cmbPortName;
    private System.Windows.Forms.ComboBox cmbBaudRate;
    private System.Windows.Forms.RadioButton rbHex;
    private System.Windows.Forms.RadioButton rbText;
    private System.Windows.Forms.GroupBox gbMode;
    private System.Windows.Forms.Label lblComPort;
    private System.Windows.Forms.Label lblBaudRate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbParity;
    private System.Windows.Forms.Label lblDataBits;
    private System.Windows.Forms.ComboBox cmbDataBits;
    private System.Windows.Forms.Label lblStopBits;
    private System.Windows.Forms.ComboBox cmbStopBits;
    private System.Windows.Forms.Button btnOpenPort;
    private System.Windows.Forms.GroupBox gbPortSettings;
      private System.Windows.Forms.LinkLabel lnkAbout;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
      private System.Windows.Forms.SaveFileDialog saveFileDialog1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem menuSaveMyFile;
      private System.Windows.Forms.ToolStripMenuItem menuPageSetup;
      private System.Windows.Forms.ToolStripMenuItem menuPrintPreview;
      private System.Windows.Forms.ToolStripMenuItem menuPrint;
      private System.Windows.Forms.ToolStripMenuItem menuExit;
      private RichTextBoxPrintCtrl.RichTextBoxPrintCtrl rtfTerminal;
      private System.Windows.Forms.PrintDialog printDialog1;
      private System.Drawing.Printing.PrintDocument printDocument1;
      private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
      private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.Button bntClear;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.TextBox txtSendAddr;
      private System.Windows.Forms.TextBox txtSendCmd;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox addrFilter1;
      private System.Windows.Forms.TextBox addrFilter2;
      private System.Windows.Forms.TextBox addrFilter3;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.CheckBox cbFromFilter3;
      private System.Windows.Forms.CheckBox cbFromFilter2;
      private System.Windows.Forms.CheckBox cbFromFilter1;
      private System.Windows.Forms.TextBox txtSendFrom;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.CheckBox cbToFilter3;
      private System.Windows.Forms.CheckBox cbToFilter2;
      private System.Windows.Forms.CheckBox cbToFilter1;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox cmdFilter3;
      private System.Windows.Forms.TextBox cmdFilter2;
      private System.Windows.Forms.TextBox cmdFilter1;
      private System.Windows.Forms.TextBox tbCSData;
      private System.Windows.Forms.TextBox tbCSHeader;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.TextBox tbBytesSec;
      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.TabPage tabPage2;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.ComboBox comboBox2;
      private System.Windows.Forms.ComboBox comboBox3;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Label label17;
      private System.Windows.Forms.ComboBox comboBox4;
      private System.Windows.Forms.ComboBox comboBox5;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.GroupBox groupBox5;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.TextBox textBox3;
      private System.Windows.Forms.TextBox textBox4;
      private System.Windows.Forms.TextBox textBox5;
      private System.Windows.Forms.TextBox textBox6;
      private System.Windows.Forms.TextBox textBox7;
      private System.Windows.Forms.TextBox textBox8;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.TextBox textBox9;
      private System.Windows.Forms.TabPage tabPage3;
  }
}

