using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileSearcherWrapper;
using System.Threading;
using System.Diagnostics;

namespace FileSearcher
{
    public partial class MainForm : Form
    {
        const int SD_REL_TEXT = 0;
        const int SD_REL_TITLE = 1;
        const int SD_REL_BOTH = 2;
        
        FileTypes _fileTypesForm;
        FSWrapper _currentSearch;  
        String _searchPath;

        int _currentFileDisplayed;

        public bool _fileTypesFormOpen;         //used to keep multiple fileTypes forms from opening
        bool _searchMutex;                      //used to keep the search function from being called multiple times in a row
        public List<String> _filesToSearch;

        private BackgroundWorker _backgroundWorker1;

        public MainForm()
        {
            InitializeComponent();
            _currentSearch = new FSWrapper();
            _currentFileDisplayed = 0;

            //default search path:
            _searchPath = "C:\\";

            //by default, the fileTypesForm is closed
            _fileTypesFormOpen = false;
            _searchMutex = false;

            //default data to put in the _filesToSearch
            _filesToSearch = new List<String>();
            String tmp1 = ".doc";
            _filesToSearch.Add(tmp1);
            tmp1 = ".cpp";
            _filesToSearch.Add(tmp1);
            tmp1 = ".txt";
            _filesToSearch.Add(tmp1);

            //Initialize the background workers
            _backgroundWorker1 = new BackgroundWorker();
            _backgroundWorker1.DoWork += new DoWorkEventHandler(_backgroundWorker1_DoWork);
            _backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker1_RunWorkerCompleted);
 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setSearchPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if the user selects a folder and clicks OK
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _searchPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)  //only do action if there are rows in the grid
            {
                String tmpPath = "";
                String tmpFile = "";
                
                if (e.ColumnIndex == 1)//file name
                {
                    //Open file for viewing
                    tmpPath = (String)dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex + 1].Value;
                    tmpFile = (String)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    Process.Start(tmpPath + tmpFile);
                }
                else if (e.ColumnIndex == 2) //file path
                {
                    //Open the folder clicked on
                    tmpPath = (String)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    Process.Start(tmpPath);
                }
            }
        }

        private void setFileTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileTypesFormOpen)    //if the fileTypes form is closed the we'll open a new one
            {
                //create a new FileType form, pass it the main form so it knows who it's parent is
                _fileTypesForm = new FileTypes(this);
                _fileTypesForm.Show();
                _fileTypesFormOpen = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SetAllCurrentSearchInputs();

            //Clears old search displays
            //for (int i = 0; i < _currentFileDisplayed - 1; i++)
            //{
            //    dataGridView1.Rows.RemoveAt(i);
            dataGridView1.Rows.Clear();

            //}
            _currentFileDisplayed = 0;

            //Threads off the StartSearch() function since Boost 1.36 threading doesn't work with Vista SP1
            _backgroundWorker1.RunWorkerAsync();
        }

        void _backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _searchMutex = false;
            DisplaySearchOutputs();

            //Updates the header text to indicate that the search has completed
            this.Text = "FileSearcher - (" + _currentSearch.NumberOfFilesFound() + " Files Found)";
        }

        void _backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!_searchMutex)
            {
                _searchMutex = true;
                _currentSearch.StartSearch();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //Updates the file type output at bottom of screen based on what the user has selected
            if (SearchFilesUserSpec.Checked)
            {
                string tmpString = "";
                for (int i = 0; i < _filesToSearch.Count; i++)
                {
                    tmpString = tmpString + " " + _filesToSearch[i];
                }
                TSSL_SearchFiles.Text = " |   Searching:" + tmpString;
            }
            else if (SearchFilesAllFiles.Checked)
            {
                TSSL_SearchFiles.Text = " |   Searching: All Files";
            }

            //update the search path label at the bottom of screen
            TSSL_SearchPath.Text = "Path: " + _searchPath;

            //updates the search window while the search is going on
            if (_searchMutex)
            {
                DisplaySearchOutputs();
            }
        }

        private void SetAllCurrentSearchInputs()
        {
            //Clears previous search inputs
            _currentSearch.ClearSearch();

            //Updates the relevance style based on what the user has selected
            if (SearchTypeFileName.Checked)
            {
                _currentSearch.SetRelevanceStyle(SD_REL_TITLE);
            }
            else if (SearchTypeFileText.Checked)
            {
                _currentSearch.SetRelevanceStyle(SD_REL_TEXT);
            }
            else if (SearchTypeBoth.Checked)
            {
                _currentSearch.SetRelevanceStyle(SD_REL_BOTH);
            }

            //Updates the file type based on what the user has selected
            if (SearchFilesUserSpec.Checked)
            {
                _currentSearch.SearchAllFiles(false);
                _currentSearch.clearFileTypeToSearch();
                for (int i = 0; i < _filesToSearch.Count; i++)          //loop though all selected files to search and adds them
                {
                    _currentSearch.addFileTypeToSearch(_filesToSearch[i]);
                }
            }
            else if (SearchFilesAllFiles.Checked)                       //searches through all file types
            {
                _currentSearch.SearchAllFiles(true);
            }

            //sets the path to start the search in
            _currentSearch.SetStartPath(_searchPath);

            //sets the search string that we're looking for
            _currentSearch.SetSearchString(SearchStringTextBox.Text);
        }

        private void DisplaySearchOutputs()
        {
            uint numFilesFound = (uint)_currentSearch.NumberOfFilesFound();
            String tmpFilePath;
            String tmpFileName;
            String tmpExtension;
            double tmpRelevance;

            //Updates the header text to show number of files found
            this.Text = "FileSearcher - Searching (" + numFilesFound + " Files Found)";

            for (uint i = (uint)_currentFileDisplayed; i < numFilesFound; i++)
            {
                //Gets data from unmanaged code
                tmpFilePath = _currentSearch.ReturnPathAt(i);
                tmpFileName = _currentSearch.ReturnNameAt(i);
                tmpRelevance = _currentSearch.ReturnRelAt(i);
                tmpExtension = _currentSearch.ReturnExtAt(i);
                
                //Create a new row and updates all columns in it
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = tmpRelevance;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = tmpFileName;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = tmpFilePath;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = tmpExtension;

                //updates which columns are currently displayed
                _currentFileDisplayed++;
            }
        }
    }
}