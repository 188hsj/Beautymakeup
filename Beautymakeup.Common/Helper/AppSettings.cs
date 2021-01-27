using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Beautymakeup.Common.Helper
{
    /// <summary>
    /// appsetting.json 操作类
    /// </summary>
  public class AppSettings
    {
        public static IConfiguration Configuration { get; set; }
        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            string sqlString2 = Configuration["Logging:LogLevel:Default"];
        }

        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static string app(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch(Exception)
            {

            }
            return "";
        }

        public static List<T> app<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            Configuration.Bind(string.Join(":",sections),list);
            return list;
        }
    }
}
