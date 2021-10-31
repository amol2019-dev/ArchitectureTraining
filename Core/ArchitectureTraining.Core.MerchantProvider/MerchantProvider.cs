using ArchitectureTraining.Common.Models.Entities;
using ArchitectureTraining.Common.Models.Interfaces;
using ArchitectureTraining.Common.Models.Request;
using System;
using System.Threading.Tasks;

namespace ArchitectureTraining.Core.MerchantProvider
{
    public class MerchantProvider : IMerchantProvider
    {
        private readonly IMerchantRepository _merchantRepository;
        public MerchantProvider(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }
        public Task<bool> CreateMerchant(CreateMerchantRequest request)
        {
            Merchant merchant = new Merchant();
            merchant.MerchantName = request.MerchantName;

            return _merchantRepository.CreateMerchant(merchant);
        }
    }
}
