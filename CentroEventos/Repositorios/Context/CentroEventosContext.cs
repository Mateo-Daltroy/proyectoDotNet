using Aplicacion.entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.Context;

public class CentroEventoContext : DbContext
{

    #nullable disable
    public DbSet<Persona> personas { get; set; }
    public DbSet<EventoDeportivo> eventos { get; set; }
    public DbSet<Reserva> reservas { get; set; }
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }

}