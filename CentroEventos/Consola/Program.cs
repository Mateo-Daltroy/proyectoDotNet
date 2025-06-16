// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Diagnostics;
using Repositorios.Context;
using Aplicacion.entidades;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using CentroEventos;
using CentroEventos.Aplicacion.InterfacesRepo;
using CentroEventos.Repositorios.implementacionesRepo;
using Repositorios.ImplementacionesRepo;

//_Inicializar Bases de Datos_
IRepositorioReserva repoTempRes = new RepoReservas();
IRepositorioPersona repoTempPers = new RepoPersonas();
IRepositorioEventoDeportivo repoTempEv = new RepoEventoDeportivo();

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