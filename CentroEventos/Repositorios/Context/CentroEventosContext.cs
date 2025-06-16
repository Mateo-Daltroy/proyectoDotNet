using Aplicacion.entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Context;

public class CentroEventoContext : DbContext
{

    public DbSet<Persona> personas { get; set; }
    public DbSet<EventoDeportivo> eventos { get; set; }
    public DbSet<Reserva> reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }

}