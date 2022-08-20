namespace HotelApp
{
    partial class Form2
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnAccept = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cueTextBox2 = new CueTextBox();
            this.cueTextBox3 = new CueTextBox();
            this.cueTextBox1 = new CueTextBox();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(15, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Паспорт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Моб. телефон";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnAccept,
            this.toolStripBtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 155);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(492, 55);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnAccept
            // 
            this.toolStripBtnAccept.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.toolStripBtnAccept.Image = global::HotelApp.Properties.Resources.AddNew;
            this.toolStripBtnAccept.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripBtnAccept.Name = "toolStripBtnAccept";
            this.toolStripBtnAccept.Size = new System.Drawing.Size(133, 52);
            this.toolStripBtnAccept.Text = "Добавить";
            this.toolStripBtnAccept.Click += new System.EventHandler(this.toolStripBtnAccept_Click);
            // 
            // toolStripBtnCancel
            // 
            this.toolStripBtnCancel.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.toolStripBtnCancel.Image = global::HotelApp.Properties.Resources.Cancel;
            this.toolStripBtnCancel.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripBtnCancel.Name = "toolStripBtnCancel";
            this.toolStripBtnCancel.Size = new System.Drawing.Size(118, 52);
            this.toolStripBtnCancel.Text = "Отмена";
            this.toolStripBtnCancel.Click += new System.EventHandler(this.toolStripBtnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.cueTextBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cueTextBox3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cueTextBox1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 136);
            this.panel2.TabIndex = 12;
            // 
            // cueTextBox2
            // 
            this.cueTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.cueTextBox2.Cue = "Введите номер телефона";
            this.cueTextBox2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.cueTextBox2.Location = new System.Drawing.Point(139, 58);
            this.cueTextBox2.Name = "cueTextBox2";
            this.cueTextBox2.Size = new System.Drawing.Size(306, 25);
            this.cueTextBox2.TabIndex = 9;
            // 
            // cueTextBox3
            // 
            this.cueTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.cueTextBox3.Cue = "Введите серию и номер паспорта";
            this.cueTextBox3.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.cueTextBox3.Location = new System.Drawing.Point(139, 89);
            this.cueTextBox3.Name = "cueTextBox3";
            this.cueTextBox3.Size = new System.Drawing.Size(306, 25);
            this.cueTextBox3.TabIndex = 10;
            // 
            // cueTextBox1
            // 
            this.cueTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.cueTextBox1.Cue = "Введите ФИО";
            this.cueTextBox1.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cueTextBox1.Location = new System.Drawing.Point(139, 27);
            this.cueTextBox1.Name = "cueTextBox1";
            this.cueTextBox1.Size = new System.Drawing.Size(306, 25);
            this.cueTextBox1.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(492, 210);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить постояльца";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CueTextBox cueTextBox3;
        private CueTextBox cueTextBox2;
        private CueTextBox cueTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnAccept;
        private System.Windows.Forms.ToolStripButton toolStripBtnCancel;
        private System.Windows.Forms.Panel panel2;
    }
}