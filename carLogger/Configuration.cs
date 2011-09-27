using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.ComponentModel;

namespace carLogger
{
    public class Configuration : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #region Properties
        public string Com_Port
        {
            get { return Properties.Settings.Default.com_port; }
            set
            {
                Properties.Settings.Default.com_port = value;
                Properties.Settings.Default.Save();
                NotifyPropertyChanged("CommPort");
            }
        }
        public int Baud_Rate
        {
            get { return Properties.Settings.Default.baud_rate; }
            set
            {
                Properties.Settings.Default.baud_rate = value;
                Properties.Settings.Default.Save();
                NotifyPropertyChanged("BaudRate");
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