using EcommerceWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using Blazored.Toast;

using EcommerceWebAssembly.Services.Contract;
using EcommerceWebAssembly.Services.Implementation;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5246/api/") });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<ICategoryServices,CategoryServices>();
builder.Services.AddScoped<IProductServices,ProductServices>();
builder.Services.AddScoped<ICartServices,CartServices>();
builder.Services.AddScoped<ISaleServices,SaleServices>();
builder.Services.AddScoped<IDashboardServices,DashboardServices>();

await builder.Build().RunAsync();
