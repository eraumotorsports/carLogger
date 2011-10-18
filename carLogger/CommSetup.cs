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
            txtHostname.Text = mConfig.Hostname;
            txtPort.Text = mConfig.Port.ToString();
        }

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mConfig.Hostname = txtHostname.Text;
            mConfig.Port = Int32.Parse(txtPort.Text);
            OnChanged(EventArgs.Empty);
            this.Close();
        }
    }
}
