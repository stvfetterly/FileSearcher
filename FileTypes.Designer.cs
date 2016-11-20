namespace FileSearcher
{
    partial class FileTypes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileTypeList = new System.Windows.Forms.ListBox();
            this.FilesToBeAddedTextbox = new System.Windows.Forms.TextBox();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fileTypeList);
            this.groupBox1.Location = new System.Drawing.Point(210, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files Currently Searched For";
            // 
            // fileTypeList
            // 
            this.fileTypeList.FormattingEnabled = true;
            this.fileTypeList.Location = new System.Drawing.Point(6, 19);
            this.fileTypeList.Name = "fileTypeList";
            this.fileTypeList.Size = new System.Drawing.Size(154, 95);
            this.fileTypeList.TabIndex = 0;
            // 
            // FilesToBeAddedTextbox
            // 
            this.FilesToBeAddedTextbox.Location = new System.Drawing.Point(12, 31);
            this.FilesToBeAddedTextbox.Name = "FilesToBeAddedTextbox";
            this.FilesToBeAddedTextbox.Size = new System.Drawing.Size(121, 20);
            this.FilesToBeAddedTextbox.TabIndex = 1;
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.Location = new System.Drawing.Point(139, 31);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(71, 25);
            this.AddFilesButton.TabIndex = 2;
            this.AddFilesButton.Text = "Add Files";
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seperate different filetypes by a space";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "(\' \'), or a comma (\',\').  Ex:  \".txt, .cpp,";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = " .doc\" or \".pdf .txt .h\".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // FileTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 136);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddFilesButton);
            this.Controls.Add(this.FilesToBeAddedTextbox);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileTypes";
            this.Text = "File Searcher - File Types";
            this.Load += new System.EventHandler(this.FileTypes_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileTypes_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox fileTypeList;
        private System.Windows.Forms.TextBox FilesToBeAddedTextbox;
        private System.Windows.Forms.Button AddFilesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}