using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace esp8266UDP_Client
{
    public partial class SettingsForm : Form
    {
        Properties.Settings ps = Properties.Settings.Default;

        private const string Debug_IP_Default = "127.0.0.1";  //Defaults debug IP and Port
        private const string Debug_Port_Default = "8000";

        public SettingsForm()
        {
            InitializeComponent();

        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            chkBox_Open_Consol.Checked = ps.Debug_Open_Console;
            chkBox_Joy_Enable.Checked = ps.Joy_Enable;
            chkBox_Debug.Checked = ps.Debug_Enable;
            txt_Debug_IP.Text = ps.Debug_IP;
            txt_Debug_Port.Text = ps.Debug_Port;
        }
        private void chkBox_Open_Consol_CheckedChanged(object sender, EventArgs e)
        {
            ps.Debug_Open_Console = chkBox_Open_Consol.Checked;
        }

        private void chkBox_Debug_CheckedChanged(object sender, EventArgs e)
        {
            ps.Debug_Enable = chkBox_Debug.Checked;
            if (chkBox_Debug.Checked)//Робить не активними поля вводу тексту
            {
                txt_Debug_IP.Enabled = true;
                txt_Debug_Port.Enabled = true;
            }
            else
            {
                txt_Debug_IP.Enabled = false;
                txt_Debug_Port.Enabled = false;
            }     
        }
        private void chkBox_Joy_Enable_CheckedChanged(object sender, EventArgs e)
        {
            ps.Joy_Enable = chkBox_Joy_Enable.Checked;
        }
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {          
            if (chkBox_Debug.Checked==true)
            {
                if (txt_Debug_IP.Text != "127.0.0.1")
                {
                    ps.Debug_IP = txt_Debug_IP.Text;
                    if (txt_Debug_IP.Text == "")
                    {
                        MessageBox.Show("Please fill Debug IP box","You forgot!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (txt_Debug_IP.Text == "127.0.0.1")
                {
                    ps.Debug_IP = Debug_IP_Default;                   
                }

                if (txt_Debug_Port.Text != "8000")
                {
                    ps.Debug_Port = txt_Debug_Port.Text;
                    if (txt_Debug_Port.Text == "")
                    {
                        MessageBox.Show("Please fill Debug Port box", "You forgot!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (txt_Debug_Port.Text == "8000")
                {
                    ps.Debug_Port = Debug_Port_Default;
                }
            }

            ps.Save();
        }

       






    }
}
