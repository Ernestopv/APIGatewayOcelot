// //
// <copyright file="Startup.cs" company="The AA(Ireland) Limited">
//     // Copyright (c) The AA(Ireland) Limited. All rights reserved. //
// </copyright>

using APIgateway.Ocelot.Aggregators;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIgateway.Ocelot
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Startup app
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration"> App configuration </param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"> App services </param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Metrics working under /metrics-text , /metrics endpoints
            services.AddMetrics();
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
                //options.Filters.Add<NotFoundExceptionFilter>();
            });
            // Adds Swagger documentation for Ocelot
            services.AddSwaggerForOcelot(Configuration, (options) => { options.GenerateDocsForAggregates = true; });

            services.AddResponseCompression();
            //Ocelot service  add request aggregator classes
            services.AddOcelot()
                .AddSingletonDefinedAggregator<CustomerProcessCoffeeAggregator>()
                .AddSingletonDefinedAggregator<CustomerProcessTeaAggregator>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"> App builder </param>
        /// <param name="env"> App environment </param>
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });

            app.UseResponseCompression();
            // UseOcelot
            await app.UseOcelot();
        }
    }
}