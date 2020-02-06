namespace StorjTardigradeWindowsGui
{
    partial class MainGUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.title = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.groupManageBuckets = new System.Windows.Forms.GroupBox();
            this.buttonCreateBucket = new System.Windows.Forms.Button();
            this.buttonListBuckets = new System.Windows.Forms.Button();
            this.bucketContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.textBoxLogOutput = new System.Windows.Forms.RichTextBox();
            this.bucketControls = new System.Windows.Forms.GroupBox();
            this.labelTotalSize = new System.Windows.Forms.Label();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.labelFileDate = new System.Windows.Forms.Label();
            this.buttonBucketListFiles = new System.Windows.Forms.Button();
            this.buttonDeleteBucket = new System.Windows.Forms.Button();
            this.buttonRetrieveFile = new System.Windows.Forms.Button();
            this.buttonBucketRemoveFile = new System.Windows.Forms.Button();
            this.buttonBucketUploadFile = new System.Windows.Forms.Button();
            this.boxProjectBucketsTree = new System.Windows.Forms.GroupBox();
            this.treeProjectStorageTree = new System.Windows.Forms.TreeView();
            this.groupManageBuckets.SuspendLayout();
            this.groupOutput.SuspendLayout();
            this.bucketControls.SuspendLayout();
            this.boxProjectBucketsTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.title.Location = new System.Drawing.Point(324, 9);
            this.title.Name = "title";
            this.title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.title.Size = new System.Drawing.Size(474, 48);
            this.title.TabIndex = 0;
            this.title.Text = "Storj Uplink GUI";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAuthor
            // 
            this.labelAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(1002, 589);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(102, 17);
            this.labelAuthor.TabIndex = 1;
            this.labelAuthor.Text = "by Carlotronics";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupManageBuckets
            // 
            this.groupManageBuckets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupManageBuckets.Controls.Add(this.buttonCreateBucket);
            this.groupManageBuckets.Controls.Add(this.buttonListBuckets);
            this.groupManageBuckets.Location = new System.Drawing.Point(12, 60);
            this.groupManageBuckets.Name = "groupManageBuckets";
            this.groupManageBuckets.Size = new System.Drawing.Size(302, 116);
            this.groupManageBuckets.TabIndex = 2;
            this.groupManageBuckets.TabStop = false;
            this.groupManageBuckets.Text = "Manage buckets";
            // 
            // buttonCreateBucket
            // 
            this.buttonCreateBucket.Location = new System.Drawing.Point(166, 47);
            this.buttonCreateBucket.Name = "buttonCreateBucket";
            this.buttonCreateBucket.Size = new System.Drawing.Size(112, 48);
            this.buttonCreateBucket.TabIndex = 0;
            this.buttonCreateBucket.Text = "Create bucket";
            this.buttonCreateBucket.UseVisualStyleBackColor = true;
            this.buttonCreateBucket.Click += new System.EventHandler(this.buttonCreateBucket_Click);
            // 
            // buttonListBuckets
            // 
            this.buttonListBuckets.Location = new System.Drawing.Point(26, 47);
            this.buttonListBuckets.Name = "buttonListBuckets";
            this.buttonListBuckets.Size = new System.Drawing.Size(112, 48);
            this.buttonListBuckets.TabIndex = 0;
            this.buttonListBuckets.Text = "List buckets";
            this.buttonListBuckets.UseVisualStyleBackColor = true;
            this.buttonListBuckets.Click += new System.EventHandler(this.buttonListBuckets_Click);
            // 
            // bucketContextMenu
            // 
            this.bucketContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bucketContextMenu.Name = "bucketContextMenu";
            this.bucketContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // groupOutput
            // 
            this.groupOutput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupOutput.Controls.Add(this.textBoxLogOutput);
            this.groupOutput.Location = new System.Drawing.Point(664, 60);
            this.groupOutput.Name = "groupOutput";
            this.groupOutput.Size = new System.Drawing.Size(440, 526);
            this.groupOutput.TabIndex = 3;
            this.groupOutput.TabStop = false;
            this.groupOutput.Text = "Output";
            // 
            // textBoxLogOutput
            // 
            this.textBoxLogOutput.Location = new System.Drawing.Point(7, 21);
            this.textBoxLogOutput.Name = "textBoxLogOutput";
            this.textBoxLogOutput.ReadOnly = true;
            this.textBoxLogOutput.Size = new System.Drawing.Size(427, 499);
            this.textBoxLogOutput.TabIndex = 1;
            this.textBoxLogOutput.Text = "";
            this.textBoxLogOutput.TextChanged += new System.EventHandler(this.event_textBoxLogOutput_changed);
            // 
            // bucketControls
            // 
            this.bucketControls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bucketControls.Controls.Add(this.labelTotalSize);
            this.bucketControls.Controls.Add(this.labelFileSize);
            this.bucketControls.Controls.Add(this.labelFileDate);
            this.bucketControls.Controls.Add(this.buttonBucketListFiles);
            this.bucketControls.Controls.Add(this.buttonDeleteBucket);
            this.bucketControls.Controls.Add(this.buttonRetrieveFile);
            this.bucketControls.Controls.Add(this.buttonBucketRemoveFile);
            this.bucketControls.Controls.Add(this.buttonBucketUploadFile);
            this.bucketControls.Location = new System.Drawing.Point(12, 182);
            this.bucketControls.Name = "bucketControls";
            this.bucketControls.Size = new System.Drawing.Size(302, 255);
            this.bucketControls.TabIndex = 4;
            this.bucketControls.TabStop = false;
            this.bucketControls.Text = "Bucket:";
            // 
            // labelTotalSize
            // 
            this.labelTotalSize.AutoSize = true;
            this.labelTotalSize.Location = new System.Drawing.Point(97, 157);
            this.labelTotalSize.Name = "labelTotalSize";
            this.labelTotalSize.Size = new System.Drawing.Size(97, 17);
            this.labelTotalSize.TabIndex = 3;
            this.labelTotalSize.Text = "labelTotalSize";
            this.labelTotalSize.Visible = false;
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Location = new System.Drawing.Point(18, 216);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(87, 17);
            this.labelFileSize.TabIndex = 2;
            this.labelFileSize.Text = "labelFileSize";
            this.labelFileSize.Visible = false;
            // 
            // labelFileDate
            // 
            this.labelFileDate.AutoSize = true;
            this.labelFileDate.Location = new System.Drawing.Point(18, 191);
            this.labelFileDate.Name = "labelFileDate";
            this.labelFileDate.Size = new System.Drawing.Size(90, 17);
            this.labelFileDate.TabIndex = 2;
            this.labelFileDate.Text = "labelFileDate";
            this.labelFileDate.Visible = false;
            // 
            // buttonBucketListFiles
            // 
            this.buttonBucketListFiles.Enabled = false;
            this.buttonBucketListFiles.Location = new System.Drawing.Point(21, 23);
            this.buttonBucketListFiles.Name = "buttonBucketListFiles";
            this.buttonBucketListFiles.Size = new System.Drawing.Size(112, 48);
            this.buttonBucketListFiles.TabIndex = 0;
            this.buttonBucketListFiles.Text = "List files";
            this.buttonBucketListFiles.UseVisualStyleBackColor = true;
            this.buttonBucketListFiles.Click += new System.EventHandler(this.event_ListBucketFiles);
            // 
            // buttonDeleteBucket
            // 
            this.buttonDeleteBucket.Enabled = false;
            this.buttonDeleteBucket.Location = new System.Drawing.Point(166, 191);
            this.buttonDeleteBucket.Name = "buttonDeleteBucket";
            this.buttonDeleteBucket.Size = new System.Drawing.Size(112, 48);
            this.buttonDeleteBucket.TabIndex = 0;
            this.buttonDeleteBucket.Text = "Delete bucket";
            this.buttonDeleteBucket.UseVisualStyleBackColor = true;
            this.buttonDeleteBucket.Click += new System.EventHandler(this.event_DeleteBucket);
            // 
            // buttonRetrieveFile
            // 
            this.buttonRetrieveFile.Enabled = false;
            this.buttonRetrieveFile.Location = new System.Drawing.Point(166, 89);
            this.buttonRetrieveFile.Name = "buttonRetrieveFile";
            this.buttonRetrieveFile.Size = new System.Drawing.Size(112, 48);
            this.buttonRetrieveFile.TabIndex = 0;
            this.buttonRetrieveFile.Text = "Download file";
            this.buttonRetrieveFile.UseVisualStyleBackColor = true;
            this.buttonRetrieveFile.Click += new System.EventHandler(this.event_DownloadFileFromBucket);
            // 
            // buttonBucketRemoveFile
            // 
            this.buttonBucketRemoveFile.Enabled = false;
            this.buttonBucketRemoveFile.Location = new System.Drawing.Point(166, 23);
            this.buttonBucketRemoveFile.Name = "buttonBucketRemoveFile";
            this.buttonBucketRemoveFile.Size = new System.Drawing.Size(112, 48);
            this.buttonBucketRemoveFile.TabIndex = 0;
            this.buttonBucketRemoveFile.Text = "Remove file";
            this.buttonBucketRemoveFile.UseVisualStyleBackColor = true;
            this.buttonBucketRemoveFile.Click += new System.EventHandler(this.event_RemoveFileFromBucket);
            // 
            // buttonBucketUploadFile
            // 
            this.buttonBucketUploadFile.Enabled = false;
            this.buttonBucketUploadFile.Location = new System.Drawing.Point(21, 89);
            this.buttonBucketUploadFile.Name = "buttonBucketUploadFile";
            this.buttonBucketUploadFile.Size = new System.Drawing.Size(112, 48);
            this.buttonBucketUploadFile.TabIndex = 0;
            this.buttonBucketUploadFile.Text = "Upload file";
            this.buttonBucketUploadFile.UseVisualStyleBackColor = true;
            this.buttonBucketUploadFile.Click += new System.EventHandler(this.event_UploadFileToBucket);
            // 
            // boxProjectBucketsTree
            // 
            this.boxProjectBucketsTree.Controls.Add(this.treeProjectStorageTree);
            this.boxProjectBucketsTree.Location = new System.Drawing.Point(313, 60);
            this.boxProjectBucketsTree.Name = "boxProjectBucketsTree";
            this.boxProjectBucketsTree.Size = new System.Drawing.Size(352, 526);
            this.boxProjectBucketsTree.TabIndex = 1;
            this.boxProjectBucketsTree.TabStop = false;
            this.boxProjectBucketsTree.Text = "My buckets";
            this.boxProjectBucketsTree.Visible = false;
            // 
            // treeProjectStorageTree
            // 
            this.treeProjectStorageTree.Location = new System.Drawing.Point(6, 16);
            this.treeProjectStorageTree.Name = "treeProjectStorageTree";
            this.treeProjectStorageTree.PathSeparator = "";
            this.treeProjectStorageTree.Size = new System.Drawing.Size(339, 504);
            this.treeProjectStorageTree.TabIndex = 2;
            // this.treeProjectStorageTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.event_ItemsTreeAfterMouseClick);
            this.treeProjectStorageTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.event_ItemsTreeAfterSelect);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 615);
            this.Controls.Add(this.boxProjectBucketsTree);
            this.Controls.Add(this.bucketControls);
            this.Controls.Add(this.groupOutput);
            this.Controls.Add(this.groupManageBuckets);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGUI";
            this.Text = "Storj Uplink GUI";
            this.groupManageBuckets.ResumeLayout(false);
            this.groupOutput.ResumeLayout(false);
            this.bucketControls.ResumeLayout(false);
            this.bucketControls.PerformLayout();
            this.boxProjectBucketsTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.GroupBox groupManageBuckets;
        private System.Windows.Forms.Button buttonListBuckets;
        private System.Windows.Forms.GroupBox groupOutput;
        private System.Windows.Forms.Button buttonCreateBucket;
        private System.Windows.Forms.GroupBox bucketControls;
        private System.Windows.Forms.ContextMenuStrip bucketContextMenu;
        private System.Windows.Forms.Button buttonBucketListFiles;
        private System.Windows.Forms.Button buttonBucketUploadFile;
        private System.Windows.Forms.Button buttonDeleteBucket;
        private System.Windows.Forms.Button buttonBucketRemoveFile;
        private System.Windows.Forms.GroupBox boxProjectBucketsTree;
        private System.Windows.Forms.RichTextBox textBoxLogOutput;
        private System.Windows.Forms.Button buttonRetrieveFile;
        private System.Windows.Forms.Label labelFileDate;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Label labelTotalSize;
        public System.Windows.Forms.TreeView treeProjectStorageTree;
    }
}

