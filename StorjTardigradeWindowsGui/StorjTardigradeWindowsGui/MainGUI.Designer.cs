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
            this.label2 = new System.Windows.Forms.Label();
            this.groupManageBuckets = new System.Windows.Forms.GroupBox();
            this.groupMyBuckets = new System.Windows.Forms.GroupBox();
            this.listMyBuckets = new System.Windows.Forms.ListView();
            this.buttonCreateBucket = new System.Windows.Forms.Button();
            this.buttonListBuckets = new System.Windows.Forms.Button();
            this.bucketContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.textBoxLogOutput = new System.Windows.Forms.RichTextBox();
            this.bucketControls = new System.Windows.Forms.GroupBox();
            this.boxBucketFiles = new System.Windows.Forms.GroupBox();
            this.listBoxBucketFiles = new System.Windows.Forms.ListBox();
            this.buttonBucketListFiles = new System.Windows.Forms.Button();
            this.buttonDeleteBucket = new System.Windows.Forms.Button();
            this.buttonRetrieveFile = new System.Windows.Forms.Button();
            this.buttonBucketRemoveFile = new System.Windows.Forms.Button();
            this.buttonBucketUploadFile = new System.Windows.Forms.Button();
            this.groupManageBuckets.SuspendLayout();
            this.groupMyBuckets.SuspendLayout();
            this.groupOutput.SuspendLayout();
            this.bucketControls.SuspendLayout();
            this.boxBucketFiles.SuspendLayout();
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1002, 589);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "by Carlotronics";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupManageBuckets
            // 
            this.groupManageBuckets.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupManageBuckets.Controls.Add(this.groupMyBuckets);
            this.groupManageBuckets.Controls.Add(this.buttonCreateBucket);
            this.groupManageBuckets.Controls.Add(this.buttonListBuckets);
            this.groupManageBuckets.Location = new System.Drawing.Point(12, 60);
            this.groupManageBuckets.Name = "groupManageBuckets";
            this.groupManageBuckets.Size = new System.Drawing.Size(302, 526);
            this.groupManageBuckets.TabIndex = 2;
            this.groupManageBuckets.TabStop = false;
            this.groupManageBuckets.Text = "Manage buckets";
            // 
            // groupMyBuckets
            // 
            this.groupMyBuckets.Controls.Add(this.listMyBuckets);
            this.groupMyBuckets.Location = new System.Drawing.Point(7, 168);
            this.groupMyBuckets.Name = "groupMyBuckets";
            this.groupMyBuckets.Size = new System.Drawing.Size(289, 352);
            this.groupMyBuckets.TabIndex = 1;
            this.groupMyBuckets.TabStop = false;
            this.groupMyBuckets.Text = "My buckets";
            this.groupMyBuckets.Visible = false;
            // 
            // listMyBuckets
            // 
            this.listMyBuckets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMyBuckets.HideSelection = false;
            this.listMyBuckets.Location = new System.Drawing.Point(7, 22);
            this.listMyBuckets.MultiSelect = false;
            this.listMyBuckets.Name = "listMyBuckets";
            this.listMyBuckets.Size = new System.Drawing.Size(276, 324);
            this.listMyBuckets.TabIndex = 0;
            this.listMyBuckets.UseCompatibleStateImageBehavior = false;
            this.listMyBuckets.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.event_SelectBucket);
            // 
            // buttonCreateBucket
            // 
            this.buttonCreateBucket.Location = new System.Drawing.Point(26, 113);
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
            this.bucketControls.Controls.Add(this.boxBucketFiles);
            this.bucketControls.Controls.Add(this.buttonBucketListFiles);
            this.bucketControls.Controls.Add(this.buttonDeleteBucket);
            this.bucketControls.Controls.Add(this.buttonRetrieveFile);
            this.bucketControls.Controls.Add(this.buttonBucketRemoveFile);
            this.bucketControls.Controls.Add(this.buttonBucketUploadFile);
            this.bucketControls.Location = new System.Drawing.Point(320, 60);
            this.bucketControls.Name = "bucketControls";
            this.bucketControls.Size = new System.Drawing.Size(338, 526);
            this.bucketControls.TabIndex = 4;
            this.bucketControls.TabStop = false;
            this.bucketControls.Text = "Bucket:";
            this.bucketControls.Visible = false;
            // 
            // boxBucketFiles
            // 
            this.boxBucketFiles.Controls.Add(this.listBoxBucketFiles);
            this.boxBucketFiles.Location = new System.Drawing.Point(6, 174);
            this.boxBucketFiles.Name = "boxBucketFiles";
            this.boxBucketFiles.Size = new System.Drawing.Size(326, 286);
            this.boxBucketFiles.TabIndex = 1;
            this.boxBucketFiles.TabStop = false;
            this.boxBucketFiles.Text = "My buckets";
            this.boxBucketFiles.Visible = false;
            // 
            // listBoxBucketFiles
            // 
            this.listBoxBucketFiles.FormattingEnabled = true;
            this.listBoxBucketFiles.ItemHeight = 16;
            this.listBoxBucketFiles.Location = new System.Drawing.Point(6, 21);
            this.listBoxBucketFiles.Name = "listBoxBucketFiles";
            this.listBoxBucketFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxBucketFiles.Size = new System.Drawing.Size(314, 260);
            this.listBoxBucketFiles.TabIndex = 1;
            this.listBoxBucketFiles.SelectedIndexChanged += new System.EventHandler(this.event_SelectBucketFile);
            // 
            // buttonBucketListFiles
            // 
            this.buttonBucketListFiles.Location = new System.Drawing.Point(21, 47);
            this.buttonBucketListFiles.Name = "buttonBucketListFiles";
            this.buttonBucketListFiles.Size = new System.Drawing.Size(112, 48);
            this.buttonBucketListFiles.TabIndex = 0;
            this.buttonBucketListFiles.Text = "List files";
            this.buttonBucketListFiles.UseVisualStyleBackColor = true;
            this.buttonBucketListFiles.Click += new System.EventHandler(this.event_ListBucketFiles);
            // 
            // buttonDeleteBucket
            // 
            this.buttonDeleteBucket.Location = new System.Drawing.Point(220, 466);
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
            this.buttonRetrieveFile.Location = new System.Drawing.Point(202, 113);
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
            this.buttonBucketRemoveFile.Location = new System.Drawing.Point(202, 47);
            this.buttonBucketRemoveFile.Name = "buttonBucketRemoveFile";
            this.buttonBucketRemoveFile.Size = new System.Drawing.Size(112, 48);
            this.buttonBucketRemoveFile.TabIndex = 0;
            this.buttonBucketRemoveFile.Text = "Remove file";
            this.buttonBucketRemoveFile.UseVisualStyleBackColor = true;
            this.buttonBucketRemoveFile.Click += new System.EventHandler(this.event_RemoveFileFromBucket);
            // 
            // buttonBucketUploadFile
            // 
            this.buttonBucketUploadFile.Location = new System.Drawing.Point(21, 113);
            this.buttonBucketUploadFile.Name = "buttonBucketUploadFile";
            this.buttonBucketUploadFile.Size = new System.Drawing.Size(112, 48);
            this.buttonBucketUploadFile.TabIndex = 0;
            this.buttonBucketUploadFile.Text = "Upload file";
            this.buttonBucketUploadFile.UseVisualStyleBackColor = true;
            this.buttonBucketUploadFile.Click += new System.EventHandler(this.event_UploadFileToBucket);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 615);
            this.Controls.Add(this.bucketControls);
            this.Controls.Add(this.groupOutput);
            this.Controls.Add(this.groupManageBuckets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGUI";
            this.Text = "Storj Uplink GUI";
            this.groupManageBuckets.ResumeLayout(false);
            this.groupMyBuckets.ResumeLayout(false);
            this.groupOutput.ResumeLayout(false);
            this.bucketControls.ResumeLayout(false);
            this.boxBucketFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupManageBuckets;
        private System.Windows.Forms.Button buttonListBuckets;
        private System.Windows.Forms.GroupBox groupOutput;
        private System.Windows.Forms.Button buttonCreateBucket;
        private System.Windows.Forms.GroupBox bucketControls;
        private System.Windows.Forms.GroupBox groupMyBuckets;
        private System.Windows.Forms.ListView listMyBuckets;
        private System.Windows.Forms.ContextMenuStrip bucketContextMenu;
        private System.Windows.Forms.Button buttonBucketListFiles;
        private System.Windows.Forms.Button buttonBucketUploadFile;
        private System.Windows.Forms.Button buttonDeleteBucket;
        private System.Windows.Forms.Button buttonBucketRemoveFile;
        private System.Windows.Forms.GroupBox boxBucketFiles;
        private System.Windows.Forms.ListBox listBoxBucketFiles;
        private System.Windows.Forms.RichTextBox textBoxLogOutput;
        private System.Windows.Forms.Button buttonRetrieveFile;
    }
}

