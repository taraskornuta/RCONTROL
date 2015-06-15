using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.Threading;
using SharpDX.DirectInput;




namespace esp8266UDP_Client
{
    public partial class Form1 : Form
    {

        private Thread JoystickThread = null;
        public int X, Y, Z, RotZ;
        private string ch1, ch2, ch3, ch4, ch5, ch6, ch7, ch8;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, System.EventArgs e)
        {
            
            JoystickThread = new Thread(new ThreadStart(this.joyStatus));
            JoystickThread.Start();
            //ThreadStart UdpThread = new ThreadStart(UdpReceive);
            //workReceive = new Thread(UdpThread);
            //workReceive.Start();
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            UdpClient udp = new UdpClient();
            // Указываем адрес отправки сообщения
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, 8000);

            byte[] message =
                Encoding.Default.GetBytes(
                         Convert.ToString(ch1 + ","
                                        + ch2 + ","
                                        + ch3 + ","
                                        + ch4 + ","
                                        + ch5 + ","
                                        + ch6 + ","
                                        + ch7 + ","
                                        + ch8));
                udp.Send(message, message.Length, ipendpoint);


            ch1 = Convert.ToString(tBar_CH1.Value);
            ch2 = Convert.ToString(tBar_CH2.Value);
            ch3 = Convert.ToString(tBar_CH3.Value);
            ch4 = Convert.ToString(tBar_CH4.Value);
            ch5 = Convert.ToString(tBar_CH5.Value);
            ch6 = Convert.ToString(tBar_CH6.Value);
            ch7 = Convert.ToString(tBar_CH7.Value);
            ch8 = Convert.ToString(tBar_CH8.Value);
            pBar_CH1.Value = tBar_CH1.Value;
            pBar_CH2.Value = tBar_CH2.Value;
            pBar_CH3.Value = tBar_CH3.Value;
            pBar_CH4.Value = tBar_CH4.Value;
            pBar_CH5.Value = tBar_CH5.Value;
            pBar_CH6.Value = tBar_CH6.Value;
            pBar_CH7.Value = tBar_CH7.Value;
            pBar_CH8.Value = tBar_CH8.Value;

            tBar_CH1.Value = Convert.ToInt16(1000 + (X * 3.92156862745099));
            tBar_CH2.Value = Convert.ToInt16(1000 + (Y * 3.92156862745099));  //Треба інвертувати
            tBar_CH3.Value = Convert.ToInt16(1000 + (Z * 3.92156862745099));
            tBar_CH4.Value = Convert.ToInt16(1000 + (RotZ * 3.92156862745099)); //Треба інвертувати
            udp.Close();

        }

        UdpClient udp = null;
        bool stopReceive = false;
        Thread workReceive = null;

        void UdpReceive()
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
                udp = new UdpClient(ep);
                while (true)
                {
                    IPEndPoint remote = null;
                    byte[] message = udp.Receive(ref remote);
                    ShowMessage(Encoding.Default.GetString(message));
                    if (stopReceive == true) break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (udp != null) udp.Close();
            }


        }
        //Приймає значення із паралельного потоку
        delegate void SetTextCallback(string message);
        void ShowMessage(string message)
        {
            if (this.label9.InvokeRequired)
            {
                SetTextCallback dt = new SetTextCallback(ShowMessage);
                this.Invoke(dt, new object[] { message });
            }
            else
            {
                this.label9.Text = message;
            }
        }

        void StopReceive()
        {
            stopReceive = true;
            if (udp != null) udp.Close();
            if (workReceive != null) workReceive.Join();
        }
        private void btn_Close_Click(object sender, System.EventArgs e)
        {
            
            timer1.Stop();
            StopReceive();

        }
        
        public void joyStatus()
        {
            var directInput = new DirectInput();

            // Find a Joystick Guid
            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad,
                DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick,
                    DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                MessageBox.Show("");


            }

           
            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            //Query all suported ForceFeedback effects
            //var allEffects = joystick.GetEffects();
            //foreach (var effectInfo in allEffects)
            //    Console.WriteLine("Effect available {0}", effectInfo.Name);

            //Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            //Poll events from joystick
            while (true)
            {
                joystick.Poll();
                var data = joystick.GetBufferedData();
                //foreach (var state in datas)
                //    Console.WriteLine(state);
                foreach (var state in data)
                {
                    if (state.Offset == JoystickOffset.X)
                    {
                        X = (state.Value/256);
                    }
                    else if (state.Offset == JoystickOffset.Y)
                    {
                        Y = (state.Value/256);
                    }
                    else if (state.Offset == JoystickOffset.Z)
                    {
                        Z = (state.Value/256);
                    }
                    else if (state.Offset == JoystickOffset.RotationZ)
                    {
                        RotZ = (state.Value/256);
                    }

                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            StopReceive();
        }
    }
}
