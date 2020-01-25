using System;
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
        public MainGUI()
        {
            InitializeComponent();
            RefreshBucketsList();
        }

        public void RefreshBucketsList()
        {
            Program.Buckets = Program.cli.ListBuckets();

            this.listMyBuckets.Items.Clear();
            foreach (Dictionary<string, string> bucket in Program.Buckets)
            {
                string name = null;
                bucket.TryGetValue("name", out name);
                if(name != null)
                {
                    var t = new ListViewItem(name);
                    this.listMyBuckets.Items.Add(t);
                }
            }

            if (Program.Buckets != null && Program.Buckets.Count > 0)
                this.groupMyBuckets.Show();
        }

        private void AddBucketToList(string name)
        {
            this.listMyBuckets.Items.Add(name);
            this.groupMyBuckets.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonListBuckets_Click(object sender, EventArgs e)
        {
            RefreshBucketsList();
        }

        private void AddtoLog(string s, bool clear=false)
        {
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
