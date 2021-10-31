using Couchbase;
using Couchbase.KeyValue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureTraining.Common.Repository
{
    public interface ICouchbaseService
    {
        ICluster Cluster { get; }
        IBucket Bucket { get; }
        ICouchbaseCollection Collection { get; }
        public Task<ICouchbaseCollection> TenantCollection(string tenant, string collection);
    }

    public static class StringExtension
    {
        public static string DefaultIfEmpty(this string str, string defaultValue)
            => string.IsNullOrWhiteSpace(str) ? defaultValue : str;
    }

    public class CouchbaseService : ICouchbaseService
    {
        public ICluster Cluster { get; private set; }
        public IBucket Bucket { get; private set; }
        public ICouchbaseCollection Collection { get; private set; }

        public CouchbaseService()
        {
            // TODO: get these variables via DI, possibly overriding config in appsettings.json
            var CB_HOST = Environment.GetEnvironmentVariable("CB_HOST").DefaultIfEmpty("localhost");
            var CB_USER = Environment.GetEnvironmentVariable("CB_USER").DefaultIfEmpty("Administrator");
            var CB_PSWD = Environment.GetEnvironmentVariable("CB_PSWD").DefaultIfEmpty("Administrator");

            Console.WriteLine(
                $"Connecting to couchbase://{CB_HOST} with {CB_USER} / {CB_PSWD}");

            try
            {
                //var cluster = await Cluster.ConnectAsync("couchbases://" + endpoint, opts);
                //var bucket = await cluster.BucketAsync(bucketName);
                //var collection = bucket.DefaultCollection();

                var task = Task.Run(async () => {
                    var cluster = await Couchbase.Cluster.ConnectAsync(
                        $"couchbase://{CB_HOST}",
                        CB_USER,
                        CB_PSWD);

                    Cluster = cluster;
                    Bucket = await Cluster.BucketAsync("ADVIK_TEST");
                    Collection = Bucket.DefaultCollection();
                    //var inventoryScope = await Bucket.ScopeAsync("inventory");
                    //Collection = await inventoryScope.CollectionAsync("hotel");
                });
                task.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle((x) => throw x);
            }
        }

        public async Task<ICouchbaseCollection> TenantCollection(string tenant, string collection)
        {
            var tenantScope = await Bucket.ScopeAsync(tenant);
            var tenantCollection = await tenantScope.CollectionAsync(collection);
            return tenantCollection;
        }
    }
}
