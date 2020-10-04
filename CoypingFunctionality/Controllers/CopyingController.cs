using DcsFileCopying.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcslFileCopying.Controllers.CoypingFunctionality
{
    public class CopyingController
    {
        private FileViewModel mFileViewModel;
        private Dictionary<string, FileViewModel> fileDictionary;
        public delegate void UpdateListBox();


        public CopyingController(FileViewModel mFileViewModel)
        {
            this.mFileViewModel = mFileViewModel;
            fileDictionary = new Dictionary<string, FileViewModel>(); 
        }


        #region Recursive Algoritm to copy files and folders  

        //recursion is a method that calls its self (self callback)
        public void ResursiveCopy(BackgroundWorker copyingBackgroundWorkerThread,
                        DoWorkEventArgs copyingWorker, string source, string destination)
        {
      
            try
            {

                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);


                var count = 0;
                var filesTobeCopied = Directory.GetFiles(source);
                foreach (string file in filesTobeCopied)
                {
                    //if the file does not eists in dest folder copy 
                    if (File.Exists(file.Replace(source,destination)))
                    {
                        //skip this copy but report progress to progress bar 
                        count++;
                        continue;
                    }

                    var name = Path.GetFileName(file);
                    var dest = Path.Combine(destination, name);
                    File.Copy(file, dest);


                    //This is where we report to stop the thread if user has clicked stop and break out of the loop 
                    if (copyingBackgroundWorkerThread.CancellationPending) //calls to the background cancellation event 
                    {
                        copyingWorker.Cancel = true;
                        return;
                    }
                    count++;
                    //inform the progress bar of how copying is progressing 
                    copyingBackgroundWorkerThread.ReportProgress(count);
                }

                //copy the next file in folders if any 
                var folders = Directory.GetDirectories(source);
                foreach (string folder in folders)
                {
                    var name = Path.GetFileName(folder);
                    var dest = Path.Combine(destination, name);


                    //This is where we report to stop the thread if user has clicked stop and break out of the loop 
                    if (copyingBackgroundWorkerThread.CancellationPending) //calls to the background cancellation event 
                    {
                        copyingWorker.Cancel = true;
                        return;
                    }
                    count++;
                    //inform the progress bar of how copying is progressing 
                    copyingBackgroundWorkerThread.ReportProgress(count);

                    //call recurtion 
                    ResursiveCopy(copyingBackgroundWorkerThread, copyingWorker, folder, dest);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion



    }
}
