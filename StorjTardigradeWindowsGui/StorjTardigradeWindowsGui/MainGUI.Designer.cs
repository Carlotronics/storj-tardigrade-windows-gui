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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupManageBuckets = new System.Windows.Forms.GroupBox();
            this.buttonCreateBucket = new System.Windows.Forms.Button();
            this.buttonListBuckets = new System.Windows.Forms.Button();
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.bucketControls = new System.Windows.Forms.GroupBox();
            this.groupMyBuckets = new System.Windows.Forms.GroupBox();
            this.listMyBuckets = new System.Windows.Forms.ListView();
            this.groupManageBuckets.SuspendLayout();
            this.groupMyBuckets.SuspendLayout();
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
            this.title.Size = new System.Drawing.Size(304, 48);
            this.title.TabIndex = 0;
            this.title.Text = "Storj Uplink GUI";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.title.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(832, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "by Carlotronics";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupManageBuckets
            // 
            this.groupManageBuckets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupManageBuckets.Controls.Add(this.groupMyBuckets);
            this.groupManageBuckets.Controls.Add(this.buttonCreateBucket);
            this.groupManageBuckets.Controls.Add(this.buttonListBuckets);
            this.groupManageBuckets.Location = new System.Drawing.Point(12, 78);
            this.groupManageBuckets.Name = "groupManageBuckets";
            this.groupManageBuckets.Size = new System.Drawing.Size(217, 374);
            this.groupManageBuckets.TabIndex = 2;
            this.groupManageBuckets.TabStop = false;
            this.groupManageBuckets.Text = "Manage buckets";
            // 
            // buttonCreateBucket
            // 
            this.buttonCreateBucket.Location = new System.Drawing.Point(26, 113);
            this.buttonCreateBucket.Name = "buttonCreateBucket";
            this.buttonCreateBucket.Size = new System.Drawing.Size(134, 48);
            this.buttonCreateBucket.TabIndex = 0;
            this.buttonCreateBucket.Text = "Create bucket";
            this.buttonCreateBucket.UseVisualStyleBackColor = true;
            this.buttonCreateBucket.Click += new System.EventHandler(this.buttonCreateBucket_Click);
            // 
            // buttonListBuckets
            // 
            this.buttonListBuckets.Location = new System.Drawing.Point(26, 47);
            this.buttonListBuckets.Name = "buttonListBuckets";
            this.buttonListBuckets.Size = new System.Drawing.Size(134, 48);
            this.buttonListBuckets.TabIndex = 0;
            this.buttonListBuckets.Text = "List buckets";
            this.buttonListBuckets.UseVisualStyleBackColor = true;
            this.buttonListBuckets.Click += new System.EventHandler(this.buttonListBuckets_Click);
            // 
            // groupOutput
            // 
            this.groupOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupOutput.Location = new System.Drawing.Point(579, 78);
            this.groupOutput.Name = "groupOutput";
            this.groupOutput.Size = new System.Drawing.Size(355, 357);
            this.groupOutput.TabIndex = 3;
            this.groupOutput.TabStop = false;
            this.groupOutput.Text = "Output";
            // 
            // bucketControls
            // 
            this.bucketControls.Location = new System.Drawing.Point(235, 78);
            this.bucketControls.Name = "bucketControls";
            this.bucketControls.Size = new System.Drawing.Size(338, 374);
            this.bucketControls.TabIndex = 4;
            this.bucketControls.TabStop = false;
            this.bucketControls.Text = "Bucket";
            // 
            // groupMyBuckets
            // 
            this.groupMyBuckets.Controls.Add(this.listMyBuckets);
            this.groupMyBuckets.Location = new System.Drawing.Point(7, 168);
            this.groupMyBuckets.Name = "groupMyBuckets";
            this.groupMyBuckets.Size = new System.Drawing.Size(200, 189);
            this.groupMyBuckets.TabIndex = 1;
            this.groupMyBuckets.TabStop = false;
            this.groupMyBuckets.Text = "My buckets";
            this.groupMyBuckets.Visible = false;
            // 
            // listMyBuckets
            // 
            this.listMyBuckets.HideSelection = false;
            this.listMyBuckets.Location = new System.Drawing.Point(7, 22);
            this.listMyBuckets.Name = "listMyBuckets";
            this.listMyBuckets.Size = new System.Drawing.Size(187, 161);
            this.listMyBuckets.TabIndex = 0;
            this.listMyBuckets.UseCompatibleStateImageBehavior = false;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 464);
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
    }
}

