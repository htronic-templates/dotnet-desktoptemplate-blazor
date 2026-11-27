using BlazorBlueprint.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Desktop3.GUI.WebWasm;

internal static class Program {
    private static async Task Main(string[] args) {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        // Add BlazorBlueprint services to the DI container.
        builder.Services
            .AddBlazorBlueprintComponents();

        // Register the root component for the main window.
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        await builder.Build().RunAsync();
    }
}
