using Aplicacion.entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Context;

public class CentroEventoContext : DbContext
{

    #nullable disable
    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }

}