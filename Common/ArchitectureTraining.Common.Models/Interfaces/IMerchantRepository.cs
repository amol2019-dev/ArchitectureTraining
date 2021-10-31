using ArchitectureTraining.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureTraining.Common.Models.Interfaces
{
    public interface IMerchantRepository
    {
        Task<bool> CreateMerchant(Merchant item);
    }
}
