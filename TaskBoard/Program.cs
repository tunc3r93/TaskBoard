using TaskBoard.Components; // Falls du eigene Komponenten hast
using MudBlazor;
using MudBlazor.Services;
using TaskBoard.Services;
using TaskBoard.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IKanbanService, KanbanService>();

// Füge MudBlazor-Dienste hinzu
builder.Services.AddMudServices();  // Hier fügen wir MudBlazor hinzu

// Add Razor Components und Interaktive Server-Komponenten (wenn du das nutzt)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// HTTP-Pipeline konfigurieren
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

// Stellt sicher, dass statische Dateien wie CSS geladen werden
app.UseStaticFiles(); 

// Füge die Razor-Komponenten hinzu
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();