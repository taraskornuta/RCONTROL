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
using System.Runtime.InteropServices;

namespace RCONTROL
{
    public partial class MainForm : Form
    {
        #region UserParam
        string defaultIP = "192.168.4.1";
        int defaultPort = 8000;

        private Joystick joystick;
        private bool[] joystickButtons;

        private int X, Y, Z, RotZ;
        private string ch1, ch2, ch3, ch4, ch5, ch6, ch7, ch8;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            Settings.Load();
            Settings.Read();

            if (Settings.Joy_Enable == true)
            {
                joystick = new Joystick(this.Handle);
                connectToJoystick(joystick);
            }            
        }

        [DllImport("kernel32.dll", SetLastError = true)] //Enabling debuging console
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void MainForm_Load(object sender, EventArgs e)
        {           
            if (Settings.Debug_Open_Console==true)
            {
                AllocConsole(); //Enabling debuging console
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UDPtimer.Stop();
        }

        private void connectToJoystick(Joystick joystick)
        {
            while (true)
            {
                string joyName = joystick.FindJoysticks();
                if (joyName != null)
                {
                    if (joystick.AcquireJoystick(joyName))
                    {
                        enableTimer();
                        break;
                    }
                }
                else if (joyName == null)
                {
                    MessageBox.Show("Connect Joystick and restart programm", " Joystick NOT connected!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
        }

        private void enableTimer()  //Method to enabling timer for joystick
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ThreadStart(delegate()
                {
                    joystickTimer.Enabled = true;
                }));
            }
            else
                joystickTimer.Enabled = true;
        }

        private void joystickTimer_Tick(object sender, EventArgs e)
        {
             try
            {
                joystick.UpdateStatus();
                joystickButtons = joystick.buttons;

                    X = joystick.Axis_X;
                    Y = Revert(joystick.Axis_Y);
                    Z = joystick.Axis_Z;
                    RotZ = Revert(joystick.Axis_RotZ);

                    Console.WriteLine("Axis X:" + X + 
                                    "\nAxis Y:" + Y + 
                                    "\nAxis Z:" + Z + 
                                    "\nAxis RotZ:" + RotZ);

               

                for (int i = 0; i < joystickButtons.Length; i++)
                {
                    if(joystickButtons[i] == true)
                    {
                        label9.Text = "Button " + i + " Pressed";
                        Console.WriteLine("Button " + i + " Pressed");
                        
                    }
                }
            }
            catch
            {
                joystickTimer.Enabled = false;
                connectToJoystick(joystick);
            }
        }

        public int Revert(int data) //Revert joystick axis direction
        {
            int i = 65535 - data;
            return i;
        } 
       
        private void UDPtimer_Tick(object sender, System.EventArgs e)
        {
            UdpClient udp = new UdpClient();

            if (Settings.Debug_Enable == true)
            {
                defaultIP = Settings.Debug_IP;
                defaultPort = Convert.ToInt16(Settings.Debug_Port);
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

            if (Settings.Joy_Enable == true)
            {
                tBar_CH1.Value = Convert.ToInt16(1000 + (X * 0.0152590218966964));
                tBar_CH2.Value = Convert.ToInt16(1000 + (Y * 0.0152590218966964));
                tBar_CH3.Value = Convert.ToInt16(1000 + (Z * 0.0152590218966964));
                tBar_CH4.Value = Convert.ToInt16(1000 + (RotZ * 0.0152590218966964)); 
            }

            udp.Close();
        }

        private void btn_Open_Click(object sender, System.EventArgs e)
        {
            UDPtimer.Start();
        }

        private void btn_Close_Click(object sender, System.EventArgs e)
        {           
            UDPtimer.Stop();
        }
      
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(); // Створює форму Settings
            settings.Show(); 
        }
             
    }
}

