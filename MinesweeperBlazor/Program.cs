using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Minesweeper_WPF.Core.Abstractions;
using Minesweeper_WPF.Core.Core;
using MinesweeperBlazor.AuthProviders;
using MinesweeperBlazor.Interfaces;
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

            builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri("https://ivan213kminesweeper.herokuapp.com/") });
            builder.Services.AddTransient<IGameConfiguration>(sp => GameSesstings.GameConfiguration);
            builder.Services.AddTransient<IGame, Game>();
            builder.Services.AddTransient<IBlazorTimer, BlazorTimer>();
            builder.Services.AddTransient<IGameLevelsService, GameLevelService>();
            builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            await builder.Build().RunAsync();
        }
    }
}
