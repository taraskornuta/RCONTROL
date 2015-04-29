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
        private Thread tread = null;
        public int X, Y, Z, RotZ;
        private UdpClient udp = new UdpClient();
        private string ch1, ch2, ch3, ch4, ch5, ch6, ch7, ch8;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, System.EventArgs e)
        {
            this.tread = new Thread(new ThreadStart(this.relayStatus));
            this.tread.Start();
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {

            // Указываем адрес отправки сообщения
            IPAddress ipaddress = IPAddress.Parse("192.168.4.1");
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, 8000);

            byte[] message =
                Encoding.Default.GetBytes(
                    Convert.ToString(ch1 + "," + ch2 + "," + ch3 + "," + ch4 + "," + ch5 + "," + ch6 + "," + ch7 + "," +
                                     ch8));
            try
            {
                int sended = udp.Send(message, message.Length, ipendpoint);
            }
            catch (Exception)
            {

                udp.Close();
            }

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


        }

        private void btn_Close_Click(object sender, System.EventArgs e)
        {
            udp.Close();
            timer1.Stop();
        }

        private void btn_Send_Click(object sender, System.EventArgs e)
        {

            timer1.Start();
        }

        public void relayStatus()
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
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            Console.WriteLine("Found Joystick/Gamepad with GUID: {0}", joystickGuid);

            //Query all suported ForceFeedback effects
            var allEffects = joystick.GetEffects();
            foreach (var effectInfo in allEffects)
                Console.WriteLine("Effect available {0}", effectInfo.Name);

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
    }
}
