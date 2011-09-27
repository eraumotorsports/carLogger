using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace carLogger
{
    public partial class CommSetup : Form
    {
        private Configuration mConfig;
        public event EventHandler Changed;

        public CommSetup()
        {
            InitializeComponent();
        }

        private void CommSetup_Load(object sender, EventArgs e)
        {
            mConfig = new Configuration();
            cmbPorts.Text = mConfig.Com_Port;

            foreach (string s in SerialPort.GetPortNames())
            {
                cmbPorts.Items.Add(s);
            }
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbPorts.Items.Contains(cmbPorts.Text))
            {
                mConfig.Com_Port = cmbPorts.Text;
                OnChanged(EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("The port entered is not valid. Reverting port settings.", "Invlaid Port");
                this.Close();
            }
        }
    }
}
