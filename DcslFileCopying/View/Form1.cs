using DcsFileCopying.ViewModel;
using DcslFileCopying.Controllers;
using DcslFileCopying.Controllers.CoypingFunctionality;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DcslFileCopying
{
    public partial class FrmCopyingUI : Form
    {
        public static string C_Path = "C:\\";
        public static string AllFilesSymbol = "*.*";
        private FileViewModel mFileViewModel;
        private CopyingController copyingController;
        private Dictionary<string, FileViewModel> fileDictionary;
        public delegate void UpdateListBox();
        private static Stopwatch copyingStopWatch;

        public FrmCopyingUI()
        {
            InitializeComponent();
        }

        //so to allow list box to be seen by controller  
        public ListBox GetCopyingListBox()
        {
            return lstAllFilesFolders;
        }


        private void GetAllFilesFromFolder(FolderBrowserDialog openFolder)
        {
            var userClick = openFolder.ShowDialog();
            mFileViewModel = new FileViewModel();
            copyingController = new CopyingController(mFileViewModel);


            var fileIndex = 0;
            if (userClick == DialogResult.OK)
            {
                txtCopyFileLocation.Text = openFolder.SelectedPath;
                var folderPath = txtCopyFileLocation.Text;

                Application.UseWaitCursor = true;
                //clear all previous items in the list box 
                lstAllFilesFolders.Items.Clear();

                //this is a call back for letting program know that thread has finished 
                var starterToRetreiveFiles = new ThreadStart(() => PutFilesIntoListBox(folderPath, fileIndex));
                starterToRetreiveFiles += () =>
                {
                    // Do what you want in the callback
                    Application.UseWaitCursor = false; // Set cursor as default arrow
                    Debug.WriteLine("We have finished the thread : and reading all the files");
                };

                var retrievingFilesThread = new Thread(starterToRetreiveFiles);
                retrievingFilesThread.Start();
            }
        }

        private void PutFilesIntoListBox(string folderPath, int fileIndex)
        {
            //set all files in that folder to the list box item
            var specifiedDirectory = new DirectoryInfo(folderPath);
            fileDictionary = new Dictionary<string, FileViewModel>(); 
            foreach (var file in specifiedDirectory.GetFiles(AllFilesSymbol, SearchOption.AllDirectories))
            {
                fileIndex++;
                //mFileViewModel.fileID = fileIndex;
                mFileViewModel.FileName = file.FullName.ToString();
                mFileViewModel.FileExtension = Path.GetExtension(file.FullName.ToString());
                mFileViewModel.FileSize = file.Length;
                mFileViewModel.DateCopied = DateTime.Now.ToString();

                AddFileToListView(mFileViewModel.FileName, mFileViewModel.FileSize, mFileViewModel.FileExtension, mFileViewModel.DateCopied); 

            }
        }


        internal void AddFileToListView(string fileName, long fileSize, string fileExtension, string dateCopied)
        {
            //Note initialise new object when adding to collections
            var fileVm = new FileViewModel();

            if (GetCopyingListBox().InvokeRequired) //check thread ID that they dont match to avoid confusion between threads
            {
                fileVm.FileName = fileName;
                fileVm.FileSize = fileSize;
                fileVm.FileExtension = fileExtension;
                fileVm.DateCopied = dateCopied;
                fileDictionary[fileVm.FileName] = fileVm;

                //update GUI listbox using delegate function pointer
                this.GetCopyingListBox().Invoke(new UpdateListBox(AddingFilesToUpdateList));
            }
            else
            {
                Debug.WriteLine("Error Should Write on thread Above");
            }
        }

        /// <summary>
        /// A delegate pointer to update UI on seperate thread
        /// </summary>
        public void AddingFilesToUpdateList()
        {
            this.GetCopyingListBox().Items.Add(this.GetFile());
        }

        /// <summary>
        /// Gets the full file name to the list
        /// </summary>
        /// <returns> the full file name of the file</returns>
        public string GetFile()
        {
            return this.mFileViewModel.FileName;
        }


        //total file size in MB 
        public float GetTotalFolderSize()
        {
            //this checks in the UI listbox object 
            var MB = 1024f;
            long totalSize = 0;
            foreach (var item in GetCopyingListBox().Items)
            {
                var file = new FileInfo(item.ToString());
                totalSize += file.Length;
            }
            return (totalSize / MB) / MB;
        }









        #region Events 

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //Create an instance of the open file dialog box.
            try
            {
                using (var openFolder = new FolderBrowserDialog())
                {
                    if (!Directory.Exists(C_Path))
                    {
                        Debug.WriteLine("C Drive not Found");
                        lblErrors.Text = "C Drive not Found";
                    }
                    else
                    {
                        openFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                        //openFolder.ShowDialog();

                        //call method to  retrive file and folder path name  
                        GetAllFilesFromFolder(openFolder);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        private void btnCopyTo_Click(object sender, EventArgs e)
        {

            //Create an instance of the open file dialog box.
            try
            {
                using (var openDestinationFolder = new FolderBrowserDialog())
                {
                    if (!Directory.Exists(C_Path))
                    {
                        Debug.WriteLine("C Drive not Found");
                        lblErrors.Text = "C Drive not Found";
                    }
                    else
                    {
                        openDestinationFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                        openDestinationFolder.ShowDialog();

                        txtCopyDestination.Text = openDestinationFolder.SelectedPath;
                        var folderPath = txtCopyDestination.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }


        /// <summary>
        /// Copy button which will start to copy 
        /// files from source o destination 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            //check if backgroud worker is already running asynchronous operation 
            if (!CopyingBackgroundWorkerThread.IsBusy)
            {
                //this method will start excution asychronously in the background 
                CopyingBackgroundWorkerThread.RunWorkerAsync();
            }
            else
            {
                Debug.WriteLine("Copying Busy Processing, please wait");
                lblErrors.Text = "Copying Busy Processing, please wait"; 
            }
        }




        #endregion



        #region BGThread



        /// <summary>
        /// Start bg worker thread 
        /// </summary>
        private void CopyingBackgroundWorkerThread_DoWork(object sender, DoWorkEventArgs ex)
        {
            //var files = new List<string>();
            //foreach (var file in lstAllFilesFolders.Items)
            //{
            //    files.Add(file.ToString());
            //}
            //copying Controller.

            //start timer 
            try
            {
                copyingStopWatch = new Stopwatch();
                copyingStopWatch.Start();
                progressBarCopyingFiles.Minimum = 0;
               // progressBarCopyingFiles.Maximum = lstAllFilesFolders.Items.Count;
                copyingController.ResursiveCopy(CopyingBackgroundWorkerThread, ex, txtCopyFileLocation.Text, txtCopyDestination.Text);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                MessageBox.Show(e.Message,
                    "Important Note",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }

        }


        private void CopyingBackgroundWorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                //set how many files we have as our 100 percent which was sent via our report progress method 
                progressBarCopyingFiles.Maximum = lstAllFilesFolders.Items.Count; 
            }

            try
            {
                //percentageValue = (e.ProgressPercentage / progressBarCopyingFiles.Maximum);
                progressBarCopyingFiles.Value = e.ProgressPercentage;
               // percentageValue = Math.Round((percentageValue * 100), 2);
                lblProgress.Text = progressBarCopyingFiles.Value.ToString() + " % Completion";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message,
                    "Important Note",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }



        }


        private void CopyingBackgroundWorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled) //check if the thread or stop button as called
                {
                    //reset ui telling user copying was interupted 
                    progressBarCopyingFiles.Value = 0;
                    lstAllFilesFolders.Items.Clear();
                    txtCopyDestination.Text = string.Empty;
                    txtCopyFileLocation.Text = string.Empty;
                    copyingStopWatch.Reset();

                }
                else
                {
                    copyingStopWatch.Stop();
                    //display info of completed process 
                    lblFolderName.Text = txtCopyFileLocation.Text;
                    lblFolderSize.Text = GetTotalFolderSize().ToString();
                    lblTotalFileSize.Text = lstAllFilesFolders.Items.Count.ToString(); 
                    lblErrors.Text = "Completed Copying";
                    lblTimeElapsed.Text = copyingStopWatch.Elapsed.Milliseconds.ToString() + " MiliSeconds";
                    lblProgress.Text = "100% Completion";
                    copyingStopWatch.Reset();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message,
                    "Important Note",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }



        #endregion


    }
}
