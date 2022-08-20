namespace HotelApp
{
    partial class Form7
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.cueTextBox1 = new CueTextBox();
            this.cueTextBox2 = new CueTextBox();
            this.cueTextBox3 = new CueTextBox();
            this.cueTextBox4 = new CueTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Моб. телефон";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Паспорт";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 211);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(535, 55);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnCancel
            // 
            this.toolStripBtnCancel.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.toolStripBtnCancel.Image = global::HotelApp.Properties.Resources.Cancel;
            this.toolStripBtnCancel.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripBtnCancel.Name = "toolStripBtnCancel";
            this.toolStripBtnCancel.Size = new System.Drawing.Size(124, 52);
            this.toolStripBtnCancel.Text = "Закрыть";
            this.toolStripBtnCancel.Click += new System.EventHandler(this.toolStripBtnCancel_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(351, 12);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Комната";
            // 
            // cueTextBox1
            // 
            this.cueTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.cueTextBox1.Cue = null;
            this.cueTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cueTextBox1.Location = new System.Drawing.Point(66, 25);
            this.cueTextBox1.Name = "cueTextBox1";
            this.cueTextBox1.ReadOnly = true;
            this.cueTextBox1.Size = new System.Drawing.Size(273, 22);
            this.cueTextBox1.TabIndex = 18;
            // 
            // cueTextBox2
            // 
            this.cueTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.cueTextBox2.Cue = null;
            this.cueTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cueTextBox2.Location = new System.Drawing.Point(136, 64);
            this.cueTextBox2.Name = "cueTextBox2";
            this.cueTextBox2.ReadOnly = true;
            this.cueTextBox2.Size = new System.Drawing.Size(203, 22);
            this.cueTextBox2.TabIndex = 19;
            // 
            // cueTextBox3
            // 
            this.cueTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.cueTextBox3.Cue = null;
            this.cueTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cueTextBox3.Location = new System.Drawing.Point(93, 92);
            this.cueTextBox3.Name = "cueTextBox3";
            this.cueTextBox3.ReadOnly = true;
            this.cueTextBox3.Size = new System.Drawing.Size(246, 22);
            this.cueTextBox3.TabIndex = 20;
            // 
            // cueTextBox4
            // 
            this.cueTextBox4.BackColor = System.Drawing.SystemColors.Control;
            this.cueTextBox4.Cue = null;
            this.cueTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cueTextBox4.Location = new System.Drawing.Point(93, 120);
            this.cueTextBox4.Name = "cueTextBox4";
            this.cueTextBox4.ReadOnly = true;
            this.cueTextBox4.Size = new System.Drawing.Size(246, 22);
            this.cueTextBox4.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.cueTextBox4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cueTextBox3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cueTextBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cueTextBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 190);
            this.panel1.TabIndex = 22;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 266);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form7";
            this.Text = "Информация о пользователе";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form7_FormClosed);
            this.Load += new System.EventHandler(this.Form7_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnCancel;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label4;
        private CueTextBox cueTextBox1;
        private CueTextBox cueTextBox2;
        private CueTextBox cueTextBox3;
        private CueTextBox cueTextBox4;
        private System.Windows.Forms.Panel panel1;
    }
}