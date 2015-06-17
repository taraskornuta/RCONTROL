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
            this.SuspendLayout();
            // 
            // cBox_Joy_Select
            // 
            this.cBox_Joy_Select.FormattingEnabled = true;
            this.cBox_Joy_Select.Location = new System.Drawing.Point(13, 13);
            this.cBox_Joy_Select.Name = "cBox_Joy_Select";
            this.cBox_Joy_Select.Size = new System.Drawing.Size(241, 21);
            this.cBox_Joy_Select.TabIndex = 0;
            // 
            // btn_Joy_Enable
            // 
            this.btn_Joy_Enable.Location = new System.Drawing.Point(261, 10);
            this.btn_Joy_Enable.Name = "btn_Joy_Enable";
            this.btn_Joy_Enable.Size = new System.Drawing.Size(75, 23);
            this.btn_Joy_Enable.TabIndex = 1;
            this.btn_Joy_Enable.Text = "Enable";
            this.btn_Joy_Enable.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 261);
            this.Controls.Add(this.btn_Joy_Enable);
            this.Controls.Add(this.cBox_Joy_Select);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBox_Joy_Select;
        private System.Windows.Forms.Button btn_Joy_Enable;
    }
}