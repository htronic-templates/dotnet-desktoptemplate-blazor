using BlazorBlueprint.Components;
using DesktopTemplate1.App.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;

namespace DesktopTemplate1.GUI.PhotinoX;

internal static class Program {
    [STAThread]
    private static void Main(string[] args) {
        var appBuilder = PhotinoBlazorApp.CreateBuilder(args);
        appBuilder.Services
            .AddLogging();

        // Add BlazorBlueprint services to the DI container.
        appBuilder.Services
            .AddBlazorBlueprintComponents();
        // Add all demo services via shared extension method
        appBuilder.Services.AddBlazorBlueprintDemo();

        // Register the root component for the main window.
        appBuilder.RootComponents.Add<App>("#app");

        var app = appBuilder.Build();

        // Customize the native Photino window.
        app.MainBlazorWindow.Window
            // These need to be done differently for a desktop app
            .SetIconFile("favicon.ico")
            .SetTitle("Blazor Blueprint Demo (PhotinoX)");

        AppDomain.CurrentDomain.UnhandledException += (_, error) => app.MainBlazorWindow.Window.ShowMessage("Fatal exception", error.ExceptionObject?.ToString() ?? "Unknown fatal exception.");

        app.Run();
    }

}
