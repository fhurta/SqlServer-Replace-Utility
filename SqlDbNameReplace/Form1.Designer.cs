namespace SqlDbNameReplace
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
            this.btnStart = new System.Windows.Forms.Button();
            this.DatabasesComboBox = new System.Windows.Forms.ComboBox();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.tbOrigString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNewString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(265, 180);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // DatabasesComboBox
            // 
            this.DatabasesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DatabasesComboBox.FormattingEnabled = true;
            this.DatabasesComboBox.Location = new System.Drawing.Point(91, 12);
            this.DatabasesComboBox.Name = "DatabasesComboBox";
            this.DatabasesComboBox.Size = new System.Drawing.Size(175, 21);
            this.DatabasesComboBox.TabIndex = 23;
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DatabaseLabel.Location = new System.Drawing.Point(4, 15);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(81, 17);
            this.DatabaseLabel.TabIndex = 22;
            this.DatabaseLabel.Text = "&Database:";
            // 
            // tbOrigString
            // 
            this.tbOrigString.Location = new System.Drawing.Point(91, 71);
            this.tbOrigString.Name = "tbOrigString";
            this.tbOrigString.Size = new System.Drawing.Size(100, 20);
            this.tbOrigString.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Replace";
            // 
            // tbNewString
            // 
            this.tbNewString.Location = new System.Drawing.Point(240, 71);
            this.tbNewString.Name = "tbNewString";
            this.tbNewString.Size = new System.Drawing.Size(100, 20);
            this.tbNewString.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "With";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 220);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNewString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOrigString);
            this.Controls.Add(this.DatabasesComboBox);
            this.Controls.Add(this.DatabaseLabel);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Replace in DB";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox DatabasesComboBox;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.TextBox tbOrigString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNewString;
        private System.Windows.Forms.Label label2;
    }
}

