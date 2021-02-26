using Entities.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployeesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();
            var config = builder.Services.GetRequiredService<IConfiguration>();
            var connectionString = config.GetConnectionString("identityConnection");
            ConfigureUserData.EnsureSeedData(connectionString);
            builder.Run();
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
