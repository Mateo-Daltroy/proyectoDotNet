using UI.Components;
// See https://aka.ms/new-console-template for more information
using Repositorios.Context;
using Aplicacion.entidades;
using Aplicacion.UseCases;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using Repositorios.ImplementacionesRepo;

//_Inicializar Bases de Datos_
IRepositorioReserva repoTempRes = new RepoReservas();
IRepositorioPersona repoTempPers = new RepoPersonas();
//IRepositorioEventoDeportivo repoTempEv = new RepoEventoDeportivoEF();

CentroEventosSQLite.Inicializar();

using (var context = new CentroEventoContext())
{
Console.WriteLine("-- Tabla Personas --");
foreach (var p in context.Personas)
{
    Console.WriteLine($"{p._id} {p._nombre}");
}
Console.WriteLine("-- Tabla Eventos --");
foreach (var e in context.EventosDeportivos)
{
    Console.WriteLine($"{e._id} {e._nombre}");
}
Console.WriteLine("-- Tabla Reservas --");
foreach (var r in context.Reservas)
{
    Console.WriteLine($"{r._id} {r._personaId} {r._eventoDeportivoId} {r._fechaAltaReserva}");
}
}

var builder = WebApplication.CreateBuilder(args); //////////////////////
builder.Services.AddScoped<AltaPersona>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
