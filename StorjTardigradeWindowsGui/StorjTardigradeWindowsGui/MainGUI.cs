using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorjTardigradeWindowsGui
{
    public partial class MainGUI : Form
    {
        private string groupBucketControls_baseName;
        private string currentBucketName;
        private int currentBucketIndex;
        private bool verbose = true;

        public MainGUI()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InitializeComponent();
#if !DEBUG
                RefreshBucketsList();
#endif
        }

        public void RefreshBucketsList()
        {
            Program.Buckets = Program.cli.ListBuckets();

            if (Program.Buckets.Count > 0)
                AddtoLog(Program.Buckets.Count.ToString() + " buckets retrieved");
            else
                AddtoLog("No buckets");

            this.listMyBuckets.Items.Clear();
            foreach (Dictionary<string, string> bucket in Program.Buckets)
            {
                string name = null;
                bucket.TryGetValue("name", out name);
                if(name != null)
                {
                    /*
                    var t = new ListViewItem(name);
                    this.listMyBuckets.Items.Add(t);
                    */
                    AddBucketToList(name);
                }
            }

            /*
            if (Program.Buckets != null && Program.Buckets.Count > 0)
                this.groupMyBuckets.Show();
            */
            event_bucketsList_change();
        }

        private void AddBucketToList(string name)
        {
            var t = new ListViewItem(name);

            this.listMyBuckets.Items.Add(t);
            // this.groupMyBuckets.Show();
            event_bucketsList_change();
        }

        private void ListBucketFiles()
        {
            List<Dictionary<string, string>> filesList = Program.cli.ListFilesInBucket(this.currentBucketName);

            if (filesList.Count > 0)
            {
                AddtoLog(filesList.Count.ToString() + " files for bucket " + currentBucketName);
                this.listBoxBucketFiles.Items.Clear();
                foreach (var file in filesList)
                {
                    string name;
                    file.TryGetValue("name", out name);
                    this.listBoxBucketFiles.Items.Add(name);
                }
                this.boxBucketFiles.Show();
            }
            else
                AddtoLog("No file for bucket " + this.currentBucketName);
        }

        private void event_ListBucketFiles(object sender, EventArgs e)
        {
            ListBucketFiles();
        }

        private void event_DeleteBucket(object sender, EventArgs e)
        {
            if(DialogBox.Confirm("Delete bucket","Are you sure you want to delete the \""+this.currentBucketName+"\" bucket ?","Yes","No") == DialogResult.OK)
            {
                bool _v = verbose;
                this.verbose = false;
                ListBucketFiles();
                foreach (string file in this.listBoxBucketFiles.Items)
                    Program.cli.RemoveFromBucket(this.currentBucketName, file);
                verbose = _v;

                if (Program.cli.DeleteBucket(this.currentBucketName))
                {
                    AddtoLog("Bucket " + this.currentBucketName + " has been succesfully deleted.");
                    this.listMyBuckets.Items.RemoveAt(this.currentBucketIndex);
                    event_bucketsList_change();
                    return;
                }

                AddtoLog("An error occured while trying to delete bucket " + this.currentBucketName + ".\nPlease restart the client and try again.");
                // AddtoLog("An error occured while trying to delete bucket " + this.currentBucketName + ".\nPlease empty your bucket, restart the client and try again.");
            }
        }

        private void event_bucketFilesList_change()
        {
            if(this.listBoxBucketFiles.Items.Count > 0)
            {
                this.boxBucketFiles.Show();
            }
            else
            {
                this.boxBucketFiles.Hide();
            }
        }

        private void event_bucketsList_change()
        {
            if (this.listMyBuckets.Items.Count > 0)
            {
                this.groupMyBuckets.Show();
            }
            else
            {
                this.groupMyBuckets.Hide();
            }
        }

        private void event_RemoveFileFromBucket(object sender, EventArgs e)
        {
            if (this.listBoxBucketFiles.SelectedItems.Count <= 0)
                return;

            string toDel = String.Join(", ", this.listBoxBucketFiles.SelectedItems.Cast<string>());

            if (DialogBox.Confirm("Delete files from bucket", "Are you sure you want to delete \"" + toDel + "\" ?", "Yes", "No") == DialogResult.OK)
            {
                Dictionary<string, bool> success = new Dictionary<string, bool>();
                bool gl_success = true;
                
                foreach(string name in this.listBoxBucketFiles.SelectedItems)
                {
                    bool succ = Program.cli.RemoveFromBucket(this.currentBucketName, name);
                    if (succ)
                        if(success.Keys.Count > 1)
                            AddtoLog("File " + name + " has succesfully been deleted from bucket " + currentBucketName + ".");
                    else
                        AddtoLog("[ ERR ] Error: file " + name + " can't be deleted from bucket " + currentBucketName + ".");
                    success.Add(name, succ);
                    gl_success &= succ;
                }

                event_bucketFilesList_change();

                if (gl_success)
                    AddtoLog("Files " + toDel + " have been succesfully deleted from bucket " + currentBucketName + ".");
                else
                    AddtoLog("An error occured while trying to delete files " + toDel + ".\nPlease see above logs for more details.");
            }
        }

        private void event_UploadFileToBucket(object sender, EventArgs e)
        {
            string filepath = DialogBox.FilePrompt("Upload file to bucket \"" + currentBucketName + "\"");
            string remoteFilename = Path.GetFileName(filepath);
            if (DialogBox.Prompt("Remote filename", "Please enter remote filename:", ref remoteFilename) == DialogResult.OK)
            {
                Program.cli.UploadToBucket(currentBucketName, filepath, remoteFilename);
                this.listBoxBucketFiles.Items.Add(remoteFilename);
                this.event_bucketFilesList_change();
                AddtoLog("Succesfully uploaded " + remoteFilename + " to \"" + currentBucketName + "\" bucket.");
            }
        }

        private void event_SelectBucket(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
        {
            if(e.IsSelected)
            {
                this.groupBucketControls_baseName = this.bucketControls.Text;
                // Console.WriteLine(this.listMyBuckets.Items[e.ItemIndex].GetType());
                this.currentBucketName = this.listMyBuckets.Items[e.ItemIndex].Text;
                this.currentBucketIndex = e.ItemIndex;
                this.bucketControls.Text += " " + this.currentBucketName;
                this.bucketControls.Show();
                AddtoLog("Selected bucket " + this.currentBucketName);
            }
            else
            {
                this.bucketControls.Hide();
                this.boxBucketFiles.Hide();

                this.bucketControls.Text = this.groupBucketControls_baseName;
                this.currentBucketName = null;
                this.currentBucketIndex = -1;
            }
        }

        private void event_SelectBucketFile(object sender, EventArgs e)
        {
            Console.WriteLine("Selected");

            if (this.listBoxBucketFiles.SelectedItems.Count > 0)
                this.buttonBucketRemoveFile.Enabled = true;
            else
                this.buttonBucketRemoveFile.Enabled = false;

            foreach (var item in this.listBoxBucketFiles.SelectedItems)
                break;
        }

        /*
        private void event_BucketContextMenuClick(object sender, EventArgs e)
        {
            Console.WriteLine("Coucou");
        }
        */

        private void buttonListBuckets_Click(object sender, EventArgs e)
        {
            RefreshBucketsList();
        }

        private void AddtoLog(string s, bool clear=false)
        {
            if (!verbose)
                return;
            if (clear)
                this.textBoxLogOutput.Text = "";
            this.textBoxLogOutput.AppendText(s + "\n");
            Console.WriteLine(s);
        }

        private void buttonCreateBucket_Click(object sender, EventArgs e)
        {
            string value = "";
            if(DialogBox.Prompt("New bucket", "Enter new bucket's name :", ref value) == DialogResult.OK)
            {
                if(Program.cli.CreateBucket(value))
                {
                    AddtoLog("Bucket " + value + " has been succesfully created !");
                    AddBucketToList(value);
                }
                else
                {
                    AddtoLog("An error occured while creating bucket " + value + ". Please try again.");
                }
            }
        }
    }
}
