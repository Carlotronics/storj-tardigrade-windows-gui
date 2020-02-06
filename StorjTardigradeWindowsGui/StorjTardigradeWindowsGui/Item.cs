using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorjTardigradeWindowsGui
{
    public abstract class Item
    {
        internal string name;// Example: folder3
        internal string root;// Example: sj://bucket/folder1/folder2/
        // Then, full path would be s;?//bucket/folder1/folder2/folder3/

        internal string CreationDatetime;
        internal System.Windows.Forms.TreeNode Node = null;
        internal System.Windows.Forms.TreeNodeCollection _nodesCollection = null;
        internal bool HasFetchedChilds = false;
        internal Bucket bucket = null;
        internal System.Windows.Forms.ContextMenuStrip contextMenu;

        private List<Item> Childs;

        protected Item(string root, string name)
        {
            this.root = root;
            this.name = name;
            this.Childs = new List<Item>();

            this.InitContextMenu();
        }

        protected Item(string root, string name, string creationDatetime)
        {
            this.root = root;
            this.name = name;
            this.Childs = new List<Item>();
            this.CreationDatetime = creationDatetime;

            this.InitContextMenu();
        }

        private void InitContextMenu()
        {
            if (this is Root)
                return;

            this.contextMenu = new ContextMenuStrip();

            ToolStripMenuItem _item;
            switch (this)
            {
                case Bucket b:
                    _item = new ToolStripMenuItem();
                    _item.Name = "Refresh";
                    _item.Text = "Refresh";
                    // _item.Click
                    // TODO
                    // this.contextMenu.Items.Add(_item);
                    break;

                case Folder fd:
                    _item = new ToolStripMenuItem();
                    _item.Name = "Refresh";
                    _item.Text = "Refresh";
                    // _item.Click
                    // TODO
                    // this.contextMenu.Items.Add(_item);
                    break;

                case File fl:
                    _item = new ToolStripMenuItem();
                    _item.Name = "Download";
                    _item.Text = "Download";
                    _item.Click += new EventHandler(this.DownloadFile);
                    this.contextMenu.Items.Add(_item);
                    break;

                default:
                    break;
            }
        }

        private void DownloadFile(object sender, EventArgs e)
        {
            Program.mainGUI.AddtoLog("To downlowd: " + this.ID());
        }

        public bool AddChild(Item child)
        {
            foreach (Item _c in this.Childs)
                if (_c.GetName() == child.GetName() && _c.GetPath() == _c.GetPath() && _c.GetType() == child.GetType())
                    return false;
            
            // Add to local childs list
            this.Childs.Add(child);

            // Add on Tree
            var t = new System.Windows.Forms.TreeNode(child.GetDisplayText());
            t.Tag = child;
            t.Name = child.GetName();
            if (this is Root)
                this._nodesCollection.Add(t);
            else
                this.Node.Nodes.Add(t);

            child.Node = t;

            Program.mainGUI.event_itemsList_change();

            t.ContextMenuStrip = child.contextMenu;
            
            return true;
        }

        public bool RemoveChild(Item child)
        {
            if (!this.Childs.Contains(child))
                return false;

            if (child.Node != null)
                child.Node.Remove();

            return this.Childs.Remove(child);
        }

        public void ResetChildsList()
        {
            foreach (Item child in this.Childs)
                if (child.Node != null)
                    child.Node.Remove();
            this.Childs.Clear();
        }

        public List<Item> GetChilds()
        {
            return this.Childs;
        }

        public string GetCreationDatetime()
        {
            if (this is Bucket || this is File)
                return this.CreationDatetime;
            return null;
        }

        public string GetName()
        {
            return this.name;
        }

        public override string ToString()
        {
            return this.GetName();
        }

        public string ID()
        {
            return this.GetName() + "; " + this.GetPath() + "; " + this.GetType();
        }

        public abstract string GetPath(bool regardingOverallRoot = true);
        // public abstract string GetName();
        public abstract string GetDisplayText();
    }

    class Root: Item
    {
        public Root() : base("", "") { }

        public override string GetPath(bool regardingOverallRoot = true)
        {
            return this.root;
        }

        public override string GetDisplayText()
        {
            throw new NotImplementedException();
        }
    }

    class Bucket: Item
    {
        public Bucket(string name) : base("sj://", name) {}
        public Bucket(string name, string creationDatetime) : base("sj://", name, creationDatetime) { }

        public override string GetPath(bool regardingOverallRoot=true)
        {
            return regardingOverallRoot ? this.GetDisplayText() : "";
        }

        public override string GetDisplayText()
        {
            return this.root + this.name + "/";
        }
    }

    class Folder : Item
    {
        public Folder(string root, string name) : base(root, name) { }
        // public Folder(string root, string name, string creationDatetime) : base(root, name, creationDatetime) { }

        public override string GetPath(bool regardingOverallRoot = true)
        {
            return (regardingOverallRoot
                    ? this.root
                    : Tools.RemoveBucketNameFromPath(this.root))
                + this.GetDisplayText();
        }

        public override string GetDisplayText()
        {
            return this.name + "/";
        }
    }

    class File : Item
    {
        private long size;

        public File(string root, string name, long size) : base(root, name) { this.size = size; }
        public File(string root, string name, string size) : base(root, name) { long.TryParse(size, out this.size); }
        public File(string root, string name, long size, string creationDatetime) : base(root, name, creationDatetime)
        {
            this.size = size;
        }
        public File(string root, string name, string size, string creationDatetime) : base(root, name, creationDatetime) {
            long.TryParse(size, out this.size);
        }

        public override string GetPath(bool regardingOverallRoot = true)
        {
            return this.root + this.GetDisplayText();
        }

        public long GetSize()
        {
            return size;
        }

        public override string GetDisplayText()
        {
            return this.name;
        }
    }
}
