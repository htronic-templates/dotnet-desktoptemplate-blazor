using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DesktopAll1.App.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add all demo services via shared extension method
builder.Services.AddBlazorBlueprintDemo();

await builder.Build().RunAsync();
