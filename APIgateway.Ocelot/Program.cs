// //
// <copyright file="Program.cs" company="The AA(Ireland) Limited">
//     // Copyright (c) The AA(Ireland) Limited. All rights reserved. //
// </copyright>

using Microsoft.Extensions.Configuration;
using System.IO;

namespace APIgateway.Ocelot
{
    using App.Metrics.AspNetCore;
    using App.Metrics.Formatters.Prometheus;
    using global::Ocelot.DependencyInjection;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using MMLib.SwaggerForOcelot.DependencyInjection;

    public class Program
    {
        /// <summary>
        /// App main
        /// </summary>
        /// <param name="args"> </param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// App host builder
        /// </summary>
        /// <param name="args"> </param>
        /// <returns> </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.AddOcelot("OcelotEndpoints", hostingContext.HostingEnvironment)
                        .AddOcelotWithSwaggerSupport((o) =>
                        {
                            o.Folder = "OcelotEndpoints";
                        }).AddEnvironmentVariables();

                    });
                }).UseMetricsWebTracking().UseMetrics(options =>
                {
                    options.EndpointOptions = endpointsOptions =>
                    {
                        endpointsOptions.MetricsTextEndpointOutputFormatter =
                            new MetricsPrometheusTextOutputFormatter();
                        endpointsOptions.MetricsEndpointOutputFormatter =
                            new MetricsPrometheusProtobufOutputFormatter();
                    };
                    //}).ConfigureAppConfiguration((hostingContext, config) =>
                    //{
                    //    var builder = new ConfigurationBuilder()
                    //        .SetBasePath(Directory.GetCurrentDirectory())
                    //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    //    var isDockerEnabled = bool.Parse(builder.Build().GetSection("isDockerEnabled").Value);
                    //    if (isDockerEnabled)
                    //    {
                    //        config.AddJsonFile("ocelot.json")
                    //            .AddEnvironmentVariables();
                    //    }
                    //    else
                    //    {
                    //        config.AddJsonFile("ocelot.development.json")
                    //            .AddEnvironmentVariables();
                    //    }
                    //});
                });
    }
}