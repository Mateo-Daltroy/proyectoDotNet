using UI.Components;
// See https://aka.ms/new-console-template for more information
using Repositorios.Context;
using Aplicacion.entidades;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using Repositorios.ImplementacionesRepo;
using Aplicacion.UseCases.UseCasesPersona;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Aplicacion.UseCases.UseCasesEvento;
using Aplicacion.UseCases.UseCasesReserva;
using Aplicacion.interfacesServ;
using Aplicacion.AutorizacionProv;

//_Inicializar Bases de Datos_
/*
IRepositorioReserva repoTempRes = new RepoReservas();
IRepositorioPersona repoTempPers = new RepoPersonas();
IRepositorioEventoDeportivo repoTempEv = new RepoEventoDeportivoEF(new CentroEventoContext());
*/
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

// Codigo de la catedra, no tocar
var contexto = new CentroEventoContext();

contexto.Database.EnsureCreated();
DbConnection connection = contexto.Database.GetDbConnection();
connection.Open();
using (var command = connection.CreateCommand())
{
command.CommandText = "PRAGMA journal_mode=DELETE;";
command.ExecuteNonQuery();
}
// fin de codigo de la catedra

// --> Construccion del builder
var builder = WebApplication.CreateBuilder(args); //////////////////////
builder.Services.AddScoped<CentroEventoContext>();

// Repos
builder.Services.AddScoped<IRepositorioPersona, RepoPersonas>();
builder.Services.AddScoped<IRepositorioReserva, RepoReservas>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepoEventoDeportivo>();

// Usuario y Auth
builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacionImpl>();

// Casos Uso Persona
builder.Services.AddScoped<AltaPersona>();
builder.Services.AddScoped<ModificarPersona>();
builder.Services.AddScoped<BajaPersona>();
builder.Services.AddScoped<ExistePersonaPorId>();
builder.Services.AddScoped<ListarNombresDePersonas>();
builder.Services.AddScoped<ListarTodasLasPersonas>();
builder.Services.AddScoped<ModificarPersona>();
builder.Services.AddScoped<ObetenerIdPersonaPorDocumento>();
builder.Services.AddScoped<PersonaPoseeElPermiso>();
builder.Services.AddScoped<ValidarUsuarioYContraseña>();
builder.Services.AddScoped<ObtenerPersonaPorId>();

// Casos Uso Evento Deportivo
builder.Services.AddScoped<AltaEvento>();
builder.Services.AddScoped<ModificarEvento>();
builder.Services.AddScoped<BajaEvento>();
builder.Services.AddScoped<ListarEventosConCupo>();
builder.Services.AddScoped<ListarEventosPasados>();
builder.Services.AddScoped<ListarEventosSinReservas>();
builder.Services.AddScoped<ObtenerEventoPorId>();

// Casos Uso Reserva
builder.Services.AddScoped<AltaReserva>();
builder.Services.AddScoped<ModificarReserva>();
builder.Services.AddScoped<BajaReserva>();
builder.Services.AddScoped<ListarPersonasAsistidasAEvento>();
builder.Services.AddScoped<ListarTodasLasReservas>();
builder.Services.AddScoped<ObtenerReservaPorId>();

// --> Fin del constructor del builder

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
