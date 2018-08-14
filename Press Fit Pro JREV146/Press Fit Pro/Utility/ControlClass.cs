using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Press_Fit_Pro
{
    public class ControlClass
    {
        public struct ControlStatusStructure
        {
            public bool Home;
            public bool HandSwitch;

            public ControlStatusStructure(bool home, bool hand)
            {
                this.Home = home;
                this.HandSwitch = hand;
            }
        }

        public System.IO.Ports.SerialPort ComPort = new System.IO.Ports.SerialPort();

        public void Connect(string portName)
        {
            try
            {
                if (ComPort.IsOpen == true) ComPort.Close();
                ComPort.PortName = portName;
                ComPort.BaudRate = 9600;
                ComPort.DataBits = 8;
                ComPort.Parity = System.IO.Ports.Parity.None;
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

        int HOME_BIT = Convert.ToByte("00000001", 2);
        int HAND_BIT = Convert.ToByte("00000010", 2);

        public ControlStatusStructure ReadStatus()
        {
            try
            {
                
                //เพิ่มคำสั่งอ่าน สถานะสวิทช์ ที่นี่
                //

                int IncomingByte = Convert.ToByte("00000011", 2);//ตัวอย่างสมมติฐานสอง

                bool home_sw = (IncomingByte & HOME_BIT) == HOME_BIT;
                bool hand_sw = (IncomingByte & HAND_BIT) == HAND_BIT;
                return new ControlStatusStructure(hand_sw, hand_sw);//ตัวอย่างคืนค่า
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ReadHome()
        {
            try
            {

                //เพิ่มคำสั่งอ่าน สถานะสวิทช์ ที่นี่
                //

                int IncomingByte = Convert.ToByte("00000011", 2);//ตัวอย่างสมมติฐานสอง

                return (IncomingByte & HOME_BIT) == HOME_BIT;//ตัวอย่างคืนค่า
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ReadHand()
        {
            try
            {

                //เพิ่มคำสั่งอ่าน สถานะสวิทช์ ที่นี่
                //
                ComPort.DiscardInBuffer();
                ComPort.WriteLine("RD");
                string strIn = ComPort.ReadLine();
                return strIn;

                //int IncomingByte = Convert.ToByte("00000011", 2);//ตัวอย่างสมมติฐานสอง

                //return (IncomingByte & HAND_BIT) == HAND_BIT;//ตัวอย่างคืนค่า
            }
            catch (Exception ex)
            {
                Log.AppendText(ex.Message);
                //throw new Exception(ex.Message);
                return "ND";
            }
        }
    }
}
