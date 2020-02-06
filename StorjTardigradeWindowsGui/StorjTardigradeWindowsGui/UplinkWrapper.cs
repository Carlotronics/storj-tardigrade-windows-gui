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
        }

        public UplinkWrapper(string accessToken)
        {
            Scope.SetTempDirectory(System.IO.Path.GetTempPath());
            this._scope = new Scope(accessToken);
        }

        public bool Init()
        {
            /*
            UplinkConfig uplinkConfig = new UplinkConfig();
            Uplink upl = new Uplink(uplinkConfig);
            Project proj = new Project(upl, _scope.GetAPIKey(), _scope.GetSatelliteAddress());
            */
            this.bucketService = new BucketService(_scope);
            return true;
        }

        async private Task ListBuckets()
        {
            BucketListOptions listOptions = new BucketListOptions();

            /*var _task = bucketService.ListBucketsAsync(listOptions);
            _task.Wait();
            Console.WriteLine("Debug 7");
            var buckets = _task.Result;
            */
            var buckets = await bucketService.ListBucketsAsync(listOptions);

            List<string> retrieved = new List<string>();

            foreach(BucketInfo bucket in buckets.Items)
            {
                Console.WriteLine(bucket.Created.ToString());
                Bucket _b = new Bucket(bucket.Name, bucket.Created.ToString());
                Program.Root.AddChild(_b);

                retrieved.Add(_b.ID());
            }

            Tools.CheckAndRemoveDeletedItems(Program.Root, retrieved);
            // return Program.Root.GetChilds().Count;
        }

        async internal Task ListItems(Item root, bool hardRefresh=false)
        {
            if (hardRefresh)
                root.ResetChildsList();

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
            
            Item child;
            List<string> currentItemsIDs = new List<string>();
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
                currentItemsIDs.Add(child.ID());
            }

            Tools.CheckAndRemoveDeletedItems(root, currentItemsIDs);
        }

        async internal Task<Bucket> CreateBucket(string name)
        {
            BucketConfig bucketConfig = new BucketConfig();
            BucketInfo bucket = await bucketService.CreateBucketAsync("", bucketConfig);

            return null;
        }
    }
}
