using DesktopTemplate1.App.Extensions;
using DesktopTemplate1.GUI.WebAuto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add all demo services via shared extension method
builder.Services.AddBlazorBlueprintDemo();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(DesktopTemplate1.App.Routes).Assembly,
        typeof(DesktopTemplate1.GUI.WebAuto.Client._Imports).Assembly);

app.Run();
