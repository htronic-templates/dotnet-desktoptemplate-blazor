using DesktopTemplate1.App.Extensions;
using DesktopTemplate1.GUI.WebWasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add all demo services via shared extension method
builder.Services.AddBlazorBlueprintDemo();

await builder.Build().RunAsync();
