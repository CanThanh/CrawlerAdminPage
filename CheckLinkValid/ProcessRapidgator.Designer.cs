﻿namespace CheckLinkValid
{
    partial class ProcessRapidgator
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
            this.pChrome = new System.Windows.Forms.Panel();
            this.btnProcessFile = new System.Windows.Forms.Button();
            this.txtFileNotExist = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // pChrome
            // 
            this.pChrome.Location = new System.Drawing.Point(12, 41);
            this.pChrome.Name = "pChrome";
            this.pChrome.Size = new System.Drawing.Size(887, 508);
            this.pChrome.TabIndex = 0;
            // 
            // btnProcessFile
            // 
            this.btnProcessFile.Location = new System.Drawing.Point(1047, 12);
            this.btnProcessFile.Name = "btnProcessFile";
            this.btnProcessFile.Size = new System.Drawing.Size(125, 23);
            this.btnProcessFile.TabIndex = 1;
            this.btnProcessFile.Text = "Process Files";
            this.btnProcessFile.UseVisualStyleBackColor = true;
            this.btnProcessFile.Click += new System.EventHandler(this.btnProcessFile_Click);
            // 
            // txtFileNotExist
            // 
            this.txtFileNotExist.Location = new System.Drawing.Point(905, 41);
            this.txtFileNotExist.Name = "txtFileNotExist";
            this.txtFileNotExist.ReadOnly = true;
            this.txtFileNotExist.Size = new System.Drawing.Size(267, 508);
            this.txtFileNotExist.TabIndex = 2;
            this.txtFileNotExist.Text = "";
            // 
            // ProcessRapidgator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.txtFileNotExist);
            this.Controls.Add(this.btnProcessFile);
            this.Controls.Add(this.pChrome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProcessRapidgator";
            this.Text = "ProcessRapidgator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pChrome;
        private System.Windows.Forms.Button btnProcessFile;
        private System.Windows.Forms.RichTextBox txtFileNotExist;
    }
}