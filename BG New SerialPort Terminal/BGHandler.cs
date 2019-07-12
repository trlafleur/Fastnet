using System;
using System.Threading;

namespace BGSerialLib
{
    /// <summary>
    /// BG Handler - B&G Serial Library 
    /// </summary>
    public class BGHandler : IDisposable
    {
        internal static SerialPort BGPort = new SerialPort();

        private ThreadStart clThreadStart;
        private Thread clThread;

        //private static bool portopen = false;
        private System.Windows.Forms.Control _Parent;
        private bool disposed = false;

        /// <summary>
        /// A delegate type for hooking up change notifications.
        /// </summary>
        public delegate void NewBGHandler(object sender, BGEventArgs e);

        /// <summary>
        /// Overridden. Fires when the BGHandler has received data from the Network.
        /// </summary>
        public event NewBGHandler NewBG;

        /// <summary>
        /// Event fired whenever new Network data has been processed. Runs in BG thread
        /// </summary>
        private event NewBGHandler _NewBG;



        /// <summary>
        /// Initializes a BGHandler for communication with B$G Network
        /// The BGHandler is used for communication with the B&G Network and process information from the Network.
        /// </summary>
        /// <param name="Parent">Parent form which callbacks should be directed to.</param>
        /// <example>
        /// The following example demonstrates how to create an BGHandler instance that reacts to BG Frames.
        /// <code>
        /// [C#]
        /// public class Form1 : System.Windows.Forms.Form
        /// {
        /// 	public static BGHandler BG;
        /// 	public Form1()
        /// 	{
        /// 	InitializeComponent();
        /// 	//Initialize BG handler
        /// 	BG = new BGHandler(this); 
        /// 	//Hook up BG data events to a handler
        /// 	BG.NewBG += new BGHandler.NewBGHandler(this.BGEventHandler);
        /// }
        /// 
        /// public void ExitApp()
        /// {
        /// 	BG.Dispose();  //Closes serial port and cleans up
        /// 	Application.Exit();
        /// }
        /// 
        /// private void BGEventHandler(object sender, BGHandler.BGEventArgs e)
        /// {
        /// 	switch (e.TypeOfEvent)
        /// 	{
        /// 		case BGEventType.GPRMC:  //Recommended minimum specific BG/Transit data
        /// 			if(BG.HasBGFix) //Is a BG fix available?
        /// 			{
        /// 				lbPosition.Text = BG.RMC.Longitude.ToString() + "," + BG.RMC.Latitude.ToString();
        /// 				lbHeading.Text = BG.RMC.Course.ToString();
        /// 				lbSpeed.Text = BG.RMC.Speed.ToString() + " mph";
        /// 				lbTimeOfFix.Text = BG.RMC.TimeOfFix + " - " + BG.RMC.DateOfFix;
        /// 			}
        /// 			else
        /// 			{
        /// 				lbPosition.Text = "No fix";
        /// 				lbHeading.Text = "N/A";
        /// 				lbSpeed.Text = "N/A";
        /// 				lbTimeOfFix.Text = "N/A";
        /// 			}
        /// 			break;
        /// 	}
        /// }
        /// 
        /// private void btnStartBG_Click(object sender, System.EventArgs e)
        /// {
        /// 	if(!BG.IsPortOpen) 
        /// 	{
        /// 		try
        /// 		{
        /// 			//Open serial port 1             
        /// 			BG.Start("COM1");
        /// 		}
        /// 		catch(System.Exception ex) 
        /// 		{
        /// 			MessageBox.Show("Opem error: " + ex.Message);
        /// 		}
        /// 	}
        /// }
        /// </code>
        /// </example>
        /// 



        public BGHandler(System.Windows.Forms.Control Parent)
        {
            _Parent = Parent;
            disposed = false;
            this._NewBG += new NewBGHandler(this.BGEventHandler);

            //Link event from B&G Network to process data function
            BGPort.NewBGData += new BGSerialLib.SerialPort.NewBGDataHandler(this.BGDataEventHandler);
        }

        /// <summary>
        /// Gets a boolean stating whether the port to the B&G Network is open.
        /// </summary>
        public bool IsPortOpen
        {
            get { return BGPort.IsPortOpen; }
        }

        /// <summary>
        /// Gets a boolean stating CTS status.
        /// </summary>
        public bool IsCTS
        {
            get { return BGPort.CtsStatus; }
        }

