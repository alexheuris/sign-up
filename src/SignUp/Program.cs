using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace SignUp
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var certPassword = Environment.GetEnvironmentVariable("CERT_PASSWORD");

            var host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.UseHttps(new X509Certificate2(@"cert.pfx", certPassword));
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001")
                .Build();

            host.Run();
        }
    }
}
