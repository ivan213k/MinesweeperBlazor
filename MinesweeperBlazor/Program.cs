using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Minesweeper_WPF.Core.Abstractions;
using Minesweeper_WPF.Core.Core;
using MinesweeperBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinesweeperBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<IGameConfiguration>(sp => new GameConfiguration(9, 9, 9));
            builder.Services.AddTransient<IGame, Game>();
            builder.Services.AddTransient<IBlazorTimer, BlazorTimer>();
            await builder.Build().RunAsync();
        }
    }
}
