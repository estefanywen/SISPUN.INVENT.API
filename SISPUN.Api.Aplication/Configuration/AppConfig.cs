using Microsoft.Extensions.Configuration;
using SISPUN.Api.Aplication.Interface.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.Aplication.Configuration
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int MaxTrys => int.Parse(_configuration.GetSection("Polly:MaxTrys").Value);
        public int SecondsToWait => int.Parse(_configuration.GetSection("Polly:TimeDelay").Value);
        public int CacheExpireInMinutes => int.Parse(_configuration.GetSection("Cache:CacheExpireInMinutes").Value);
        public string ServiceUrl => _configuration.GetSection("ServiceUrl:Url").Value;
    }
}
