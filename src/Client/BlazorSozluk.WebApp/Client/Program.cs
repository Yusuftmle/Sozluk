using Blazored.LocalStorage;
using BlazorSozluk.WebApp;
using BlazorSozluk.WebApp.Infrastructure.Auth;
using BlazorSozluk.WebApp.Infrastructure.Services;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorSozluk.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddHttpClient("webApiClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5282");
            })
            .AddHttpMessageHandler<AuthTokenHandler>();//Auth token will be here


			builder.Services.AddScoped(sp =>
            {
                var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                return clientFactory.CreateClient("webApiClient");
            });
            builder.Services.AddScoped<AuthTokenHandler>();
            builder.Services.AddTransient<IEntryService, EntryService>();
			builder.Services.AddTransient<IVoteService, VoteService>();
			builder.Services.AddTransient<IFavService, FavService>();
			builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<IidentityService, IdentityService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            //  builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            
            builder.Services.AddAuthorizationCore();
			await builder.Build().RunAsync();
        }
    }
}