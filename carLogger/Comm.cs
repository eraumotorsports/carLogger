using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace carLogger
{
    public class Comm
    {
        Configuration _config = new Configuration();
        private SerialPort _serialPort = new SerialPort();

        public Comm()
        {
            try
            {

                _serialPort.PortName = _config.Com_Port;
                _serialPort.BaudRate = _config.Baud_Rate;
                _serialPort.ReadTimeout = _config.Timeout;
                _serialPort.Open();
            }
            catch
            {
                //MessageBox.Show("Could not open " + _config.Com_Port.ToString(), "Comm Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region Member Functions

        // Refresh Port Settings
        public void RefreshSettings()
        {
            _serialPort.Close();
            _serialPort.PortName = _config.Com_Port;
            _serialPort.BaudRate = _config.Baud_Rate;
            _serialPort.ReadTimeout = _config.Timeout;
            _serialPort.Open();
        }
        // Sends a command and returns the response
        public string SendCommand(string command)
        {
            try
            {
                if (!_serialPort.IsOpen)
                    _serialPort.Open();
                _serialPort.WriteLine(command);
                return _serialPort.ReadLine();
            }
            catch (TimeoutException)
            {
                return "TIMEOUT";
            }
            catch (System.IO.IOException)
            {
                return "CANT OPEN " + _serialPort.PortName.ToString();
            }
            catch
            {
                return "COMM ERROR";
            }
        }

        // Sends a string
        public bool Send(string command)
        {
            try
            {
                if (!_serialPort.IsOpen)
                    _serialPort.Open();
                _serialPort.WriteLine(command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Read a line
        public string ReadLine()
        {
            try
            {
                if (!_serialPort.IsOpen)
                    _serialPort.Open();
                return _serialPort.ReadLine();
            }
            catch (TimeoutException)
            {
                return "TIMEOUT";
            }
            catch (System.IO.IOException)
            {
                return "CANT OPEN " + _serialPort.PortName.ToString();
            }
            catch
            {
                return "COMM ERROR";
            }
        }

        // Open Port
        public void Open()
        {
            _serialPort.Open();
        }

        // Close Port
        public void Close()
        {
            _serialPort.Close();
        }

        #endregion
    }
}