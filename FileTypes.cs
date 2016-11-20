using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileSearcher
{
    public partial class FileTypes : Form
    {
        MainForm _parentForm;

        public FileTypes(MainForm parentForm)
        {
            InitializeComponent();

            _parentForm = parentForm;               //set the parent of this form
        }

        private void FileTypes_Load(object sender, EventArgs e)
        {
            updateFileTypeListData();
        }

        private void FileTypes_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parentForm._fileTypesFormOpen = false;
        }


        private void updateFileTypeListData()
        {
            fileTypeList.Items.Clear();
            for (int i = 0; i < _parentForm._filesToSearch.Count; i++)
            {
                fileTypeList.Items.Add(_parentForm._filesToSearch[i]);
            }
        }

        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            string[] bufferList;
            bufferList = FilesToBeAddedTextbox.Text.Split(new char[] { ',', ' ' });

            _parentForm._filesToSearch.Clear();             //clear out old data from the _filesToSearch list
            for (int i = 0; i < bufferList.Length; i++)
            {
                if (bufferList[i] != "")
                {
                    _parentForm._filesToSearch.Add(bufferList[i]);
                }
            }

            updateFileTypeListData();
        }
    }
}