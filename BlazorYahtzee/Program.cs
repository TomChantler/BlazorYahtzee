using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorYahtzee.Data;
using BlazorYahtzee.Services;

namespace BlazorYahtzee
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IScoreService, ScoreService>();
            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

            await builder.Build().RunAsync();
        }
    }
}
