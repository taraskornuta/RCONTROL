namespace esp8266UDP_Client
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cBox_Joy_Select = new System.Windows.Forms.ComboBox();
            this.btn_Joy_Enable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBox_Debug = new System.Windows.Forms.CheckBox();
            this.txt_Debug_Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Debug_IP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.digitControl1 = new esp8266UDP_Client.DigitControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBox_Joy_Select
            // 
            this.cBox_Joy_Select.FormattingEnabled = true;
            this.cBox_Joy_Select.Location = new System.Drawing.Point(6, 19);
            this.cBox_Joy_Select.Name = "cBox_Joy_Select";
            this.cBox_Joy_Select.Size = new System.Drawing.Size(136, 21);
            this.cBox_Joy_Select.TabIndex = 0;
            // 
            // btn_Joy_Enable
            // 
            this.btn_Joy_Enable.Location = new System.Drawing.Point(151, 19);
            this.btn_Joy_Enable.Name = "btn_Joy_Enable";
            this.btn_Joy_Enable.Size = new System.Drawing.Size(75, 23);
            this.btn_Joy_Enable.TabIndex = 1;
            this.btn_Joy_Enable.Text = "Enable";
            this.btn_Joy_Enable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // chkBox_Debug
            // 
            this.chkBox_Debug.AutoSize = true;
            this.chkBox_Debug.Location = new System.Drawing.Point(6, 19);
            this.chkBox_Debug.Name = "chkBox_Debug";
            this.chkBox_Debug.Size = new System.Drawing.Size(58, 17);
            this.chkBox_Debug.TabIndex = 3;
            this.chkBox_Debug.Text = "Debug";
            this.chkBox_Debug.UseVisualStyleBackColor = true;
            this.chkBox_Debug.CheckedChanged += new System.EventHandler(this.chkBox_Debug_CheckedChanged);
            // 
            // txt_Debug_Port
            // 
            this.txt_Debug_Port.Enabled = false;
            this.txt_Debug_Port.Location = new System.Drawing.Point(6, 94);
            this.txt_Debug_Port.Name = "txt_Debug_Port";
            this.txt_Debug_Port.Size = new System.Drawing.Size(162, 20);
            this.txt_Debug_Port.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // txt_Debug_IP
            // 
            this.txt_Debug_IP.Enabled = false;
            this.txt_Debug_IP.Location = new System.Drawing.Point(6, 55);
            this.txt_Debug_IP.Name = "txt_Debug_IP";
            this.txt_Debug_IP.Size = new System.Drawing.Size(162, 20);
            this.txt_Debug_IP.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBox_Debug);
            this.groupBox1.Controls.Add(this.txt_Debug_Port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Debug_IP);
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 124);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debuging";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBox_Joy_Select);
            this.groupBox2.Controls.Add(this.btn_Joy_Enable);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 55);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Joystick";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.digitControl1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(250, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 366);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Channel Limits";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "CH1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Center";
            // 
            // digitControl1
            // 
            this.digitControl1.Location = new System.Drawing.Point(163, 36);
            this.digitControl1.MinOrMax = false;
            this.digitControl1.Name = "digitControl1";
            this.digitControl1.Size = new System.Drawing.Size(74, 23);
            this.digitControl1.TabIndex = 4;
            this.digitControl1.Value = "-100";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 396);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBox_Joy_Select;
        private System.Windows.Forms.Button btn_Joy_Enable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBox_Debug;
        private System.Windows.Forms.TextBox txt_Debug_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Debug_IP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DigitControl digitControl1;
    }
}