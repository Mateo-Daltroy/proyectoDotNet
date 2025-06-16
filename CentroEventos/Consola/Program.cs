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

// Variables Globales
string input;
int Id = -1;

//djfnñsjfn
//nkdn

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
    Console.WriteLine($"{p.Id} {p.Nombre}");
}
Console.WriteLine("-- Tabla Eventos --");
foreach (var e in context.EventosDeportivos)
{
    Console.WriteLine($"{e.Id} {e.Nombre}");
}
Console.WriteLine("-- Tabla Reservas --");
foreach (var r in context.Reservas)
{
    Console.WriteLine($"{r.Id} {r.PersonaId} {r.EventoId} {r.Fecha}");
}
}