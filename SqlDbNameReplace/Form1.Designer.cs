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
            this.tbOut = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(426, 98);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Replace";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // DatabasesComboBox
            // 
            this.DatabasesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DatabasesComboBox.FormattingEnabled = true;
            this.DatabasesComboBox.Location = new System.Drawing.Point(102, 18);
            this.DatabasesComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DatabasesComboBox.Name = "DatabasesComboBox";
            this.DatabasesComboBox.Size = new System.Drawing.Size(276, 24);
            this.DatabasesComboBox.TabIndex = 23;
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DatabaseLabel.Location = new System.Drawing.Point(5, 18);
            this.DatabaseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(108, 21);
            this.DatabaseLabel.TabIndex = 22;
            this.DatabaseLabel.Text = "&Database:";
            // 
            // tbOrigString
            // 
            this.tbOrigString.Location = new System.Drawing.Point(102, 59);
            this.tbOrigString.Margin = new System.Windows.Forms.Padding(4);
            this.tbOrigString.Name = "tbOrigString";
            this.tbOrigString.Size = new System.Drawing.Size(276, 22);
            this.tbOrigString.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Find";
            // 
            // tbNewString
            // 
            this.tbNewString.Location = new System.Drawing.Point(102, 98);
            this.tbNewString.Margin = new System.Windows.Forms.Padding(4);
            this.tbNewString.Name = "tbNewString";
            this.tbNewString.Size = new System.Drawing.Size(276, 22);
            this.tbNewString.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Replace with";
            // 
            // tbOut
            // 
            this.tbOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOut.Location = new System.Drawing.Point(5, 140);
            this.tbOut.Margin = new System.Windows.Forms.Padding(4);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOut.Size = new System.Drawing.Size(664, 333);
            this.tbOut.TabIndex = 28;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(426, 59);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 474);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNewString);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOrigString);
            this.Controls.Add(this.DatabasesComboBox);
            this.Controls.Add(this.DatabaseLabel);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.Button btnSearch;
    }
}

