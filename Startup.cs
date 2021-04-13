using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace DOTNETCOREConfigurationDemo
{
    public class Startup
    {
        /* added nuget PM
         Microsoft.Extensions.Configuration.EnvironmentVariables
         Microsoft.Extensions.Configuration.FileExtensions
         Microsoft.Extensions.Configuration.Json
         Microsoft.Extensions.Configuration.Binder
        */
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration; 
        public Startup(IHostingEnvironment hostingEnvironment,IConfiguration configuration)
        {
            this.configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                //For different files, having one for each environment allows you to add the environment name into the file name.For example, appsettings.json for the development environment must be called appsettings.Development.json, and appsettings.Production.json would be used for a production environment
                //add below line
                //.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true)
                .Build();
            var config = new Configuration(); builder.Bind(config);

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        // As use of the configuration values across the application, such as the controller, services, and whatever else needs to read the configuration values.
        //Register the instance of configuration class.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory logger)
        {
            logger.CreateLogger("start services");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
