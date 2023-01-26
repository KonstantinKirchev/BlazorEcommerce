global using BlazorEcommerce.Shared;
global using BlazorEcommerce.Shared.Models;
global using BlazorEcommerce.Shared.Models.ViewModels;
global using BlazorEcommerce.Client.Services.Interfaces;
global using BlazorEcommerce.Client.Services.Implementations;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components;
global using Blazored.LocalStorage;
using BlazorEcommerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();

await builder.Build().RunAsync();
