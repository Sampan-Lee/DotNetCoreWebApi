using CoreApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Tools
{
    public static class ConfigHelper
    {
        private readonly static IConfiguration Configuration;

        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();
        }

        public static T GetSection<T>(string key) where T : class, new()
        {
            var section = Configuration.GetSection(key);
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<T>(section)
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return obj;
        }
        //public static Config GetSection()
        //{
        //    var obj = new ServiceCollection()
        //        .AddOptions()
        //        .Configure<Config>(Configuration.)
        //        .BuildServiceProvider()
        //        .GetService<IOptions<T>>()
        //        .Value;
        //    return obj;
        //}

        public static string GetSection(string key)
        {
            return Configuration.GetValue<string>(key);
        }
    }
}
