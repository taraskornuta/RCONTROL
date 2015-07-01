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
using System.Runtime.InteropServices;

namespace RCONTROL
{
    public partial class MainForm : Form
    {
        Properties.Settings ps = Properties.Settings.Default;
        private Thread JoystickThread = null;
        public int X, Y, Z, RotZ;
        private string ch1, ch2, ch3, ch4, ch5, ch6, ch7, ch8;

        public MainForm()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", SetLastError = true)] //Enabling debuging console
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (ps.Debug_Open_Console==true)
            {
                AllocConsole(); //Enabling debuging console
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            StopReceive();
        }

        private void btn_Open_Click(object sender, System.EventArgs e)
        {
            if (ps.Joy_Enable==true)
            {
                JoystickThread = new Thread(new ThreadStart(this.JoyStatus));
                JoystickThread.Start();
            }

            //ThreadStart UdpThread = new ThreadStart(UdpReceive);
            //workReceive = new Thread(UdpThread);
            //workReceive.Start();
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            UdpClient udp = new UdpClient();
            string defaultIP = "192.168.4.1";
            int defaultPort = 8000;

            if (ps.Debug_Enable == true)
            {
                defaultIP = ps.Debug_IP;
                defaultPort = Convert.ToInt16(ps.Debug_Port);
            }

            // Указываем адрес отправки сообщения
            IPAddress ipaddress = IPAddress.Parse(defaultIP);
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, defaultPort);

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

            if (ps.Joy_Enable == true)
            {
                tBar_CH1.Value = Convert.ToInt16(1000 + (X * 3.92156862745099));
                tBar_CH2.Value = Convert.ToInt16(1000 + (Y * 3.92156862745099));
                tBar_CH3.Value = Convert.ToInt16(1000 + (Z * 3.92156862745099));
                tBar_CH4.Value = Convert.ToInt16(1000 + (RotZ * 3.92156862745099)); 
            }

            udp.Close();

            


        }

        UdpClient udp = null;
       // bool stopReceive = false;
        Thread workReceive = null;

        //void UdpReceive()
        //{
        //    try
        //    {
        //        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.4.1"), 8001);
        //        udp = new UdpClient(ep);
        //        while (true)
        //        {
        //            IPEndPoint remote = null;
        //            byte[] message = udp.Receive(ref remote);
        //            ShowMessage(Encoding.Default.GetString(message));
        //            if (stopReceive == true) break;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        if (udp != null) udp.Close();
        //    }


        //}
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
            //stopReceive = true;
            if (udp != null) udp.Close();
            if (workReceive != null) workReceive.Join();
        }
        private void btn_Close_Click(object sender, System.EventArgs e)
        {
            
            timer1.Stop();
            StopReceive();

        }

        public int Revert(int data)
        {
            int i = 255 - data;
            return i;
        }
        public void JoyStatus()
        {
            if (ps.Joy_Enable == true)
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
                    MessageBox.Show("Joystick not found");
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
                    foreach (var state in data)
                        Console.WriteLine(state);

                    foreach (var state in data)
                    {
                        if (state.Offset == JoystickOffset.X)
                        {
                            X = (state.Value/256);
                        }
                        else if (state.Offset == JoystickOffset.Y)
                        {
                            Y = Revert(state.Value/256);
                        }
                        else if (state.Offset == JoystickOffset.Z)
                        {
                            Z = (state.Value/256);
                        }
                        else if (state.Offset == JoystickOffset.RotationZ)
                        {
                            RotZ = Revert(state.Value/256);
                        }
                    }
                }
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(); // Створює форму Settings
            settings.Show(); 
        }

        
    }
}

