using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uplink;
using uplink.NET;
using uplink.NET.Services;
using uplink.NET.Exceptions;
using uplink.NET.Interfaces;
using uplink.NET.Models;

namespace StorjTardigradeWindowsGui
{
    public class UplinkWrapper
    {
        private Scope _scope;
        private BucketService bucketService;

        public UplinkWrapper(string satelliteAddress, string APIKey, string encryptionPassphrase)
        {
            Scope.SetTempDirectory(System.IO.Path.GetTempPath());
            this._scope = new Scope(
                APIKey,
                satelliteAddress,
                encryptionPassphrase);
            this.bucketService = new BucketService(_scope);
        }

        async private Task ListBuckets()
        {
            Console.WriteLine("Debug 5");
            BucketListOptions listOptions = new BucketListOptions();
            Console.WriteLine("Debug 6");

            /*var _task = bucketService.ListBucketsAsync(listOptions);
            _task.Wait();
            Console.WriteLine("Debug 7");
            var buckets = _task.Result;
            */
            var buckets = await bucketService.ListBucketsAsync(listOptions);
            
            foreach(BucketInfo bucket in buckets.Items)
            {
                Console.WriteLine(bucket.Created.ToString());
                Bucket _b = new Bucket(bucket.Name, bucket.Created.ToString());
                Program.Root.AddChild(_b);
            }

            // return Program.Root.GetChilds().Count;
        }

        async internal Task ListItems(Item root)
        {
            if (root is Root)
            {
                await ListBuckets();
                return;
            }

            Bucket bucket = root is Bucket ? (Bucket)root : root.bucket;

            // Open bucket
            /*
            Task<BucketRef> _task = bucketService.OpenBucketAsync(bucket.GetName());
            _task.Wait();
            BucketRef _b = _task.Result;
            */
            BucketRef _b = await bucketService.OpenBucketAsync(bucket.GetName());

            // Set list's options
            ObjectService objectService = new ObjectService();
            var _listOptions = new ListOptions();
            _listOptions.Recursive = false;
            _listOptions.Direction = ListDirection.STORJ_AFTER;
            _listOptions.Prefix = root.GetPath(false);

            // Retrieve list
            /*
            Task<ObjectList> _objects = objectService.ListObjectsAsync(_b, _listOptions);
            _objects.Wait();
            ObjectList objects = _objects.Result;
            */
            ObjectList objects = await objectService.ListObjectsAsync(_b, _listOptions);
            
            /*
            Console.WriteLine("Prefix: " + objects.Prefix);
            Console.WriteLine("Bucket: " + objects.Bucket);
            Console.WriteLine("Delimiter: " + _listOptions.Delimiter);
            Console.WriteLine("\n");
            */

            root.ResetChildsList();
            Item child;
            foreach (var obj in objects.Items)
            {
                /*
                Console.WriteLine(obj.Path);
                Console.WriteLine(obj.IsPrefix);
                Console.WriteLine(obj.Size);
                Console.WriteLine(obj.ToString());
                Console.WriteLine();
                */

                // Folder
                if(obj.IsPrefix)
                {
                    child = new Folder(root.GetPath(), Tools.SubString(obj.Path, 0, -1));
                }
                // File
                else
                {
                    child = new File(root.GetPath(), obj.Path, obj.Size, obj.Created.ToString());
                }

                child.bucket = bucket;
                root.AddChild(child);
            }
        }
    }
}
