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
        public string Hostname
        {
            get { return Properties.Settings.Default.hostname; }
            set
            {
                Properties.Settings.Default.hostname = value;
                Properties.Settings.Default.Save();
                NotifyPropertyChanged("Hostname");
            }
        }
        public int Port
        {
            get { return Properties.Settings.Default.port; }
            set
            {
                Properties.Settings.Default.port = value;
                Properties.Settings.Default.Save();
                NotifyPropertyChanged("Port");
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