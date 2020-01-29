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

        private TreeNode currentNode;
        private Item currentItem;

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


        public async void event_ItemsTreeAfterSelect(object obj, TreeViewEventArgs e)
        {
            currentNode = this.treeProjectStorageTree.SelectedNode;
            currentItem = (Item)currentNode.Tag;

            switch(currentItem.GetType().Name)
            {
                case "Bucket":
                case "Folder":
                    if (!currentItem.HasFetchedChilds)
                    {
                        await this.ListFiles(currentItem);
                        currentItem.HasFetchedChilds = true;
                    }
                    break;

                case "File":
                    break;

                default:
                    return;
            }
        }

        public async Task ListFiles(Item item, TreeNodeCollection NodesList = null)
        {
            await Program.Uplink.ListItems(item);

            NodesList = NodesList == null ? item.Node.Nodes : NodesList;

            NodesList.Clear();
            foreach (Item child in item.GetChilds())
            {
                child.Node = AddChildToNode(NodesList, child);
                switch(child.GetType().Name)
                {
                    case "Bucket":
                    case "Folder":
                        break;

                    case "File":
                        break;

                    default:
                        break;
                }
            }
        }


        /*
         * 
         * MANAGE BUCKETS
         * 
        */

        public async void RefreshBucketsList()
        {
            Item root = Program.Root;
            // Program.cli.List(root);
            // await Program.Uplink.ListItems(root);
            await ListFiles(root, this.treeProjectStorageTree.Nodes);

            if (root.GetChilds().Count > 0)
                AddtoLog(root.GetChilds().Count.ToString() + " buckets retrieved");
            else
                AddtoLog("No buckets");

            return;

            this.treeProjectStorageTree.Nodes.Clear();
            foreach (Item bucket in root.GetChilds())
            {
                bucket.Node = AddBucketToList(bucket);
            }

            event_bucketsList_change();
        }

        private TreeNode AddBucketToList(Item bucket)
        {
            /*
            var t = new TreeNode(bucket.GetDisplayText());
            t.Tag = bucket;
            t.Name = bucket.GetName();
            
            this.treeProjectStorageTree.Nodes.Add(t);

            event_bucketsList_change();

            return t;
            */
            return AddChildToNode(this.treeProjectStorageTree.Nodes, bucket);
        }

        private TreeNode AddChildToNode(TreeNodeCollection parentNodeChilds, Item item)
        {
            var t = new TreeNode(item.GetDisplayText());
            t.Tag = item;
            t.Name = item.GetName();

            parentNodeChilds.Add(t);

            event_itemsList_change();

            return t;
        }

        // TODO
        private void event_itemsList_change()
        {
            if (this.treeProjectStorageTree.Nodes.Count > 0)
            {
                this.boxProjectBucketsTree.Show();
            }
            else
            {
                this.boxProjectBucketsTree.Hide();
            }
        }

        private void event_DeleteBucket(object sender, EventArgs e)
        {
            if (DialogBox.Confirm("Delete bucket", "Are you sure you want to delete the \"" + this.currentBucketName + "\" bucket ?", "Yes", "No") == DialogResult.OK)
            {
                bool _v = verbose;
                this.verbose = false;

                // TODO
                /*
                ListBucketFiles();
                if (this.listBoxBucketFiles.Items.Count == 0 || DialogBox.Confirm("Delete files inside bucket", "You are going to permanently delete " + this.listBoxBucketFiles.Items.Count.ToString() + " files. Continue ?", "Yes", "No") == DialogResult.OK)
                {
                    foreach (string file in this.listBoxBucketFiles.Items)
                        Program.cli.RemoveFromBucket(this.currentBucketName, file);

                    if (Program.cli.DeleteBucket(this.currentBucketName))
                    {
                        AddtoLog("Bucket " + this.currentBucketName + " has been succesfully deleted.");
                        this.listMyBuckets.Items.RemoveAt(this.currentBucketIndex);
                        event_bucketsList_change();
                        return;
                    }

                    AddtoLog("An error occured while trying to delete bucket " + this.currentBucketName + ".\nPlease restart the client and try again.");
                }

                verbose = _v;
                */
            }
        }

        private void event_bucketsList_change()
        {
            if (this.treeProjectStorageTree.Nodes.Count > 0)
            {
                this.boxProjectBucketsTree.Show();
            }
            else
            {
                this.boxProjectBucketsTree.Hide();
            }
        }

        private void buttonListBuckets_Click(object sender, EventArgs e)
        {
            RefreshBucketsList();
        }

        private void buttonCreateBucket_Click(object sender, EventArgs e)
        {
            string value = "";
            if (DialogBox.Prompt("New bucket", "Enter new bucket's name :", ref value) == DialogResult.OK)
            {
                if (Program.cli.CreateBucket(value))
                {
                    Bucket bucket = new Bucket(value);
                    AddtoLog("Bucket " + value + " has been succesfully created !");
                    bucket.Node = AddBucketToList(bucket);
                }
                else
                {
                    AddtoLog("An error occured while creating bucket " + value + ". Please try again.");
                }
            }
        }

        private void event_SelectBucket(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
        {
            this.labelTotalSize.Hide();
            this.labelFileDate.Hide();
            this.labelFileSize.Hide();
            this.bucketControls.Hide();
            this.boxProjectBucketsTree.Hide();

            // TODO
            /*
            if (e.IsSelected)
            {
                if(this.listMyBuckets.Items[e.ItemIndex].Text != this.currentBucketName)
                    this.listBoxBucketFiles.Items.Clear();
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
                this.bucketControls.Text = this.groupBucketControls_baseName;
                this.currentBucketName = null;
                this.currentBucketIndex = -1;
            }
            */
        }





        /*
         * 
         * MANAGE BUCKETS FILES
         * 
        */

        private void ListBucketFiles()
        {
            // TODO
            /*
            if (filesList.Count > 0)
            {
                long totalSize = 0;

                AddtoLog(filesList.Count.ToString() + " files for bucket " + currentBucketName);
                this.listBoxBucketFiles.Items.Clear();
                foreach (var file in filesList)
                {
                    string name;
                    file.TryGetValue("name", out name);
                    this.listBoxBucketFiles.Items.Add(name);

                    string _t;
                    long size = -1;
                    if (file.TryGetValue("size", out _t))
                        if (long.TryParse(_t, out size))
                            totalSize += size;
                    if (size == -1)
                        AddtoLog("An error occured while adding size of file \"" + name + "\" to total size.");

                }
                this.boxBucketFiles.Show();
                
                this.labelTotalSize.Text = "" + filesList.Count.ToString() + " file" + (filesList.Count > 1 ? "s" : "") + "; " + Tools.FormatSize(totalSize) + " total";
                this.labelTotalSize.Show();
            }
            else
                AddtoLog("No file for bucket " + this.currentBucketName);

            Program.BucketFiles = filesList;
            */
        }

        private void event_ListBucketFiles(object sender, EventArgs e)
        {
            ListBucketFiles();
        }

        private void event_bucketFilesList_change()
        {
            // TODO
            /*
            if(this.listBoxBucketFiles.Items.Count > 0)
            {
                this.boxBucketFiles.Show();
            }
            else
            {
                this.boxBucketFiles.Hide();
            }
            */
        }

        private void event_RemoveFileFromBucket(object sender, EventArgs e)
        {
            // TODO
            /*
            if (this.listBoxBucketFiles.SelectedItems.Count <= 0)
                return;

            string toDel = String.Join(", ", this.listBoxBucketFiles.SelectedItems.Cast<string>());

            if (DialogBox.Confirm("Delete files from bucket", "Are you sure you want to delete \"" + toDel + "\" ?", "Yes", "No") == DialogResult.OK)
            {
                Dictionary<string, bool> success = new Dictionary<string, bool>();
                bool gl_success = true;

                string[] selected = new string[this.listBoxBucketFiles.SelectedItems.Count];
                this.listBoxBucketFiles.SelectedItems.CopyTo(selected, 0);
                foreach (string name in selected)
                {
                    bool succ = Program.cli.RemoveFromBucket(this.currentBucketName, name);
                    if (succ)
                    {
                        this.listBoxBucketFiles.Items.Remove(name);
                        AddtoLog("File " + name + " has succesfully been deleted from bucket " + currentBucketName + ".");
                    }
                    else
                        AddtoLog("[ ERR ] Error: file " + name + " can't be deleted from bucket " + currentBucketName + ".");
                    success.Add(name, succ);
                    gl_success &= succ;
                }

                // this.ListBucketFiles();
                event_bucketFilesList_change();

                if (gl_success)
                {
                    if (success.Keys.Count > 1)
                        AddtoLog("Files " + toDel + " have been succesfully deleted from bucket " + currentBucketName + ".");
                }
                else
                    AddtoLog("An error occured while trying to delete files " + toDel + ".\nPlease see above logs for more details.");
            }
            */
        }

        private void event_UploadFileToBucket(object sender, EventArgs e)
        {
            // TODO
            /*
            string filepath = DialogBox.FilePrompt("Upload file to bucket \"" + currentBucketName + "\"");
            if (filepath == null)
                return;
            string remoteFilename = Path.GetFileName(filepath);

            if (DialogBox.Prompt("Remote filename", "Please enter remote filename:", ref remoteFilename) == DialogResult.OK)
            {
                Program.cli.UploadToBucket(currentBucketName, filepath, remoteFilename);
                bool _v = verbose;
                this.listBoxBucketFiles.Items.Add(remoteFilename);
                this.event_bucketFilesList_change();

                var _d = new Dictionary<string, string>();
                _d.Add("name", remoteFilename);
                Program.BucketFiles.Add(_d);
                verbose = _v;

                AddtoLog("Succesfully uploaded " + remoteFilename + " to \"" + currentBucketName + "\" bucket.");
            }
            */
        }

        private void event_DownloadFileFromBucket(object sender, EventArgs e)
        {
            // TODO
            /*
            string remoteFilename = (string)this.listBoxBucketFiles.SelectedItem;
            string filepath = DialogBox.FileSavePrompt("Download \"" + remoteFilename + "\"", remoteFilename);
            if (filepath == null)
                return;

            Program.cli.DownloadFromBucket(currentBucketName, filepath, remoteFilename);
            AddtoLog("Succesfully downloaded " + remoteFilename + " to \"" + filepath + "\".");
            */
        }

        private void event_SelectBucketFile(object sender, EventArgs e)
        {
            Console.WriteLine("Selected");

            this.buttonRetrieveFile.Enabled = false;
            this.labelFileDate.Hide();
            this.labelFileSize.Hide();

            // TODO
            /*
            if (this.listBoxBucketFiles.SelectedItems.Count > 0)
                this.buttonBucketRemoveFile.Enabled = true;
            else
                this.buttonBucketRemoveFile.Enabled = false;

            if (this.listBoxBucketFiles.SelectedItems.Count == 1)
            {
                string _t;

                if (Program.BucketFiles[this.listBoxBucketFiles.SelectedIndex].TryGetValue("creation_datetime", out _t))
                {
                    this.labelFileDate.Text = _t;
                    this.labelFileDate.Show();
                }

                Int64 _tt;
                if (Program.BucketFiles[this.listBoxBucketFiles.SelectedIndex].TryGetValue("size", out _t))
                    Console.WriteLine("File size - step 1: " + _t);
                    if (Int64.TryParse(_t, out _tt))
                    {
                        this.labelFileSize.Text = Tools.FormatSize(_tt);
                        this.labelFileSize.Show();
                    }

                this.buttonRetrieveFile.Enabled = true;
            }

            foreach (var item in this.listBoxBucketFiles.SelectedItems)
                break;
            */
        }

        private void OpenFile(string remoteFilename)
        {
            string localFilename = Path.Combine(Path.GetTempPath(), remoteFilename);

            Program.cli.DownloadFromBucket(currentBucketName, localFilename, remoteFilename);

            System.Diagnostics.Process.Start(localFilename);
        }

        private void event_BucketFileDoubleClick(object sender, MouseEventArgs e)
        {
            // TODO
            /*
            if (this.listBoxBucketFiles.SelectedItems.Count == 1)
            {
                string remoteFilename = (string)this.listBoxBucketFiles.SelectedItem;
                this.OpenFile(remoteFilename);
            }
            else
            {
                return;
            }
            */
        }

        private void event_BucketFileKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                // TODO
                /*
                if (this.listBoxBucketFiles.SelectedItems.Count == 1)
                {
                    string remoteFilename = (string)this.listBoxBucketFiles.SelectedItem;
                    this.OpenFile(remoteFilename);
                }
                */
            }
        }





        /*
         * 
         * GLOBAL
         * 
        */

        private void AddtoLog(string s, bool clear = false)
        {
            if (!verbose)
                return;
            if (clear)
                this.textBoxLogOutput.Text = "";
            this.textBoxLogOutput.AppendText(s + "\n");
            Console.WriteLine(s);
        }

        private void event_textBoxLogOutput_changed(object sender, EventArgs e)
        {
            this.textBoxLogOutput.SelectionStart = this.textBoxLogOutput.Text.Length;
            this.textBoxLogOutput.ScrollToCaret();
        }
    }
}
