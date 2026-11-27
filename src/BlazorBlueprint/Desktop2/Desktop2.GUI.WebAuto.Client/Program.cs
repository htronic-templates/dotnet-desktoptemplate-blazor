using BlazorBlueprint.Components;
using Desktop2.App.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Desktop2.GUI.WebAuto.Client;

internal static class Program {
    private static async Task Main(string[] args) {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        // Add BlazorBlueprint services to the DI container.
        builder.Services
            .AddBlazorBlueprintComponents();
        // Add all demo services via shared extension method
        builder.Services.AddBlazorBlueprintDemo();

        await builder.Build().RunAsync();
    }
}
