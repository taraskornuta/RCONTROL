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
        public SettingsForm()
        {
            InitializeComponent();

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

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {          
            if (chkBox_Debug.Checked==true)
            {
                ps.Debug_IP = txt_Debug_IP.Text;
                ps.Debug_Port = txt_Debug_Port.Text;
            }
            ps.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            chkBox_Debug.Checked = ps.Debug_Enable;
            txt_Debug_IP.Text = ps.Debug_IP;
            txt_Debug_Port.Text = ps.Debug_Port;
        }
    }
}
