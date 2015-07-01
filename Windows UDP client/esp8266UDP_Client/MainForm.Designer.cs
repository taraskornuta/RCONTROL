namespace RCONTROL
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tBar_CH5 = new System.Windows.Forms.TrackBar();
            this.tBar_CH6 = new System.Windows.Forms.TrackBar();
            this.tBar_CH7 = new System.Windows.Forms.TrackBar();
            this.tBar_CH8 = new System.Windows.Forms.TrackBar();
            this.tBar_CH1 = new System.Windows.Forms.TrackBar();
            this.tBar_CH2 = new System.Windows.Forms.TrackBar();
            this.tBar_CH4 = new System.Windows.Forms.TrackBar();
            this.tBar_CH3 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.pBar_CH8 = new ProgressBars.Basic.BasicProgressBar();
            this.pBar_CH7 = new ProgressBars.Basic.BasicProgressBar();
            this.pBar_CH6 = new ProgressBars.Basic.BasicProgressBar();
            this.pBar_CH5 = new ProgressBars.Basic.BasicProgressBar();
            this.pBar_CH3 = new ProgressBars.Basic.BasicProgressBar();
            this.pBar_CH1 = new ProgressBars.Basic.BasicProgressBar();
            this.pBar_CH2 = new ProgressBars.Basic.BasicProgressBar();
            this.pBar_CH4 = new ProgressBars.Basic.BasicProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH3)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(489, 13);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 0;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(489, 42);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tBar_CH5
            // 
            this.tBar_CH5.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH5.Location = new System.Drawing.Point(8, 27);
            this.tBar_CH5.Maximum = 2000;
            this.tBar_CH5.Minimum = 1000;
            this.tBar_CH5.Name = "tBar_CH5";
            this.tBar_CH5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH5.Size = new System.Drawing.Size(104, 45);
            this.tBar_CH5.TabIndex = 4;
            this.tBar_CH5.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH5.Value = 1000;
            // 
            // tBar_CH6
            // 
            this.tBar_CH6.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH6.Location = new System.Drawing.Point(118, 27);
            this.tBar_CH6.Maximum = 2000;
            this.tBar_CH6.Minimum = 1000;
            this.tBar_CH6.Name = "tBar_CH6";
            this.tBar_CH6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH6.Size = new System.Drawing.Size(104, 45);
            this.tBar_CH6.TabIndex = 5;
            this.tBar_CH6.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH6.Value = 1000;
            // 
            // tBar_CH7
            // 
            this.tBar_CH7.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH7.Location = new System.Drawing.Point(228, 27);
            this.tBar_CH7.Maximum = 2000;
            this.tBar_CH7.Minimum = 1000;
            this.tBar_CH7.Name = "tBar_CH7";
            this.tBar_CH7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH7.Size = new System.Drawing.Size(104, 45);
            this.tBar_CH7.TabIndex = 6;
            this.tBar_CH7.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH7.Value = 1000;
            // 
            // tBar_CH8
            // 
            this.tBar_CH8.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH8.Location = new System.Drawing.Point(338, 27);
            this.tBar_CH8.Maximum = 2000;
            this.tBar_CH8.Minimum = 1000;
            this.tBar_CH8.Name = "tBar_CH8";
            this.tBar_CH8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH8.Size = new System.Drawing.Size(104, 45);
            this.tBar_CH8.TabIndex = 7;
            this.tBar_CH8.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH8.Value = 1000;
            // 
            // tBar_CH1
            // 
            this.tBar_CH1.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH1.Location = new System.Drawing.Point(7, 272);
            this.tBar_CH1.Maximum = 2000;
            this.tBar_CH1.Minimum = 1000;
            this.tBar_CH1.Name = "tBar_CH1";
            this.tBar_CH1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH1.Size = new System.Drawing.Size(168, 45);
            this.tBar_CH1.TabIndex = 8;
            this.tBar_CH1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH1.Value = 1000;
            // 
            // tBar_CH2
            // 
            this.tBar_CH2.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH2.Location = new System.Drawing.Point(67, 122);
            this.tBar_CH2.Maximum = 2000;
            this.tBar_CH2.Minimum = 1000;
            this.tBar_CH2.Name = "tBar_CH2";
            this.tBar_CH2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tBar_CH2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH2.Size = new System.Drawing.Size(45, 144);
            this.tBar_CH2.TabIndex = 10;
            this.tBar_CH2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH2.Value = 1000;
            // 
            // tBar_CH4
            // 
            this.tBar_CH4.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH4.Location = new System.Drawing.Point(338, 122);
            this.tBar_CH4.Maximum = 2000;
            this.tBar_CH4.Minimum = 1000;
            this.tBar_CH4.Name = "tBar_CH4";
            this.tBar_CH4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tBar_CH4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH4.Size = new System.Drawing.Size(45, 144);
            this.tBar_CH4.TabIndex = 12;
            this.tBar_CH4.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH4.Value = 1000;
            // 
            // tBar_CH3
            // 
            this.tBar_CH3.BackColor = System.Drawing.SystemColors.Control;
            this.tBar_CH3.Location = new System.Drawing.Point(278, 272);
            this.tBar_CH3.Maximum = 2000;
            this.tBar_CH3.Minimum = 1000;
            this.tBar_CH3.Name = "tBar_CH3";
            this.tBar_CH3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tBar_CH3.Size = new System.Drawing.Size(168, 45);
            this.tBar_CH3.TabIndex = 11;
            this.tBar_CH3.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tBar_CH3.Value = 1000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "CH1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "CH3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "CH2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "CH4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "CH5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "CH6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "CH7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "CH8";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(506, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "label9";
            // 
            // btn_Settings
            // 
            this.btn_Settings.Location = new System.Drawing.Point(489, 309);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(75, 23);
            this.btn_Settings.TabIndex = 38;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // pBar_CH8
            // 
            this.pBar_CH8.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH8.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH8.Font = new System.Drawing.Font("Consolas", 9F);
            this.pBar_CH8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH8.Location = new System.Drawing.Point(351, 62);
            this.pBar_CH8.Maximum = 2000;
            this.pBar_CH8.Minimum = 1000;
            this.pBar_CH8.Name = "pBar_CH8";
            this.pBar_CH8.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pBar_CH8.Size = new System.Drawing.Size(79, 10);
            this.pBar_CH8.TabIndex = 35;
            this.pBar_CH8.Text = "basicProgressBar8";
            // 
            // pBar_CH7
            // 
            this.pBar_CH7.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH7.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH7.Font = new System.Drawing.Font("Consolas", 9F);
            this.pBar_CH7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH7.Location = new System.Drawing.Point(241, 62);
            this.pBar_CH7.Maximum = 2000;
            this.pBar_CH7.Minimum = 1000;
            this.pBar_CH7.Name = "pBar_CH7";
            this.pBar_CH7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pBar_CH7.Size = new System.Drawing.Size(79, 10);
            this.pBar_CH7.TabIndex = 34;
            this.pBar_CH7.Text = "basicProgressBar7";
            // 
            // pBar_CH6
            // 
            this.pBar_CH6.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH6.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH6.Font = new System.Drawing.Font("Consolas", 9F);
            this.pBar_CH6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH6.Location = new System.Drawing.Point(131, 62);
            this.pBar_CH6.Maximum = 2000;
            this.pBar_CH6.Minimum = 1000;
            this.pBar_CH6.Name = "pBar_CH6";
            this.pBar_CH6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pBar_CH6.Size = new System.Drawing.Size(79, 10);
            this.pBar_CH6.TabIndex = 33;
            this.pBar_CH6.Text = "basicProgressBar6";
            // 
            // pBar_CH5
            // 
            this.pBar_CH5.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH5.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH5.Font = new System.Drawing.Font("Consolas", 9F);
            this.pBar_CH5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH5.Location = new System.Drawing.Point(21, 62);
            this.pBar_CH5.Maximum = 2000;
            this.pBar_CH5.Minimum = 1000;
            this.pBar_CH5.Name = "pBar_CH5";
            this.pBar_CH5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pBar_CH5.Size = new System.Drawing.Size(79, 10);
            this.pBar_CH5.TabIndex = 32;
            this.pBar_CH5.Text = "basicProgressBar5";
            // 
            // pBar_CH3
            // 
            this.pBar_CH3.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH3.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH3.Font = new System.Drawing.Font("Consolas", 9F);
            this.pBar_CH3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH3.Location = new System.Drawing.Point(291, 307);
            this.pBar_CH3.Maximum = 2000;
            this.pBar_CH3.Minimum = 1000;
            this.pBar_CH3.Name = "pBar_CH3";
            this.pBar_CH3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pBar_CH3.Size = new System.Drawing.Size(143, 10);
            this.pBar_CH3.TabIndex = 31;
            this.pBar_CH3.Text = "basicProgressBar4";
            // 
            // pBar_CH1
            // 
            this.pBar_CH1.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH1.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pBar_CH1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH1.Location = new System.Drawing.Point(20, 307);
            this.pBar_CH1.Maximum = 2000;
            this.pBar_CH1.Minimum = 1000;
            this.pBar_CH1.Name = "pBar_CH1";
            this.pBar_CH1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.pBar_CH1.Size = new System.Drawing.Size(143, 10);
            this.pBar_CH1.TabIndex = 30;
            this.pBar_CH1.Text = "basicProgressBar3";
            // 
            // pBar_CH2
            // 
            this.pBar_CH2.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH2.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pBar_CH2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH2.Location = new System.Drawing.Point(102, 134);
            this.pBar_CH2.Maximum = 2000;
            this.pBar_CH2.Minimum = 1000;
            this.pBar_CH2.Name = "pBar_CH2";
            this.pBar_CH2.Size = new System.Drawing.Size(25, 119);
            this.pBar_CH2.TabIndex = 29;
            this.pBar_CH2.Text = "basicProgressBar2";
            // 
            // pBar_CH4
            // 
            this.pBar_CH4.BackColor = System.Drawing.SystemColors.Control;
            this.pBar_CH4.BorderColor = System.Drawing.Color.DarkGray;
            this.pBar_CH4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pBar_CH4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.pBar_CH4.Location = new System.Drawing.Point(376, 134);
            this.pBar_CH4.Maximum = 2000;
            this.pBar_CH4.Minimum = 1000;
            this.pBar_CH4.Name = "pBar_CH4";
            this.pBar_CH4.Size = new System.Drawing.Size(25, 119);
            this.pBar_CH4.TabIndex = 28;
            this.pBar_CH4.Text = "basicProgressBar1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 344);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pBar_CH8);
            this.Controls.Add(this.pBar_CH7);
            this.Controls.Add(this.pBar_CH6);
            this.Controls.Add(this.pBar_CH5);
            this.Controls.Add(this.pBar_CH3);
            this.Controls.Add(this.pBar_CH1);
            this.Controls.Add(this.pBar_CH2);
            this.Controls.Add(this.pBar_CH4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBar_CH4);
            this.Controls.Add(this.tBar_CH3);
            this.Controls.Add(this.tBar_CH2);
            this.Controls.Add(this.tBar_CH1);
            this.Controls.Add(this.tBar_CH8);
            this.Controls.Add(this.tBar_CH7);
            this.Controls.Add(this.tBar_CH6);
            this.Controls.Add(this.tBar_CH5);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Open);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RCONTROL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_CH3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TrackBar tBar_CH5;
        private System.Windows.Forms.TrackBar tBar_CH6;
        private System.Windows.Forms.TrackBar tBar_CH7;
        private System.Windows.Forms.TrackBar tBar_CH8;
        private System.Windows.Forms.TrackBar tBar_CH1;
        private System.Windows.Forms.TrackBar tBar_CH2;
        private System.Windows.Forms.TrackBar tBar_CH4;
        private System.Windows.Forms.TrackBar tBar_CH3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ProgressBars.Basic.BasicProgressBar pBar_CH4;
        private ProgressBars.Basic.BasicProgressBar pBar_CH2;
        private ProgressBars.Basic.BasicProgressBar pBar_CH1;
        private ProgressBars.Basic.BasicProgressBar pBar_CH3;
        private ProgressBars.Basic.BasicProgressBar pBar_CH5;
        private ProgressBars.Basic.BasicProgressBar pBar_CH6;
        private ProgressBars.Basic.BasicProgressBar pBar_CH7;
        private ProgressBars.Basic.BasicProgressBar pBar_CH8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Settings;
    }
}

