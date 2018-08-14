using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Press_Fit_Pro
{
    public class LoadCellIndicatorClass
    {
        public System.IO.Ports.SerialPort ComPort = new System.IO.Ports.SerialPort();

        public void Connect(string portName)
        {
            try
            {
                if (ComPort.IsOpen == true) ComPort.Close();
                ComPort.PortName = "Com4";
                ComPort.BaudRate = 9600;
                ComPort.DataBits = 7;
                ComPort.Parity = System.IO.Ports.Parity.Even;
                ComPort.StopBits = System.IO.Ports.StopBits.One;
                ComPort.Handshake = System.IO.Ports.Handshake.None;
                ComPort.Encoding = System.Text.ASCIIEncoding.Default;
                ComPort.NewLine = "\r\n";
                ComPort.ReadTimeout = 1000;
                ComPort.Open();
            }
            catch
            {
                throw;
            }
        }

        public string ReadString()
        {
            try
            {
                ComPort.DiscardInBuffer();
                return ComPort.ReadLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public double ReadDouble()
        {
            string strIncoming;
            try
            {
                ComPort.DiscardInBuffer();
                strIncoming = ComPort.ReadLine();
                //return double.Parse(strIncoming.Substring(1, strIncoming.Length - 2));
                return double.Parse(strIncoming.Substring(1, strIncoming.Length - 1).Trim());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
