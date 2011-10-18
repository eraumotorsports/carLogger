using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace carLogger
{
    public partial class Form1 : Form
    {
        #region Status Variables
        public long mTime;
        public int mFLrpm;
        public int mFRrpm;
        public int mRLrpm;
        public int mRRrpm;
        public double mCurrent;
        #endregion

        #region Class Variables
        public Configuration mConfig = new Configuration();
        public TCPSocket mSocket = new TCPSocket();
        public Thread mTempThread;
        private StreamWriter mpLogStream;
        private FileStream mpLogFile;
        public bool updateActive = false;
        public bool mCommError = false;
        #endregion

        #region Form Initialization
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
                                 "Car Logger",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
            Thread updateThread = new Thread(new ThreadStart(UpdateStatus));
            updateActive = true;
            updateThread.Start();
        }
        #endregion

        #region Update Functions
        public void UpdateStatus()
        {
            string result = "";
            string[] status = new string[10];
            DateTime start;
            DateTime end;
            mTempThread = Thread.CurrentThread;
            int errorCount = 0;

            while (updateActive)
            {
                result = mSocket.ReadLine();
                result = result.Replace("\r", "");
                ComLog(result);
                if (result == "SOCKET ERROR" || result == "TIMEOUT")
                {
                    mCommError = true;
                    result = "0,0,0,0,0,0";
                    if (errorCount > 20)
                    {
                        mSocket.RefreshSettings();
                        errorCount = 0;
                        Thread.Sleep(10);
                    }
                    errorCount++;
                }
                else
                {
                    mCommError = false;
                    status = result.Split(',');
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
                    else
                    {
                        mCommError = true;
                    }
                }
                UpdateDisplay();
                // timer
                start = DateTime.Now;
                end = start.AddMilliseconds(mConfig.Interval);
                while (DateTime.Now < end)
                {
                    Application.DoEvents();
                }
            }
        }

        public void UpdateDisplay()
        {
            lblCommError.Visible = mCommError;
            lblCommPort.Text = mConfig.Hostname + ":" + mConfig.Port.ToString();
            UpdateRPMs();
            //ClearOldChartPoints();
        }

        public void UpdateRPMs()
        {
            lblFLrpm.Text = mFLrpm.ToString();
            lblFRrpm.Text = mFRrpm.ToString();
            lblRLrpm.Text = mRLrpm.ToString();
            lblRRrpm.Text = mRRrpm.ToString();
            lblCurrent.Text = mCurrent.ToString();
        }
        #endregion

        private void ExitProcedure()
        {
            updateActive = false;
            mTempThread.Join();
            //LogMessage("Goodbye!");
            Form1.ActiveForm.Close();
        }

        private void serialPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommSetup cs = new CommSetup();
            cs.Changed += new EventHandler(commChanged);
            cs.Show();
        }

        public void ComLog(string response)
        {
            mpLogStream.WriteLine("[" + System.DateTime.Now + "] " + response);
        }

        public void configurationChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show("Configuration Changed!");
        }

        public void commChanged(object sender, EventArgs e)
        {
            mSocket.RefreshSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitProcedure();
        }

    }
}
