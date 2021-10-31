using ArchitectureTraining.Common.Models.Entities;
using ArchitectureTraining.Common.Models.Interfaces;
using Couchbase.KeyValue;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureTraining.Common.Repository
{
    public class MerchantRepository :  RepositoryBase<Merchant>, IMerchantRepository
    {
        public MerchantRepository(ICouchbaseService couchbaseService) :base(couchbaseService)
        {
        }

        public async Task<bool> CreateMerchant(Merchant item)
        {
            string key = GenrateKey(item.Id);
            IMutationResult result = await _couchbaseService.Collection.InsertAsync(key, item);
            return result != null;
        }        
    }
}
