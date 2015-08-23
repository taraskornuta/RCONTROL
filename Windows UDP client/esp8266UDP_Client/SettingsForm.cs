using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCONTROL
{
    public partial class SettingsForm : Form
    {
        private const string Debug_IP_Default = "127.0.0.1";  //Defaults debug IP and Port
        private const string Debug_Port_Default = "8000";

        public SettingsForm()
        {
            InitializeComponent();
            Settings.Load();

        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Settings.Read();

            chkBox_Open_Consol.Checked = Settings.Debug_Open_Console;
            chkBox_Joy_Enable.Checked = Settings.Joy_Enable;
            chkBox_Debug.Checked = Settings.Debug_Enable;
            txt_Debug_IP.Text = Settings.Debug_IP;
            txt_Debug_Port.Text = Settings.Debug_Port;
            cBox_Joy_Select.Text = Settings.Joy_Name;
        }
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {          
            if (chkBox_Debug.Checked==true)
            {
                if (txt_Debug_IP.Text != "127.0.0.1")
                {
                    Settings.Debug_IP = txt_Debug_IP.Text;
                    if (txt_Debug_IP.Text == "")
                    {
                        MessageBox.Show("Please fill Debug IP box","You forgot!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (txt_Debug_IP.Text == "127.0.0.1")
                {
                    Settings.Debug_IP = Debug_IP_Default;                   
                }

                if (txt_Debug_Port.Text != "8000")
                {
                    Settings.Debug_Port = txt_Debug_Port.Text;
                    if (txt_Debug_Port.Text == "")
                    {
                        MessageBox.Show("Please fill Debug Port box", "You forgot!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (txt_Debug_Port.Text == "8000")
                {
                    Settings.Debug_Port = Debug_Port_Default;
                }
            }

            if (chkBox_Joy_Enable.Checked == true)
            {
                Settings.Joy_Name = cBox_Joy_Select.Text;
            }

            Settings.Save();
            //MessageBox.Show("You mast restart RCONTROL client, to confirm settings!, MessageBoxButtons.OK, MessageBoxIcon.Warning");
        }

        private void chkBox_Open_Consol_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Debug_Open_Console = chkBox_Open_Consol.Checked;
        }
        private void chkBox_Debug_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Debug_Enable = chkBox_Debug.Checked;
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
            Settings.Joy_Enable = chkBox_Joy_Enable.Checked;
            cBox_Joy_Select.Enabled ^= true;
            btn_Joy_Refresh.Enabled ^= true;
        }

        private void btn_Joy_Refresh_Click(object sender, EventArgs e)
        {
            Joystick joy = new Joystick(Handle);          
            cBox_Joy_Select.Items.Add(joy.FindJoysticks());
            
        }
        
    }
}
