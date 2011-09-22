using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace carLogger
{
    public class Configuration
    {
        #region Properties
        public string Com_Port
        {
            get { return Properties.Settings.Default.com_port; }
            set
            {
                Properties.Settings.Default.com_port = value;
                Properties.Settings.Default.Save();
            }
        }
        public int Baud_Rate
        {
            get { return Properties.Settings.Default.baud_rate; }
            set
            {
                Properties.Settings.Default.baud_rate = value;
                Properties.Settings.Default.Save();
            }
        }
        public int Timeout
        {
            get { return Properties.Settings.Default.timeout; }
            set
            {
                Properties.Settings.Default.timeout = value;
                Properties.Settings.Default.Save();
            }
        }
        public int Interval
        {
            get { return Properties.Settings.Default.interval; }
            set
            {
                Properties.Settings.Default.interval = value;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        public Configuration()
        {
        }
    }
}