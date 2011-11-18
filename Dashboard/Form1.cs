using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Ribbon;
using System.IO;
using System.Threading;

namespace Dashboard
{
    public partial class Form1 : C1RibbonForm
    {
        public Configuration mConfig = new Configuration();
        private StreamWriter mpLogStream;
        private FileStream mpLogFile;
        private Thread mpUdpThread, mpUpdateThread;
        private BroadcastListener mpBl;
        private bool mpUpdateActive;

        #region Status Variables
        public long mTime;
        public int mFLrpm;
        public int mFRrpm;
        public int mRLrpm;
        public int mRRrpm;
        public double mCurrent;
        #endregion

        public Form1()
        {
            InitializeComponent();
            try
            {
                mpLogFile = File.Open("log.txt", FileMode.Append, FileAccess.Write);
                mpLogStream = new StreamWriter(mpLogFile);
                mpLogStream.AutoFlush = true;
                mConfig.PropertyChanged += new PropertyChangedEventHandler(configurationChanged);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Unable to open log file",
                                 "Dashboard",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switch (c1Ribbon1.VisualStyle)
            {
                case VisualStyle.Office2007Blue:
                    blue2007Button.Pressed = true;
                    break;
                case VisualStyle.Office2007Silver:
                    silver2007Button.Pressed = true;
                    break;
                case VisualStyle.Office2007Black:
                    black2007Button.Pressed = true;
                    break;
                case VisualStyle.Office2010Blue:
                    blue2010Button.Pressed = true;
                    break;
                case VisualStyle.Office2010Silver:
                    silver2010Button.Pressed = true;
                    break;
                case VisualStyle.Office2010Black:
                    black2010Button.Pressed = true;
                    break;
                case VisualStyle.Windows7:
                    windows7Button.Pressed = true;
                    break;
            }

            Form1.CheckForIllegalCrossThreadCalls = false;
            mpUdpThread = new Thread(new ThreadStart(UdpThread));
            mpUdpThread.Name = "UdpThread";
            mpUdpThread.Start();

            mpUpdateThread = new Thread(new ThreadStart(UpdateStatus));
            mpUpdateActive = true;
            mpUpdateThread.Name = "GUI Update";
            mpUpdateThread.Start();
        }

        private void OnClosing()
        {
            mpBl.StopListener();
            mpUdpThread.Abort();

            mpUpdateActive = false;
            mpUpdateThread.Join();
        }

        private void UdpThread()
        {
           mpBl = new BroadcastListener(12345);
           mpBl.Received += new EventHandler<UdpEventArgs>(ReceivedEventHandler);
           mpBl.StartListener();
        }

        #region Update Functions
        public void UpdateStatus()
        {      
            while (mpUpdateActive)
            {
                UpdateDisplay();
            }
        }

        public void UpdateDisplay()
        {
            UpdateRPMs();
            UpdateGauges();
            //ClearOldChartPoints();
        }

        public void UpdateRPMs()
        {
            lblFLrpm.Text = mFLrpm.ToString();
            lblFRrpm.Text = mFRrpm.ToString();
            lblRLrpm.Text = mRLrpm.ToString();
            lblRRrpm.Text = mRRrpm.ToString();
            //lblCurrent.Text = mCurrent.ToString();
        }

        public void UpdateGauges()
        {
            speedometer.Value = mFLrpm / 4;
            tachometer.Value = mFRrpm / 4;
        }
        #endregion

        private void visualStyle_PressedButtonChanged(object sender, EventArgs e)
        {
            if (blue2007Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2007Blue;
            else if (silver2007Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2007Silver;
            else if (black2007Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2007Black;
            else if (blue2010Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2010Blue;
            else if (silver2010Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2010Silver;
            else if (black2010Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Office2010Black;
            else if (windows7Button.Pressed)
                c1Ribbon1.VisualStyle = VisualStyle.Windows7;
        }

        void ReceivedEventHandler(object sender, UdpEventArgs e)
        {
            Console.WriteLine(e.message);
            string[] status = new string[10];
            status = e.message.Split(',');
            if (status.Length == 6)
            {
                //Time
                mTime = Int64.Parse(status[0]);

                //Front Left
                mFLrpm = Int32.Parse(status[1]);

                //Front Right
                mFRrpm = Int32.Parse(status[2]);

                //Rear Left
                mRLrpm = Int32.Parse(status[3]);

                //Rear Right
                mRRrpm = Int32.Parse(status[4]);

                //Current
                try
                {
                    mCurrent = Double.Parse(status[5]);
                }
                catch (Exception ex)
                {
                    mCurrent = 0;
                }
            }
        }

        public void configurationChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show("Configuration Changed!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClosing();
        }
    }
}
