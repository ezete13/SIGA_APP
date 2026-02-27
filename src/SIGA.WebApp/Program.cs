using MudBlazor.Services;
using SIGA.WebApp;
using SIGA.WebApp.Features.Propuestas.CrearPropuestaBorrador.Service;
using SIGA.WebApp.Features.Unidades;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddHttpClient<CrearPropuestaBorradorService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5227");
});
builder.Services.AddHttpClient<UnidadService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5227");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
