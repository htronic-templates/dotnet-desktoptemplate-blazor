using BlazorBlueprint.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Desktop1.GUI.WebAuto.Client;

internal static class Program {
    [STAThread]
    private static async Task Main(string[] args) {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        // Add BlazorBlueprint services to the DI container.
        builder.Services
            .AddBlazorBlueprintComponents();

        await builder.Build().RunAsync();
    }
}
