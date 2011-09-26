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

namespace carLogger
{
    public partial class Form1 : Form
    {
        #region Status Variables
        public int mTime;
        public int mFLrpm;
        public int mFRrpm;
        public int mRLrpm;
        public int mRRrpm;
        public double mCurrent;
        #endregion

        #region Class Variables
        public Configuration mConfig = new Configuration();
        public Comm mComm = new Comm();
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

            while (updateActive)
            {
                result = mComm.ReadLine();
                //ComLog(STATUS,result);
                if (result == "COMM ERROR" || result == "TIMEOUT")
                {
                    mCommError = true;
                    result = "0,0,0,0,0,0";
                }
                else
                {
                    mCommError = false;
                    status = result.Split(',');
                    if (status.Length == 6)
                    {
                        //Time
                        mTime = Int32.Parse(status[0]);

                        //Front Left
                        mFLrpm = Int32.Parse(status[1]);

                        //Front Right
                        mRLrpm = Int32.Parse(status[2]);

                        //Rear Left
                        mRLrpm = Int32.Parse(status[3]);

                        //Rear Right
                        mRRrpm = Int32.Parse(status[4]);

                        //Current
                        mCurrent = Double.Parse(status[5]);
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
            UpdateRPMs();
        }

        public void UpdateRPMs()
        {
            lblFLrpm.Text = mFLrpm.ToString();
            lblFRrpm.Text = mFRrpm.ToString();
            lblRLrpm.Text = mRLrpm.ToString();
            lblRRrpm.Text = mRRrpm.ToString();
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            updateActive = false;
            mTempThread.Join();
            //LogMessage("Goodbye!");
            Form1.ActiveForm.Close();
        }

        private void serialPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommSetup cs = new CommSetup();
            cs.Show();
        }
    }
}
