using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.ModuloAtivo.Api
{
    public class GetValueJsonAppSettings
    {
        public static string GetValue(string key)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())//AppDomain.CurrentDomain.BaseDirectory
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.GetSection(key).Value;
        }
    }
}