        /// <summary>
        /// Gets a int of frameErrors.
        /// </summary>
        public int frameErrors
        {
            get { return BGPort.FrameErrors; }
        }

        /// <summary>
        /// Gets a int of csErrors
        /// </summary>
        public int headersErrors
        {
            get { return BGPort.HeaderErrors; }
        }

        /// <summary>
        /// Parse event from BG thread to Parent thread
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">BGEventArgs</param>
        private void BGEventHandler(object sender, BGEventArgs e)
        {
            ControlInvoker controlInvoker;
            controlInvoker = new ControlInvoker(this._Parent);
            controlInvoker.Invoke(new MethodCallInvoker(ReturnEvent), e); //Send event to parent thread
        }

        private void ReturnEvent(Object[] arguments)
        {
            BGEventArgs e = (BGEventArgs)arguments[0];
            NewBG(this, e); //Fire event back to main application
        }

        /// <summary>
        /// Eventtype invoked when a new message is received from the B&G.
        /// String BGEventArgs.TypeOfEvent specifies eventtype.
        /// </summary>
        public class BGEventArgs : EventArgs
        {
            /// <summary>
            /// Type of event
            /// </summary>
            public BGEventType TypeOfEvent;
            /// <summary>
            /// Full Frame data
            /// </summary>
            public byte [] Sentence;
        }


        /// <summary>
        /// Starts the BG thread and opens the port.
        /// </summary>
        /// <param name="serialPort">Serialport number where B&G is connected (ie. "COM1").</param>
        public void Start(string serialPort)
        {
            BGPort.Port = serialPort;
            this.clThreadStart = new ThreadStart(BGPort.Start);
            this.clThread = new Thread(this.clThreadStart);

            try
            {
                this.clThread.Start();
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Send data to the B&G network
        /// </summary>
        /// <param name="buffer">Send Data To B&G Network</param>
        public void Send(byte[] buffer, int x, int length)
        {
            BGPort.WriteData(buffer,x ,length);
        }


        /// <summary>
        /// Method called when a BG event occured.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BGDataEventHandler(object sender, SerialPort.BGEventArgs e)
        {
            switch (e.TypeOfEvent)
            {
                case BGEventType.Valid:
                    ParseValid(e.Sentence);   
                    break;

                case BGEventType.CheckSum:
                    ParseCS(e.Sentence);
                    break;

                case BGEventType.TimeOut:
                    FireTimeOut();
                    break;

                case BGEventType.Unknown:
                    BGEventArgs e2 = new BGEventArgs();
                    e2.TypeOfEvent = e.TypeOfEvent;
                    e2.Sentence = e.Sentence;
                    _NewBG(this, e2);
                    break;

                default: break;
            }
        }

        /// <summary>
        /// Private method for parsing the CheckSum Frame
        /// </summary>
        /// <param name="CheckSum">Frame</param>
        private void ParseCS(byte[] frame)
        {
            BGEventArgs e = new BGEventArgs();
            e.TypeOfEvent = BGEventType.CheckSum;
            e.Sentence = frame;
            _NewBG(this, e);
        }

        /// <summary>
        /// Private method for parsing the Valid Frame
        /// </summary>
        /// <param name="Valid">Frame</param>
        private void ParseValid(byte[] frame)
        {
            BGEventArgs e = new BGEventArgs();
            e.TypeOfEvent = BGEventType.Valid;
            e.Sentence = frame;
            _NewBG(this, e);
        }

        /// <summary>
        /// Stops the BG thread and closes the port.
        /// </summary>
        public void Stop()
        {
            BGPort.Stop();
            if (this.clThread != null)
                this.clThread.Abort();
            this.clThread = null;
            this.clThreadStart = null;
        }

        /// <summary>
        /// Disposes the BGHandler and if nessesary calls Stop()
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                Stop();
                BGPort.Dispose();
                BGPort = null;
                disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~BGHandler()
        {
            Dispose();
        }


        /// <summary>
        /// Gets or sets the BGHandler TimeOut (default: 5 seconds).
        /// </summary>
        public int TimeOut
        {
            get { return BGPort.TimeOut; }
            set { BGPort.TimeOut = value; }
        }

        /// <summary>
        /// Private method for Firing a serialport timeout event
        /// </summary>
        private void FireTimeOut()
        {
            BGEventArgs e = new BGEventArgs();
            e.TypeOfEvent = BGEventType.TimeOut;
            _NewBG(this, e);
        }     
    }

}

