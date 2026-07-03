namespace TEST_1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnOFF = new System.Windows.Forms.Button();
            this.btnON = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.btnSTART = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SoSanPham = new System.Windows.Forms.Label();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.labelGreen = new System.Windows.Forms.Label();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.labelYelow = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.a = new System.Windows.Forms.Label();
            this.panelGreenNam = new System.Windows.Forms.Panel();
            this.labelGreenNam = new System.Windows.Forms.Label();
            this.panelYellowNam = new System.Windows.Forms.Panel();
            this.labelYelowNam = new System.Windows.Forms.Label();
            this.panelRed = new System.Windows.Forms.Panel();
            this.labelRed = new System.Windows.Forms.Label();
            this.panelRedNam = new System.Windows.Forms.Panel();
            this.labelRedNam = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelGreen.SuspendLayout();
            this.panelYellow.SuspendLayout();
            this.panelGreenNam.SuspendLayout();
            this.panelYellowNam.SuspendLayout();
            this.panelRed.SuspendLayout();
            this.panelRedNam.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOFF
            // 
            this.btnOFF.BackColor = System.Drawing.SystemColors.Control;
            this.btnOFF.Location = new System.Drawing.Point(515, 129);
            this.btnOFF.Name = "btnOFF";
            this.btnOFF.Size = new System.Drawing.Size(75, 34);
            this.btnOFF.TabIndex = 1;
            this.btnOFF.Text = "LED OFF";
            this.btnOFF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOFF.UseVisualStyleBackColor = false;
            this.btnOFF.Click += new System.EventHandler(this.btnOFF_Click);
            // 
            // btnON
            // 
            this.btnON.BackColor = System.Drawing.SystemColors.Control;
            this.btnON.Location = new System.Drawing.Point(515, 62);
            this.btnON.Name = "btnON";
            this.btnON.Size = new System.Drawing.Size(75, 34);
            this.btnON.TabIndex = 3;
            this.btnON.Text = "LED ON";
            this.btnON.UseVisualStyleBackColor = false;
            this.btnON.Click += new System.EventHandler(this.btnON_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.Location = new System.Drawing.Point(92, 61);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(75, 36);
            this.btnSTOP.TabIndex = 4;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = true;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnSTART
            // 
            this.btnSTART.Location = new System.Drawing.Point(92, 155);
            this.btnSTART.Name = "btnSTART";
            this.btnSTART.Size = new System.Drawing.Size(75, 34);
            this.btnSTART.TabIndex = 5;
            this.btnSTART.Text = "START";
            this.btnSTART.UseVisualStyleBackColor = true;
            this.btnSTART.Click += new System.EventHandler(this.btnSTART_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(92, 247);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 34);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // SoSanPham
            // 
            this.SoSanPham.AutoSize = true;
            this.SoSanPham.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.SoSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoSanPham.Location = new System.Drawing.Point(717, 61);
            this.SoSanPham.Name = "SoSanPham";
            this.SoSanPham.Size = new System.Drawing.Size(69, 76);
            this.SoSanPham.TabIndex = 8;
            this.SoSanPham.Text = "0";
            this.SoSanPham.Click += new System.EventHandler(this.SoSanPham_Click);
            // 
            // panelGreen
            // 
            this.panelGreen.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelGreen.Controls.Add(this.labelGreen);
            this.panelGreen.Location = new System.Drawing.Point(287, 355);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(40, 40);
            this.panelGreen.TabIndex = 10;
            // 
            // labelGreen
            // 
            this.labelGreen.BackColor = System.Drawing.Color.Transparent;
            this.labelGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGreen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelGreen.Location = new System.Drawing.Point(0, 0);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(40, 40);
            this.labelGreen.TabIndex = 15;
            this.labelGreen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelGreen.Click += new System.EventHandler(this.labelYelow_Click);
            // 
            // panelYellow
            // 
            this.panelYellow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelYellow.Controls.Add(this.labelYelow);
            this.panelYellow.Location = new System.Drawing.Point(287, 285);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(40, 40);
            this.panelYellow.TabIndex = 11;
            // 
            // labelYelow
            // 
            this.labelYelow.BackColor = System.Drawing.Color.Transparent;
            this.labelYelow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelYelow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYelow.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelYelow.Location = new System.Drawing.Point(0, 0);
            this.labelYelow.Name = "labelYelow";
            this.labelYelow.Size = new System.Drawing.Size(40, 40);
            this.labelYelow.TabIndex = 16;
            this.labelYelow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelYelow.Click += new System.EventHandler(this.labelGreen_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // a
            // 
            this.a.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.a.Location = new System.Drawing.Point(264, 171);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(110, 18);
            this.a.TabIndex = 15;
            this.a.Text = "Den Phia Bac";
            // 
            // panelGreenNam
            // 
            this.panelGreenNam.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelGreenNam.Controls.Add(this.labelGreenNam);
            this.panelGreenNam.Location = new System.Drawing.Point(537, 209);
            this.panelGreenNam.Name = "panelGreenNam";
            this.panelGreenNam.Size = new System.Drawing.Size(40, 40);
            this.panelGreenNam.TabIndex = 16;
            // 
            // labelGreenNam
            // 
            this.labelGreenNam.BackColor = System.Drawing.Color.Transparent;
            this.labelGreenNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGreenNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGreenNam.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelGreenNam.Location = new System.Drawing.Point(0, 0);
            this.labelGreenNam.Name = "labelGreenNam";
            this.labelGreenNam.Size = new System.Drawing.Size(40, 40);
            this.labelGreenNam.TabIndex = 0;
            this.labelGreenNam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGreenNam.Click += new System.EventHandler(this.labelGreenNam_Click);
            // 
            // panelYellowNam
            // 
            this.panelYellowNam.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelYellowNam.Controls.Add(this.labelYelowNam);
            this.panelYellowNam.Location = new System.Drawing.Point(537, 285);
            this.panelYellowNam.Name = "panelYellowNam";
            this.panelYellowNam.Size = new System.Drawing.Size(40, 40);
            this.panelYellowNam.TabIndex = 17;
            // 
            // labelYelowNam
            // 
            this.labelYelowNam.BackColor = System.Drawing.Color.Transparent;
            this.labelYelowNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelYelowNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYelowNam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelYelowNam.Location = new System.Drawing.Point(0, 0);
            this.labelYelowNam.Name = "labelYelowNam";
            this.labelYelowNam.Size = new System.Drawing.Size(40, 40);
            this.labelYelowNam.TabIndex = 15;
            this.labelYelowNam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelYelowNam.Click += new System.EventHandler(this.labelYelowNam_Click);
            // 
            // panelRed
            // 
            this.panelRed.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelRed.Controls.Add(this.labelRed);
            this.panelRed.Location = new System.Drawing.Point(287, 209);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(40, 40);
            this.panelRed.TabIndex = 9;
            // 
            // labelRed
            // 
            this.labelRed.BackColor = System.Drawing.Color.Transparent;
            this.labelRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRed.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelRed.Location = new System.Drawing.Point(0, 0);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(40, 40);
            this.labelRed.TabIndex = 0;
            this.labelRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRed.Click += new System.EventHandler(this.labelRed_Click);
            // 
            // panelRedNam
            // 
            this.panelRedNam.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelRedNam.Controls.Add(this.labelRedNam);
            this.panelRedNam.Location = new System.Drawing.Point(537, 355);
            this.panelRedNam.Name = "panelRedNam";
            this.panelRedNam.Size = new System.Drawing.Size(40, 40);
            this.panelRedNam.TabIndex = 18;
            // 
            // labelRedNam
            // 
            this.labelRedNam.BackColor = System.Drawing.Color.Transparent;
            this.labelRedNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRedNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRedNam.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelRedNam.Location = new System.Drawing.Point(0, 0);
            this.labelRedNam.Name = "labelRedNam";
            this.labelRedNam.Size = new System.Drawing.Size(40, 40);
            this.labelRedNam.TabIndex = 0;
            this.labelRedNam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(512, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Den Phia Nam";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 437);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelRedNam);
            this.Controls.Add(this.panelYellowNam);
            this.Controls.Add(this.panelGreenNam);
            this.Controls.Add(this.a);
            this.Controls.Add(this.panelYellow);
            this.Controls.Add(this.panelGreen);
            this.Controls.Add(this.panelRed);
            this.Controls.Add(this.SoSanPham);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSTART);
            this.Controls.Add(this.btnSTOP);
            this.Controls.Add(this.btnON);
            this.Controls.Add(this.btnOFF);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelGreen.ResumeLayout(false);
            this.panelYellow.ResumeLayout(false);
            this.panelGreenNam.ResumeLayout(false);
            this.panelYellowNam.ResumeLayout(false);
            this.panelRed.ResumeLayout(false);
            this.panelRedNam.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOFF;
        private System.Windows.Forms.Button btnON;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.Button btnSTART;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label SoSanPham;
        private System.Windows.Forms.Panel panelGreen;
        private System.Windows.Forms.Panel panelYellow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelYelow;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.Panel panelGreenNam;
        private System.Windows.Forms.Label labelGreenNam;
        private System.Windows.Forms.Panel panelYellowNam;
        private System.Windows.Forms.Label labelYelowNam;
        private System.Windows.Forms.Panel panelRed;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Panel panelRedNam;
        private System.Windows.Forms.Label labelRedNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
    }
}

