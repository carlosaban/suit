using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace SUIT
{
    public static class AppConfig
    {
    //    public static IConfigurationRoot Config => LazyConfig.Value;



    //    private static readonly Lazy<IConfigurationRoot> LazyConfig = new Lazy<IConfigurationRoot>(() => new ConfigurationBuilder()
    //        .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
    //        .AddJsonFile("appsettings.json")
    //        //       .AddJsonFile("config.json")
    //        .Build());

        public static readonly string DbConnection = ConfigurationManager.ConnectionStrings["pagosapp"].ConnectionString; /*Config["ConnectionStrings:DefaultConnection"];*/
    }
}
