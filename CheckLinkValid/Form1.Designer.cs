namespace CheckLinkValid
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
            this.btnCheckAdmin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrlAdmin = new System.Windows.Forms.TextBox();
            this.listBoxLinkNotValid = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcessRapidgator = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPageSizeAdmin = new System.Windows.Forms.TextBox();
            this.btnLoadFileFromText = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.btnCheckLink = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.pChrome = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckAdmin
            // 
            this.btnCheckAdmin.Location = new System.Drawing.Point(501, 11);
            this.btnCheckAdmin.Name = "btnCheckAdmin";
            this.btnCheckAdmin.Size = new System.Drawing.Size(84, 23);
            this.btnCheckAdmin.TabIndex = 1;
            this.btnCheckAdmin.Text = "Check Link";
            this.btnCheckAdmin.UseVisualStyleBackColor = true;
            this.btnCheckAdmin.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Url:";
            // 
            // txtUrlAdmin
            // 
            this.txtUrlAdmin.Location = new System.Drawing.Point(46, 13);
            this.txtUrlAdmin.Name = "txtUrlAdmin";
            this.txtUrlAdmin.Size = new System.Drawing.Size(328, 20);
            this.txtUrlAdmin.TabIndex = 3;
            this.txtUrlAdmin.Text = "http://blogpp.xyz/wp-admin/edit.php?paged=1";
            // 
            // listBoxLinkNotValid
            // 
            this.listBoxLinkNotValid.FormattingEnabled = true;
            this.listBoxLinkNotValid.Location = new System.Drawing.Point(632, 95);
            this.listBoxLinkNotValid.Name = "listBoxLinkNotValid";
            this.listBoxLinkNotValid.Size = new System.Drawing.Size(339, 459);
            this.listBoxLinkNotValid.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(632, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "File name not valid:";
            // 
            // btnProcessRapidgator
            // 
            this.btnProcessRapidgator.Location = new System.Drawing.Point(856, 40);
            this.btnProcessRapidgator.Name = "btnProcessRapidgator";
            this.btnProcessRapidgator.Size = new System.Drawing.Size(115, 23);
            this.btnProcessRapidgator.TabIndex = 13;
            this.btnProcessRapidgator.Text = "Process Rapidgator";
            this.btnProcessRapidgator.UseVisualStyleBackColor = true;
            this.btnProcessRapidgator.Click += new System.EventHandler(this.btnProcessRapidgator_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(380, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Page Size:";
            // 
            // txtPageSizeAdmin
            // 
            this.txtPageSizeAdmin.Location = new System.Drawing.Point(441, 13);
            this.txtPageSizeAdmin.Name = "txtPageSizeAdmin";
            this.txtPageSizeAdmin.Size = new System.Drawing.Size(38, 20);
            this.txtPageSizeAdmin.TabIndex = 18;
            this.txtPageSizeAdmin.Text = "1";
            this.txtPageSizeAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnLoadFileFromText
            // 
            this.btnLoadFileFromText.Location = new System.Drawing.Point(426, 11);
            this.btnLoadFileFromText.Name = "btnLoadFileFromText";
            this.btnLoadFileFromText.Size = new System.Drawing.Size(159, 23);
            this.btnLoadFileFromText.TabIndex = 19;
            this.btnLoadFileFromText.Text = "Load File Not Valid From Text";
            this.btnLoadFileFromText.UseVisualStyleBackColor = true;
            this.btnLoadFileFromText.Click += new System.EventHandler(this.btnLoadFileFromText_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 76);
            this.tabControl1.TabIndex = 20;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnCheckAdmin);
            this.tabPage1.Controls.Add(this.txtPageSizeAdmin);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtUrlAdmin);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 50);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Url Link Admin";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.btnLoadFileFromText);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(602, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File Text";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btnCheckLink);
            this.tabPage3.Controls.Add(this.txtPageSize);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtUrl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(602, 50);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Url Link";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(46, 13);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(328, 20);
            this.txtUrl.TabIndex = 21;
            this.txtUrl.Text = "http://blogpp.xyz/page/1/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Url:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Page Size:";
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(441, 13);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(38, 20);
            this.txtPageSize.TabIndex = 21;
            this.txtPageSize.Text = "1";
            this.txtPageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCheckLink
            // 
            this.btnCheckLink.Location = new System.Drawing.Point(501, 11);
            this.btnCheckLink.Name = "btnCheckLink";
            this.btnCheckLink.Size = new System.Drawing.Size(84, 23);
            this.btnCheckLink.TabIndex = 21;
            this.btnCheckLink.Text = "Check Link";
            this.btnCheckLink.UseVisualStyleBackColor = true;
            this.btnCheckLink.Click += new System.EventHandler(this.btnCheckLink_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(574, 493);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 32;
            // 
            // pChrome
            // 
            this.pChrome.Location = new System.Drawing.Point(30, 95);
            this.pChrome.Name = "pChrome";
            this.pChrome.Size = new System.Drawing.Size(575, 378);
            this.pChrome.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Start time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Số bản ghi lỗi / Tổng số bản ghi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 522);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "End Time";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(123, 522);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(0, 13);
            this.lblEndTime.TabIndex = 30;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(123, 493);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(0, 13);
            this.lblStartTime.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pChrome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnProcessRapidgator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxLinkNotValid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Check Link Valid";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCheckAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrlAdmin;
        private System.Windows.Forms.ListBox listBoxLinkNotValid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProcessRapidgator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPageSizeAdmin;
        private System.Windows.Forms.Button btnLoadFileFromText;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnCheckLink;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel pChrome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
    }
}

