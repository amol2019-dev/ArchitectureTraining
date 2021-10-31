using ArchitectureTraining.Common.Models.Interfaces;
using ArchitectureTraining.Common.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectureTraining.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly ILogger<MerchantController> _logger;
        private readonly IMerchantProvider _merchantProvider;
        public MerchantController(IMerchantProvider merchantProvider, ILogger<MerchantController> logger)
        {
            _merchantProvider = merchantProvider;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return null;
        }

        [HttpPost("[action]")]
        public Task<bool> CreateMerchant(CreateMerchantRequest request)
        {
            return _merchantProvider.CreateMerchant(request);
        }
    }
}
