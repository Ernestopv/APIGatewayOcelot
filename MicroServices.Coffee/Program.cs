// // <copyright file="Program.cs" company="The AA(Ireland) Limited">
// // Copyright (c) The AA(Ireland) Limited. All rights reserved.
// // </copyright>

namespace MicroServices.Coffee
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Program app
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main app
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// App host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}