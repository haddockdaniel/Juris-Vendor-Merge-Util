namespace JurisUtilityBase
{
    partial class UtilityBaseMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilityBaseMain));
            this.JurisLogoImageBox = new System.Windows.Forms.PictureBox();
            this.LexisNexisLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxCompanies = new System.Windows.Forms.ListBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.labelCurrentStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelPercentComplete = new System.Windows.Forms.Label();
            this.OpenFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.buttonReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbDelete = new System.Windows.Forms.ComboBox();
            this.cbKeep = new System.Windows.Forms.ComboBox();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonActiveOnly = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonKeep = new System.Windows.Forms.RadioButton();
            this.radioButtonSCYes = new System.Windows.Forms.RadioButton();
            this.radioButtonSCNo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.JurisLogoImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LexisNexisLogoPictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // JurisLogoImageBox
            // 
            this.JurisLogoImageBox.Image = ((System.Drawing.Image)(resources.GetObject("JurisLogoImageBox.Image")));
            this.JurisLogoImageBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("JurisLogoImageBox.InitialImage")));
            this.JurisLogoImageBox.Location = new System.Drawing.Point(0, 1);
            this.JurisLogoImageBox.Name = "JurisLogoImageBox";
            this.JurisLogoImageBox.Size = new System.Drawing.Size(104, 336);
            this.JurisLogoImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.JurisLogoImageBox.TabIndex = 0;
            this.JurisLogoImageBox.TabStop = false;
            // 
            // LexisNexisLogoPictureBox
            // 
            this.LexisNexisLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LexisNexisLogoPictureBox.Image")));
            this.LexisNexisLogoPictureBox.Location = new System.Drawing.Point(8, 343);
            this.LexisNexisLogoPictureBox.Name = "LexisNexisLogoPictureBox";
            this.LexisNexisLogoPictureBox.Size = new System.Drawing.Size(96, 28);
            this.LexisNexisLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LexisNexisLogoPictureBox.TabIndex = 1;
            this.LexisNexisLogoPictureBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 487);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(620, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(134, 17);
            this.toolStripStatusLabel.Text = "Status: Ready to Execute";
            // 
            // listBoxCompanies
            // 
            this.listBoxCompanies.FormattingEnabled = true;
            this.listBoxCompanies.Location = new System.Drawing.Point(111, 1);
            this.listBoxCompanies.Name = "listBoxCompanies";
            this.listBoxCompanies.Size = new System.Drawing.Size(241, 69);
            this.listBoxCompanies.TabIndex = 0;
            this.listBoxCompanies.SelectedIndexChanged += new System.EventHandler(this.listBoxCompanies_SelectedIndexChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDescription.Location = new System.Drawing.Point(373, 1);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(221, 69);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Merges 2 vendors and their appropriate vouchers, batches, checks, notes and matte" +
    "r distributions. If the vendors have different 1099 settings, the vendor to keep" +
    "\'s 1099 status is the default to use.";
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.labelCurrentStatus);
            this.statusGroupBox.Controls.Add(this.progressBar);
            this.statusGroupBox.Controls.Add(this.labelPercentComplete);
            this.statusGroupBox.Location = new System.Drawing.Point(111, 77);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(491, 73);
            this.statusGroupBox.TabIndex = 5;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Utility Status:";
            // 
            // labelCurrentStatus
            // 
            this.labelCurrentStatus.AutoSize = true;
            this.labelCurrentStatus.Location = new System.Drawing.Point(7, 50);
            this.labelCurrentStatus.Name = "labelCurrentStatus";
            this.labelCurrentStatus.Size = new System.Drawing.Size(77, 13);
            this.labelCurrentStatus.TabIndex = 2;
            this.labelCurrentStatus.Text = "Current Status:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 27);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(476, 20);
            this.progressBar.TabIndex = 0;
            // 
            // labelPercentComplete
            // 
            this.labelPercentComplete.AutoSize = true;
            this.labelPercentComplete.Location = new System.Drawing.Point(412, 11);
            this.labelPercentComplete.Name = "labelPercentComplete";
            this.labelPercentComplete.Size = new System.Drawing.Size(62, 13);
            this.labelPercentComplete.TabIndex = 0;
            this.labelPercentComplete.Text = "% Complete";
            // 
            // OpenFileDialogOpen
            // 
            this.OpenFileDialogOpen.FileName = "openFileDialog1";
            // 
            // buttonReport
            // 
            this.buttonReport.BackColor = System.Drawing.Color.LightGray;
            this.buttonReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReport.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonReport.Location = new System.Drawing.Point(121, 439);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(148, 38);
            this.buttonReport.TabIndex = 16;
            this.buttonReport.Text = "Exit";
            this.buttonReport.UseVisualStyleBackColor = false;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(437, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 38);
            this.button1.TabIndex = 17;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbDelete
            // 
            this.cbDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelete.Enabled = false;
            this.cbDelete.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbDelete.FormattingEnabled = true;
            this.cbDelete.Location = new System.Drawing.Point(118, 402);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(473, 23);
            this.cbDelete.Sorted = true;
            this.cbDelete.TabIndex = 19;
            this.cbDelete.SelectedIndexChanged += new System.EventHandler(this.cbDelete_SelectedIndexChanged);
            // 
            // cbKeep
            // 
            this.cbKeep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeep.Enabled = false;
            this.cbKeep.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKeep.FormattingEnabled = true;
            this.cbKeep.Location = new System.Drawing.Point(116, 352);
            this.cbKeep.Name = "cbKeep";
            this.cbKeep.Size = new System.Drawing.Size(475, 23);
            this.cbKeep.Sorted = true;
            this.cbKeep.TabIndex = 18;
            this.cbKeep.SelectedIndexChanged += new System.EventHandler(this.cbKeep_SelectedIndexChanged);
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.AutoSize = true;
            this.radioButtonInactive.Location = new System.Drawing.Point(21, 21);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Size = new System.Drawing.Size(196, 20);
            this.radioButtonInactive.TabIndex = 22;
            this.radioButtonInactive.TabStop = true;
            this.radioButtonInactive.Text = "Include Inactive Vendors";
            this.radioButtonInactive.UseVisualStyleBackColor = true;
            this.radioButtonInactive.CheckedChanged += new System.EventHandler(this.radioButtonInactive_CheckedChanged);
            // 
            // radioButtonActiveOnly
            // 
            this.radioButtonActiveOnly.AutoSize = true;
            this.radioButtonActiveOnly.Location = new System.Drawing.Point(253, 21);
            this.radioButtonActiveOnly.Name = "radioButtonActiveOnly";
            this.radioButtonActiveOnly.Size = new System.Drawing.Size(220, 20);
            this.radioButtonActiveOnly.TabIndex = 23;
            this.radioButtonActiveOnly.TabStop = true;
            this.radioButtonActiveOnly.Text = "Include Active Vendors Only";
            this.radioButtonActiveOnly.UseVisualStyleBackColor = true;
            this.radioButtonActiveOnly.CheckedChanged += new System.EventHandler(this.radioButtonActiveOnly_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonActiveOnly);
            this.groupBox1.Controls.Add(this.radioButtonInactive);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(121, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 49);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vendor Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(121, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 53);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1099 Options to use";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(21, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(133, 20);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Vendor to Keep";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(253, 21);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(141, 20);
            this.radioButton4.TabIndex = 22;
            this.radioButton4.Text = "Vendor to Merge";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(118, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Select Vendor to keep";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(118, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Select vendor to merge (will be removed)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonSCNo);
            this.groupBox3.Controls.Add(this.radioButtonSCYes);
            this.groupBox3.Controls.Add(this.radioButtonKeep);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(121, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 51);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Separate Checks?";
            // 
            // radioButtonKeep
            // 
            this.radioButtonKeep.AutoSize = true;
            this.radioButtonKeep.Checked = true;
            this.radioButtonKeep.Location = new System.Drawing.Point(21, 21);
            this.radioButtonKeep.Name = "radioButtonKeep";
            this.radioButtonKeep.Size = new System.Drawing.Size(169, 20);
            this.radioButtonKeep.TabIndex = 23;
            this.radioButtonKeep.TabStop = true;
            this.radioButtonKeep.Text = "Keep existing setting";
            this.radioButtonKeep.UseVisualStyleBackColor = true;
            // 
            // radioButtonSCYes
            // 
            this.radioButtonSCYes.AutoSize = true;
            this.radioButtonSCYes.Location = new System.Drawing.Point(200, 21);
            this.radioButtonSCYes.Name = "radioButtonSCYes";
            this.radioButtonSCYes.Size = new System.Drawing.Size(127, 20);
            this.radioButtonSCYes.TabIndex = 24;
            this.radioButtonSCYes.Text = "Change to Yes";
            this.radioButtonSCYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonSCNo
            // 
            this.radioButtonSCNo.AutoSize = true;
            this.radioButtonSCNo.Location = new System.Drawing.Point(345, 21);
            this.radioButtonSCNo.Name = "radioButtonSCNo";
            this.radioButtonSCNo.Size = new System.Drawing.Size(120, 20);
            this.radioButtonSCNo.TabIndex = 25;
            this.radioButtonSCNo.Text = "Change to No";
            this.radioButtonSCNo.UseVisualStyleBackColor = true;
            // 
            // UtilityBaseMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 509);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbDelete);
            this.Controls.Add(this.cbKeep);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.listBoxCompanies);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.LexisNexisLogoPictureBox);
            this.Controls.Add(this.JurisLogoImageBox);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UtilityBaseMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JPS - Merge Vendors";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JurisLogoImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LexisNexisLogoPictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox JurisLogoImageBox;
        private System.Windows.Forms.PictureBox LexisNexisLogoPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ListBox listBoxCompanies;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label labelCurrentStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelPercentComplete;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogOpen;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDelete;
        private System.Windows.Forms.ComboBox cbKeep;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonActiveOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonSCNo;
        private System.Windows.Forms.RadioButton radioButtonSCYes;
        private System.Windows.Forms.RadioButton radioButtonKeep;
    }
}

