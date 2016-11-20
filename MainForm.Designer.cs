namespace FileSearcher
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DGV_Relevance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.TSSL_SearchPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSSL_SearchFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.setFileTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSearchPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchStringTextBox = new System.Windows.Forms.TextBox();
            this.StartSearchButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchFilesAllFiles = new System.Windows.Forms.RadioButton();
            this.SearchFilesUserSpec = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SearchTypeBoth = new System.Windows.Forms.RadioButton();
            this.SearchTypeFileText = new System.Windows.Forms.RadioButton();
            this.SearchTypeFileName = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGV_Relevance,
            this.DGV_FileName,
            this.DGV_FilePath,
            this.DGV_FileType});
            this.dataGridView1.Location = new System.Drawing.Point(12, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(623, 305);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DGV_Relevance
            // 
            this.DGV_Relevance.HeaderText = "Relevance";
            this.DGV_Relevance.Name = "DGV_Relevance";
            this.DGV_Relevance.ReadOnly = true;
            this.DGV_Relevance.Width = 75;
            // 
            // DGV_FileName
            // 
            this.DGV_FileName.HeaderText = "File Name";
            this.DGV_FileName.Name = "DGV_FileName";
            this.DGV_FileName.ReadOnly = true;
            this.DGV_FileName.Width = 120;
            // 
            // DGV_FilePath
            // 
            this.DGV_FilePath.HeaderText = "File Path";
            this.DGV_FilePath.Name = "DGV_FilePath";
            this.DGV_FilePath.ReadOnly = true;
            this.DGV_FilePath.Width = 250;
            // 
            // DGV_FileType
            // 
            this.DGV_FileType.HeaderText = "File Type";
            this.DGV_FileType.Name = "DGV_FileType";
            this.DGV_FileType.ReadOnly = true;
            this.DGV_FileType.Width = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.TSSL_SearchPath,
            this.TSSL_SearchFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(645, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // TSSL_SearchPath
            // 
            this.TSSL_SearchPath.Name = "TSSL_SearchPath";
            this.TSSL_SearchPath.Size = new System.Drawing.Size(50, 17);
            this.TSSL_SearchPath.Text = "Path: C:\\";
            this.TSSL_SearchPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TSSL_SearchFiles
            // 
            this.TSSL_SearchFiles.Name = "TSSL_SearchFiles";
            this.TSSL_SearchFiles.Size = new System.Drawing.Size(110, 17);
            this.TSSL_SearchFiles.Text = " |   Searching: All Files";
            this.TSSL_SearchFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.setFileTypeToolStripMenuItem,
            this.setSearchPathToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(74, 20);
            this.toolStripMenuItem1.Text = "File Options";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // setFileTypeToolStripMenuItem
            // 
            this.setFileTypeToolStripMenuItem.Name = "setFileTypeToolStripMenuItem";
            this.setFileTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setFileTypeToolStripMenuItem.Text = "Set File Type";
            this.setFileTypeToolStripMenuItem.Click += new System.EventHandler(this.setFileTypeToolStripMenuItem_Click);
            // 
            // setSearchPathToolStripMenuItem
            // 
            this.setSearchPathToolStripMenuItem.Name = "setSearchPathToolStripMenuItem";
            this.setSearchPathToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setSearchPathToolStripMenuItem.Text = "Set Search Path";
            this.setSearchPathToolStripMenuItem.Click += new System.EventHandler(this.setSearchPathToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SearchStringTextBox
            // 
            this.SearchStringTextBox.Location = new System.Drawing.Point(12, 27);
            this.SearchStringTextBox.Name = "SearchStringTextBox";
            this.SearchStringTextBox.Size = new System.Drawing.Size(189, 20);
            this.SearchStringTextBox.TabIndex = 4;
            // 
            // StartSearchButton
            // 
            this.StartSearchButton.Location = new System.Drawing.Point(207, 28);
            this.StartSearchButton.Name = "StartSearchButton";
            this.StartSearchButton.Size = new System.Drawing.Size(58, 19);
            this.StartSearchButton.TabIndex = 5;
            this.StartSearchButton.Text = "Search";
            this.StartSearchButton.UseVisualStyleBackColor = true;
            this.StartSearchButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchFilesAllFiles);
            this.groupBox1.Controls.Add(this.SearchFilesUserSpec);
            this.groupBox1.Location = new System.Drawing.Point(422, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Files";
            // 
            // SearchFilesAllFiles
            // 
            this.SearchFilesAllFiles.AutoSize = true;
            this.SearchFilesAllFiles.Checked = true;
            this.SearchFilesAllFiles.Location = new System.Drawing.Point(6, 42);
            this.SearchFilesAllFiles.Name = "SearchFilesAllFiles";
            this.SearchFilesAllFiles.Size = new System.Drawing.Size(60, 17);
            this.SearchFilesAllFiles.TabIndex = 3;
            this.SearchFilesAllFiles.TabStop = true;
            this.SearchFilesAllFiles.Text = "All Files";
            this.SearchFilesAllFiles.UseVisualStyleBackColor = true;
            // 
            // SearchFilesUserSpec
            // 
            this.SearchFilesUserSpec.AutoSize = true;
            this.SearchFilesUserSpec.Location = new System.Drawing.Point(6, 19);
            this.SearchFilesUserSpec.Name = "SearchFilesUserSpec";
            this.SearchFilesUserSpec.Size = new System.Drawing.Size(94, 17);
            this.SearchFilesUserSpec.TabIndex = 2;
            this.SearchFilesUserSpec.Text = "User Specified";
            this.SearchFilesUserSpec.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SearchTypeBoth);
            this.groupBox2.Controls.Add(this.SearchTypeFileText);
            this.groupBox2.Controls.Add(this.SearchTypeFileName);
            this.groupBox2.Location = new System.Drawing.Point(271, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 90);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Type";
            // 
            // SearchTypeBoth
            // 
            this.SearchTypeBoth.AutoSize = true;
            this.SearchTypeBoth.Checked = true;
            this.SearchTypeBoth.Location = new System.Drawing.Point(19, 65);
            this.SearchTypeBoth.Name = "SearchTypeBoth";
            this.SearchTypeBoth.Size = new System.Drawing.Size(47, 17);
            this.SearchTypeBoth.TabIndex = 2;
            this.SearchTypeBoth.TabStop = true;
            this.SearchTypeBoth.Text = "Both";
            this.SearchTypeBoth.UseVisualStyleBackColor = true;
            // 
            // SearchTypeFileText
            // 
            this.SearchTypeFileText.AutoSize = true;
            this.SearchTypeFileText.Location = new System.Drawing.Point(19, 42);
            this.SearchTypeFileText.Name = "SearchTypeFileText";
            this.SearchTypeFileText.Size = new System.Drawing.Size(65, 17);
            this.SearchTypeFileText.TabIndex = 1;
            this.SearchTypeFileText.Text = "File Text";
            this.SearchTypeFileText.UseVisualStyleBackColor = true;
            this.SearchTypeFileText.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // SearchTypeFileName
            // 
            this.SearchTypeFileName.AutoSize = true;
            this.SearchTypeFileName.Location = new System.Drawing.Point(19, 19);
            this.SearchTypeFileName.Name = "SearchTypeFileName";
            this.SearchTypeFileName.Size = new System.Drawing.Size(72, 17);
            this.SearchTypeFileName.TabIndex = 0;
            this.SearchTypeFileName.Text = "File Name";
            this.SearchTypeFileName.UseVisualStyleBackColor = true;
            this.SearchTypeFileName.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 455);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartSearchButton);
            this.Controls.Add(this.SearchStringTextBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FileSearcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setFileTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem setSearchPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox SearchStringTextBox;
        private System.Windows.Forms.Button StartSearchButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton SearchTypeBoth;
        private System.Windows.Forms.RadioButton SearchTypeFileText;
        private System.Windows.Forms.RadioButton SearchTypeFileName;
        private System.Windows.Forms.RadioButton SearchFilesAllFiles;
        private System.Windows.Forms.RadioButton SearchFilesUserSpec;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_SearchPath;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_SearchFiles;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_Relevance;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_FileType;
    }
}

