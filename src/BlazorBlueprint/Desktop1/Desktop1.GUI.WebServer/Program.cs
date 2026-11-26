using BlazorBlueprint.Components;

namespace Desktop1.GUI.WebServer;

internal static class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Add BlazorBlueprint services to the DI container.
        builder.Services
            .AddBlazorBlueprintComponents();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapStaticAssets();
        app.MapRazorComponents<RootPage>()
            .AddInteractiveServerRenderMode()
            .AddAdditionalAssemblies(typeof(Desktop1.App.Root).Assembly);
        app.Run();
    }
}


