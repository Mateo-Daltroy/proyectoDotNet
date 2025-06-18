using Aplicacion.entidades;
using Microsoft.EntityFrameworkCore;
using Aplicacion.autorizacionProv;

namespace Repositorios.Context;

public class CentroEventoContext : DbContext
{
    #nullable disable
    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Permiso> Permisos { get; set; } 
    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         // ===== CONFIGURACIÓN DE LA ENTIDAD PERMISO =====
        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(p => p._id);
            
            entity.Property(p => p._nombre).IsRequired().HasMaxLength(100);
            
            // Índice único para el nombre del permiso
            entity.HasIndex(p => p._nombre).IsUnique();
        });

        // ===== CONFIGURACIÓN DE LA ENTIDAD PERSONA =====
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(p => p._id);
            
            // Propiedades básicas
            entity.Property(p => p._dni).IsRequired().HasMaxLength(20);
            entity.Property(p => p._nombre).IsRequired().HasMaxLength(100);
            entity.Property(p => p._apellido).IsRequired().HasMaxLength(100);
            entity.Property(p => p._mail).IsRequired().HasMaxLength(150);
            entity.Property(p => p._telefono).IsRequired().HasMaxLength(20);
            entity.Property(p => p._contraseña).IsRequired().HasMaxLength(500);
            
            // Índices únicos
            entity.HasIndex(p => p._dni).IsUnique();
            entity.HasIndex(p => p._mail).IsUnique();

            // RELACIÓN MUCHOS A MUCHOS: Persona <-> Permiso
            entity.HasMany(p => p._permisos)
                  .WithMany(per => per.Personas)
                  .UsingEntity<Dictionary<string, object>>(
                      "PersonaPermiso", // Nombre de la tabla intermedia
                      j => j.HasOne<Permiso>().WithMany().HasForeignKey("PermisoId"),
                      j => j.HasOne<Persona>().WithMany().HasForeignKey("PersonaId"),
                      j =>
                      {
                          j.HasKey("PersonaId", "PermisoId");
                          j.ToTable("PersonaPermisos");
                      });
            
        });

        // ===== CONFIGURACIÓN DE LA ENTIDAD EVENTO DEPORTIVO =====
        modelBuilder.Entity<EventoDeportivo>(entity =>
        {
            entity.HasKey(e => e._id);
            
            // Propiedades básicas
            entity.Property(e => e._nombre).IsRequired().HasMaxLength(200);
            entity.Property(e => e._descripcion).IsRequired().HasMaxLength(500);
            entity.Property(e => e._fechaHoraInicio).IsRequired();
            entity.Property(e => e._duracionHoras).IsRequired();
            entity.Property(e => e._cupoMaximo).IsRequired();
            entity.Property(e => e._responsableId).IsRequired();
            
            // RELACIÓN CON PROPIEDADES DE NAVEGACIÓN: EventoDeportivo -> Persona (Responsable)
            entity.HasOne(e => e.Responsable)
                  .WithMany()
                  .HasForeignKey(e => e._responsableId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .IsRequired();
        });

        // ===== CONFIGURACIÓN DE LA ENTIDAD RESERVA =====
        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(r => r._id);
            
            // Propiedades básicas
            entity.Property(r => r._personaId).IsRequired();
            entity.Property(r => r._eventoDeportivoId).IsRequired();
            entity.Property(r => r._fechaAltaReserva).IsRequired();
            
            // Configuración del enum Asistencia
            entity.Property(r => r._estadoAsistencia)
                  .HasConversion<int>();
            
            // RELACIÓN CON PROPIEDADES DE NAVEGACIÓN: Reserva -> Persona
            entity.HasOne(r => r.Persona)
                  .WithMany(p => p.Reservas)
                  .HasForeignKey(r => r._personaId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .IsRequired();
            
            // RELACIÓN CON PROPIEDADES DE NAVEGACIÓN: Reserva -> EventoDeportivo  
            entity.HasOne(r => r.EventoDeportivo)
                  .WithMany(e => e.Reservas)
                  .HasForeignKey(r => r._eventoDeportivoId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .IsRequired();
            
            // Índice compuesto para evitar reservas duplicadas
            entity.HasIndex(r => new { r._personaId, r._eventoDeportivoId })
                  .IsUnique()
                  .HasDatabaseName("IX_Reserva_PersonaEvento");
        });

        base.OnModelCreating(modelBuilder);
    }
}