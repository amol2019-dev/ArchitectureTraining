using ArchitectureTraining.Common.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureTraining.Common.Models.Interfaces
{
   public interface IMerchantProvider
    {
        Task<bool> CreateMerchant(CreateMerchantRequest request);
    }
}
