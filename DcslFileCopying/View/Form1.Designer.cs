namespace DcslFileCopying
{
    partial class FrmCopyingUI
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCopyFileLocation = new System.Windows.Forms.TextBox();
            this.btnCopyTo = new System.Windows.Forms.Button();
            this.txtCopyDestination = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBarCopyingFiles = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lstAllFilesFolders = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.CopyingBackgroundWorkerThread = new System.ComponentModel.BackgroundWorker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.lblFolderSize = new System.Windows.Forms.Label();
            this.lblTotalFileSize = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFile.Location = new System.Drawing.Point(25, 102);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(105, 30);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dcsl File Copying";
            // 
            // txtCopyFileLocation
            // 
            this.txtCopyFileLocation.Location = new System.Drawing.Point(153, 102);
            this.txtCopyFileLocation.Multiline = true;
            this.txtCopyFileLocation.Name = "txtCopyFileLocation";
            this.txtCopyFileLocation.Size = new System.Drawing.Size(635, 30);
            this.txtCopyFileLocation.TabIndex = 2;
            // 
            // btnCopyTo
            // 
            this.btnCopyTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyTo.Location = new System.Drawing.Point(25, 254);
            this.btnCopyTo.Name = "btnCopyTo";
            this.btnCopyTo.Size = new System.Drawing.Size(105, 31);
            this.btnCopyTo.TabIndex = 4;
            this.btnCopyTo.Text = "Copy To";
            this.btnCopyTo.UseVisualStyleBackColor = true;
            this.btnCopyTo.Click += new System.EventHandler(this.btnCopyTo_Click);
            // 
            // txtCopyDestination
            // 
            this.txtCopyDestination.Location = new System.Drawing.Point(153, 255);
            this.txtCopyDestination.Multiline = true;
            this.txtCopyDestination.Name = "txtCopyDestination";
            this.txtCopyDestination.Size = new System.Drawing.Size(635, 30);
            this.txtCopyDestination.TabIndex = 5;
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(357, 291);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(164, 35);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy File";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total No Files : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "File Size : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Folder Name : ";
            // 
            // progressBarCopyingFiles
            // 
            this.progressBarCopyingFiles.Location = new System.Drawing.Point(12, 356);
            this.progressBarCopyingFiles.Name = "progressBarCopyingFiles";
            this.progressBarCopyingFiles.Size = new System.Drawing.Size(776, 40);
            this.progressBarCopyingFiles.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Copy Time Elapsed : ";
            // 
            // lstAllFilesFolders
            // 
            this.lstAllFilesFolders.FormattingEnabled = true;
            this.lstAllFilesFolders.ItemHeight = 16;
            this.lstAllFilesFolders.Location = new System.Drawing.Point(153, 148);
            this.lstAllFilesFolders.Name = "lstAllFilesFolders";
            this.lstAllFilesFolders.Size = new System.Drawing.Size(635, 84);
            this.lstAllFilesFolders.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 34);
            this.label6.TabIndex = 13;
            this.label6.Text = "Files and Folders \r\nto be Copied : \r\n";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(389, 72);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(47, 17);
            this.lblErrors.TabIndex = 14;
            this.lblErrors.Text = "Errors";
            // 
            // CopyingBackgroundWorkerThread
            // 
            this.CopyingBackgroundWorkerThread.WorkerReportsProgress = true;
            this.CopyingBackgroundWorkerThread.WorkerSupportsCancellation = true;
            this.CopyingBackgroundWorkerThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CopyingBackgroundWorkerThread_DoWork);
            this.CopyingBackgroundWorkerThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CopyingBackgroundWorkerThread_ProgressChanged);
            this.CopyingBackgroundWorkerThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CopyingBackgroundWorkerThread_RunWorkerCompleted);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(9, 327);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(76, 17);
            this.lblProgress.TabIndex = 15;
            this.lblProgress.Text = "progress%";
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Location = new System.Drawing.Point(139, 427);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(81, 17);
            this.lblFolderName.TabIndex = 16;
            this.lblFolderName.Text = "folderName";
            // 
            // lblFolderSize
            // 
            this.lblFolderSize.AutoSize = true;
            this.lblFolderSize.Location = new System.Drawing.Point(139, 457);
            this.lblFolderSize.Name = "lblFolderSize";
            this.lblFolderSize.Size = new System.Drawing.Size(71, 17);
            this.lblFolderSize.TabIndex = 17;
            this.lblFolderSize.Text = "folderSize";
            // 
            // lblTotalFileSize
            // 
            this.lblTotalFileSize.AutoSize = true;
            this.lblTotalFileSize.Location = new System.Drawing.Point(139, 486);
            this.lblTotalFileSize.Name = "lblTotalFileSize";
            this.lblTotalFileSize.Size = new System.Drawing.Size(35, 17);
            this.lblTotalFileSize.TabIndex = 18;
            this.lblTotalFileSize.Text = "total";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeElapsed.Location = new System.Drawing.Point(527, 486);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(121, 20);
            this.lblTimeElapsed.TabIndex = 19;
            this.lblTimeElapsed.Text = "Time elapsed";
            // 
            // FrmCopyingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 521);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.lblTotalFileSize);
            this.Controls.Add(this.lblFolderSize);
            this.Controls.Add(this.lblFolderName);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstAllFilesFolders);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBarCopyingFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtCopyDestination);
            this.Controls.Add(this.btnCopyTo);
            this.Controls.Add(this.txtCopyFileLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmCopyingUI";
            this.Text = "Copy Directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCopyFileLocation;
        private System.Windows.Forms.Button btnCopyTo;
        private System.Windows.Forms.TextBox txtCopyDestination;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBarCopyingFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstAllFilesFolders;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblErrors;
        private System.ComponentModel.BackgroundWorker CopyingBackgroundWorkerThread;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.Label lblFolderSize;
        private System.Windows.Forms.Label lblTotalFileSize;
        private System.Windows.Forms.Label lblTimeElapsed;
    }
}

