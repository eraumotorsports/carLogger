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
        private SerialPort mSerial;

        public CommSetup()
        {
            InitializeComponent();
        }

        private void CommSetup_Load(object sender, EventArgs e)
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                cmbPorts.Items.Add(s);
            }
        }
    }
}
