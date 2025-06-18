using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Repositorios.Context;

namespace Repositorios.ImplementacionesRepo;

public class RepoEventoDeportivo : IRepositorioEventoDeportivo
{
    private readonly CentroEventoContext _context;

    public RepoEventoDeportivo(CentroEventoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    // Obtener evento con todas sus reservas y personas
    public async Task<EventoDeportivo?> ObtenerEventoCompleto(int eventoId)
    {
        try 
        {
            return await _context.EventosDeportivos
                .Include(e => e.Reservas)
                    .ThenInclude(r => r.Persona)
                .Include(e => e.Responsable)
                .FirstOrDefaultAsync(e => e._id == eventoId); // ✅ Async version
        } 
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener evento: {ex.Message}", ex);
        }
    }

    public async Task AgregarAsync(EventoDeportivo ev)
    {
        try
        {
            await _context.EventosDeportivos.AddAsync(ev);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error al agregar evento: {e.Message}");
        }
    }

    public async Task<EventoDeportivo> ObtenerPorIdAsync(int id)
    {
        var evento = await _context.EventosDeportivos.FindAsync(id);
        
        if (evento == null)
        {
            throw new EntidadNotFoundException($"Evento con ID {id} no encontrado.");
        }
        
        return evento;
    }

    public async Task ActualizarAsync(EventoDeportivo ev)
    {
        try
        {
            var eventoExistente = await _context.EventosDeportivos.FindAsync(ev._id);
            
            if (eventoExistente == null)
            {
                throw new EntidadNotFoundException($"Evento con ID {ev._id} no encontrado para actualizar.");
            }

            // Actualizar propiedades
            eventoExistente._nombre = ev._nombre;
            eventoExistente._descripcion = ev._descripcion;
            eventoExistente._fechaHoraInicio = ev._fechaHoraInicio;
            eventoExistente._duracionHoras = ev._duracionHoras;
            eventoExistente._cupoMaximo = ev._cupoMaximo;
            eventoExistente._responsableId = ev._responsableId;

            _context.EventosDeportivos.Update(eventoExistente);
            await _context.SaveChangesAsync();
        }
        catch (EntidadNotFoundException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new Exception($"Error al actualizar evento: {e.Message}");
        }
    }

    public async Task EliminarAsync(int id)
    {
        try
        {
            var evento = await _context.EventosDeportivos.FindAsync(id);
            
            if (evento == null)
            {
                throw new EntidadNotFoundException($"No se encontró el evento con ID {id} para eliminar.");
            }

            _context.EventosDeportivos.Remove(evento);
            await _context.SaveChangesAsync();
        }
        catch (EntidadNotFoundException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new Exception($"Error al eliminar evento: {e.Message}");
        }
    }

    public async Task<IEnumerable<EventoDeportivo>> ObtenerTodosAsync()
    {
        try
        {
            return await _context.EventosDeportivos.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error al obtener todos los eventos: {e.Message}");
        }
    }

    public async Task<bool> ContieneAsync(int id)
    {
        return await _context.EventosDeportivos.AnyAsync(ev => ev._id == id);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}