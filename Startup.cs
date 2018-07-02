using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SfmcRestApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace SfmcRestApiDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        //public Startup(IConfiguration configuration)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors();

            // Add API versioning
            services.AddApiVersioning( o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(2, 0);
            });

            // Lower-case URLs
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            })
            .AddJsonOptions(options =>
            {
                // handle loops correctly
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                // use standard name conversion of properties
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            // Create and use a local Sqlite DB for this demo
            services.AddDbContext<SfmcContext>(options =>
            {
                options.UseSqlite("Data Source=./Data/SfmcRestApiDemo.db");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Serve default page
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Enable CORS
            app.UseCors(options => 
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowCredentials();
            });

            app.UseMvc();
        }
    }
}
