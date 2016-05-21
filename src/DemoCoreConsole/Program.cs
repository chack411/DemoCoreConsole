using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace DemoCoreConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int index = 1;
            if (args.Length > 0)
                index = int.Parse(args[0]);

            Task<string> dt = Util.GetData(index);
            dt.Wait();

            Console.WriteLine(dt.Result);

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

        }
    }
}
