﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebExtractorCorePortal.Context;
using WebExtractorCorePortal.Data;

namespace WebExtractorCorePortal
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    //CreateWebHostBuilder(args).Build().Run();
        //    var host = CreateWebHost(args);
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        try
        //        {

        //            var serviceProvider = services.GetRequiredService<IServiceProvider>();
        //            var configuration = services.GetRequiredService<IConfiguration>();
        //            var context = services.GetRequiredService<ApplicationDbContext>();
        //            Seed.INTIALIZE_DATABASE_DATA(serviceProvider, configuration, context).Wait();
        //        }
        //        catch (Exception e)
        //        {
        //            var logger = services.GetRequiredService<ILogger<Program>>();
        //            logger.LogError(e, "An error occurred while create roles");
        //        }
        //    }

        //    host.Run();
        //}

        //public static IWebHost CreateWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


    }
}
