using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorjTardigradeWindowsGui
{
    public abstract class Item
    {
        internal string name;// Example: folder3
        internal string root;// Example: sj://bucket/folder1/folder2/
        // Then, full path would be s;?//bucket/folder1/folder2/folder3/

        internal string CreationDatetime;
        internal System.Windows.Forms.TreeNode Node = null;
        internal bool HasFetchedChilds = false;
        internal Bucket bucket = null;

        private List<Item> Childs;

        protected Item(string root, string name)
        {
            this.root = root;
            this.name = name;
            this.Childs = new List<Item>();
        }

        protected Item(string root, string name, string creationDatetime)
        {
            this.root = root;
            this.name = name;
            this.Childs = new List<Item>();
            this.CreationDatetime = creationDatetime;
        }

        public bool AddChild(Item child)
        {
            if (!this.Childs.Contains(child))
            {
                this.Childs.Add(child);
                return true;
            }

            return false;
        }

        public void ResetChildsList()
        {
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
