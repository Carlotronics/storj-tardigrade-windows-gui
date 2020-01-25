﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CLIUplink
{
    string filename;
	public CLIUplink(string path= ".\\uplink_windows_amd64.exe")
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

    private List<String> RunCommand(string cmd, bool RedirectStandardOutput=true)
    {
        Console.WriteLine(this.filename);
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        // System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        p.StartInfo.FileName = this.filename;
        p.StartInfo.Arguments = cmd;
        // p.StartInfo = startInfo;
        p.StartInfo.RedirectStandardOutput = RedirectStandardOutput;
        p.StartInfo.UseShellExecute = false;
        p.Start();

        /*
        string q = "";
        while (!p.HasExited)
        {
            q += p.StandardOutput.ReadToEnd();
        }

        return q;
        */

        if(RedirectStandardOutput)
        {
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return this.ParseOutput(output);
        }
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

    public List<Dictionary<string, string>> ListBuckets()
    {
        string cmd = "ls";
        List<String> outp = this.RunCommand(cmd);

        List<Dictionary<string, string>> final = new List<Dictionary<string, string>>();
        foreach (string line in outp)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            string[] _t = this.CleanOutputLine(line);

            d.Add("type", _t[0]);
            d.Add("creation_datetime", _t[1] + " " + _t[2]);
            string _name = _t[3];
            for (int i = 4; i < _t.Length; ++i)
                if(_t[i].Trim().Length > 0)
                    _name += " " + _t[i];
            d.Add("name", _name);

            final.Add(d);
        }

        return final;
    }

    public List<Dictionary<string, string>> ListFilesInBucket(string bucketName)
    {
        string cmd = "ls sj://" + bucketName + "/";
        List<String> outp = this.RunCommand(cmd);

        List<Dictionary<string, string>> final = new List<Dictionary<string, string>>();
        foreach (string line in outp)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            string[] _t = this.CleanOutputLine(line);

            d.Add("type", _t[0]);
            d.Add("creation_datetime", _t[1] + " " + _t[2]);
            d.Add("size", _t[3]);
            string _name = _t[4];
            for (int i = 5; i < _t.Length; ++i)
                if (_t[i].Trim().Length > 0)
                    _name += " " + _t[i];
            d.Add("name", _name);

            final.Add(d);
        }

        return final;
    }
    
    public bool CreateBucket(string name)
    {
        string cmd = "mb sj://" + name + "/";
        List<String> outp = this.RunCommand(cmd);
        if (outp.Count == 0)
            return false;
        return true;
    }
    
    public bool DeleteBucket(string name)
    {
        string cmd = "rb sj://" + name + "/";
        List<String> outp = this.RunCommand(cmd);
        if (outp.Count == 0)
            return false;
        return true;
    }

    // TODO
    public void UploadToBucket()
    { }

    // TODO
    public void RemoveFromBucket()
    { }
} 