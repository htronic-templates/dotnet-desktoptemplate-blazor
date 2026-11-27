using Microsoft.Extensions.DependencyInjection;
using Desktop2.App.Services;
using BlazorBlueprint.Components;

namespace Desktop2.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorBlueprintDemo(this IServiceCollection services)
    {
        // Add all BlazorBlueprint services (Primitives + Components + Theme)
        services.AddBlazorBlueprintComponents(configureTheme: options =>
        {
            options.DefaultBaseColor = BaseColor.Zinc;
            options.DetectSystemPreference = true;
        });

        // Add collapsible state service for menu state persistence
        services.AddScoped<CollapsibleStateService>();

        // Add mock data service for generating demo data
        services.AddSingleton<MockDataService>();

        return services;
    }
}
