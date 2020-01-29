using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StorjTardigradeWindowsGui
{
    public class CLIUplink
    {
        string filename;
        public CLIUplink(string path = ".\\uplink_windows_amd64.exe")
        {
            this.filename = path;
        }

        public void test(string cmd)
        {
            List<String> outp = this.RunCommand(cmd);
            Console.WriteLine("==============================");
            foreach (var line in outp)
                Console.WriteLine(line);
            Console.WriteLine("==============================\n");
        }

        private List<String> RunCommand(string cmd, bool RedirectStandardOutput = true)
        {
            Console.WriteLine(this.filename);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = this.filename;
            p.StartInfo.Arguments = cmd;
            p.StartInfo.RedirectStandardOutput = RedirectStandardOutput;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            p.Start();

            if (RedirectStandardOutput)
            {
                p.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return this.ParseOutput(output);
            }
            else
                p.WaitForExit();
            return null;
        }

        private List<String> ParseOutput(string outp)
        {
            List<String> data = new List<String>();
            foreach (string elt in outp.Split('\n'))
                if (elt.Trim().Length > 0)
                    data.Add(elt.Trim());

            return data;
        }

        private string[] CleanOutputLine(string line)
        {
            line = Regex.Replace(
                line.Trim(),
                @"\s+",
                " ",
                RegexOptions.IgnorePatternWhitespace);
            return (line).Split(' ');
        }

        private void ParseLsOutput(Item parent, List<string> lines)
        {
            foreach (string line in lines)
                ParseItemLine(parent, line, parent.GetPath());
        }

        private Item ParseItemLine(Item parent, string line, string root=null)
        {
            string[] _t = this.CleanOutputLine(line);
            Item item;
            string name;

            switch(_t[0])
            {
                // Bucket
                case "BKT":
                    name = Tools.JoinArrayBetweenIndexes(_t, 3);
                    item = new Bucket(name);
                    break;

                // File
                case "OBJ":
                    name = Tools.JoinArrayBetweenIndexes(_t, 4);
                    item = new File(root, name, _t[3], _t[1] + " " + _t[2]);
                    break;

                // Folder
                case "PRE":
                    name = Tools.SubString(Tools.JoinArrayBetweenIndexes(_t, 1), 0, -1);
                    item = new Folder(root, name);
                    break;

                default:
                    return null;
            }

            parent.AddChild(item);
            return item;
        }

        public void AuthenticateCLIUplink()
        {
            string cmd = "setup";
            this.RunCommand(cmd, false);
        }

        public bool IsRegistered()
        {
            string cmd = "access inspect";
            List<String> outp = this.RunCommand(cmd);
            Console.WriteLine("Out", outp);
            if (outp.Count == 0)
                return false;
            return true;
        }

        public int List(Item root)
        {
            string cmd = "ls";
            if (root.GetPath().Length > 0)
                cmd += " \"" + root.GetPath() + "\"";

            List<String> outp = this.RunCommand(cmd);

            root.ResetChildsList();
            this.ParseLsOutput(root, outp);

            return outp.Count;
        }

        public bool CreateBucket(string name)
        {
            string cmd = "mb \"" + Tools.FormatBucketName(name) + "\"";
            List<String> outp = this.RunCommand(cmd);
            if (outp.Count == 0)
                return false;
            return true;
        }

        public bool DeleteBucket(string name)
        {
            string cmd = "rb \"" + Tools.FormatBucketName(name) + "\"";
            List<String> outp = this.RunCommand(cmd);
            if (outp.Count == 0)
                return false;
            return true;
        }

        public void UploadToBucket(string bucket, string localFilename, string distantFilename = "")
        {
            this.Copy(localFilename, Tools.FormatBucketName(bucket) + distantFilename);
        }

        public void DownloadFromBucket(string bucket, string localFilename, string remoteFilename)
        {
            this.Copy(Tools.FormatBucketName(bucket) + remoteFilename, localFilename);
        }

        private void Copy(string from, string to)
        {
            string cmd = "cp \"" + from + "\" \"" + to + "\"";
            this.RunCommand(cmd, false);
        }

        public bool RemoveFromBucket(string bucket, string filename)
        {
            string cmd = "rm \"" + Tools.FormatBucketName(bucket) + filename + "\"";
            List<String> outp = this.RunCommand(cmd);
            if (outp.Count == 0)
                return false;
            return true;
        }
    }
}