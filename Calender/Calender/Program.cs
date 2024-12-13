using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using System;
using Calender;
using Calender.Services;

namespace Calender
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Build the WebAssembly host
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Register the root components
            builder.RootComponents.Add<App>("#app");           // Main component for the app
            builder.RootComponents.Add<HeadOutlet>("head::after");  // Adds a head outlet for adding content after the <head> tag

            // Register HttpClient as a scoped service for dependency injection
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Build and run the WebAssembly application
            await builder.Build().RunAsync();
        }
    }
}
