using Aplicacion.entidades;
using Aplicacion.UseCases.UseCasesPersona;
using Repositorios.Context;

namespace Repositorios.Context;

public static class CentroEventosSQLite
   // Esta clase es para inicializar la base de datos SQLite
   // y crearla si no existe.

   // Requiere paquete NuGet Microsoft.EntityFrameworkCore.Sqlite 

{
   public static void Inicializar()
    { 
        //COMENTAR EN CASO DE NO QUERER BORRAR LA DB
         string dbPath = "CentroEventos.sqlite";
         if (File.Exists(dbPath)) 
         {
             File.Delete(dbPath);
             Console.WriteLine("Base de datos eliminada y recreándose...");
         }

        using var context = new CentroEventoContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }

        CrearPermisosIniciales(context);
        SeedData(context);

    }

    public static void CrearPermisosIniciales(CentroEventoContext context)
    {
        var permisos = new List<Permiso>
        {
            new Permiso("EventoAlta"),
            new Permiso("EventoModificacion"),
            new Permiso("EventoBaja"),
            new Permiso("ReservaAlta"),
            new Permiso("ReservaModificacion"),
            new Permiso("ReservaBaja"),
            new Permiso("UsuarioAlta"),
            new Permiso("UsuarioModificacion"),
            new Permiso("UsuarioBaja"),
        };

        context.Permisos.AddRange(permisos);
        context.SaveChanges();
        Console.WriteLine($"Creados {permisos.Count} permisos iniciales");
    }
    
    public static void SeedData(CentroEventoContext context)
    {

        // Crear persona con permisos
        var persona1 = new Persona("123456", "Juan", "Pérez", "juan@email.com", "123456789", "password123");

        // crimenes de guerra miscelaneos
        string pass = AltaPersona.hashearPassword(persona1);
        persona1._contraseña = pass;

        //Asignarle algunos permisos
        var permisoCrearEvento = context.Permisos.First(p => p._nombre == "EventoAlta");
        var permisoCrearReserva = context.Permisos.First(p => p._nombre == "ReservaAlta");
        
        persona1._permisos.Add(permisoCrearEvento);
        persona1._permisos.Add(permisoCrearReserva);
        persona1._permisos.Add(context.Permisos.First(p => p._nombre == "UsuarioModificacion"));
        persona1._permisos.Add(context.Permisos.First(p => p._nombre == "UsuarioBaja"));
        persona1._permisos.Add(context.Permisos.First(p => p._nombre == "ReservaModificacion"));
        persona1._permisos.Add(context.Permisos.First(p => p._nombre == "ReservaBaja"));

        context.Personas.Add(persona1);
        context.SaveChanges();
        
        // Crear evento
        var evento1 = new EventoDeportivo(
            "Fútbol Amateur", 
            "Partido de fútbol", 
            DateTime.Now.AddDays(7), 
            2.0, 
            20, 
            persona1._id);
        context.EventosDeportivos.Add(evento1);
        context.SaveChanges();
        
        Console.WriteLine("Datos de prueba creados");
    }

}