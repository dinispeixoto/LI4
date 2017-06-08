using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using WhatsYummy.DataAPI;

namespace WhatsYummy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Parser p = new Parser();
            //p.Load("restaurant").Wait();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
