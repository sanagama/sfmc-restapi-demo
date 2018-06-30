using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace SfmcRestApiDemo
{
    public class Program
    {
        public static int Main(string[] args)
        {
            // Initialize Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("*** REST API Demo for Salesforce Marketing Cloud.");
                var host = BuildWebHost();
                SeedDemoData(host);

                Log.Information("*** Starting Web Host...");
                host.Run();
                Log.Information("*** Web Host exited.");
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "*** Host terminated unexpectedly, examine exception.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void SeedDemoData(IWebHost host)
        {
            Log.Information("Seeding demo data...");

            // Add seed data for the demo
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SfmcContext>();
                SfmcDemoInitializer initializer = new SfmcDemoInitializer(context);
                initializer.Initialize();
            }
        }

        private static IWebHost BuildWebHost()
        {
            Log.Information("Building Web Host...");
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000") // listen on port 5000 on all network interfaces
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSerilog()
                .UseSerilog()
                .UseStartup<Startup>()
                .Build();
            
            return host;
        }
    }
}
