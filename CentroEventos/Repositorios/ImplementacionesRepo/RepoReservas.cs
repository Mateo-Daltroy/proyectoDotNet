using System;
using System.Collections.Generic;
using System.IO;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Microsoft.EntityFrameworkCore;
using Repositorios.Context;

namespace Repositorios.ImplementacionesRepo;

public class RepoReservas : IRepositorioReserva
{
    private readonly CentroEventoContext _context;

    public RepoReservas(CentroEventoContext repo)
    {
        this._context = repo;
    }


    public IEnumerable<Reserva> ObtenerTodos()
    {
        return _context.Reservas
            .Include(r => r.Persona)          
            .Include(r => r.EventoDeportivo)  
            .ToList();
    }

    public IEnumerable<Reserva> ObtenerPorPersona(int idPersona)
    {
        return _context.Reservas
            .Include(r => r.Persona)            
            .Include(r => r.EventoDeportivo)    
            .Where(res => res._personaId == idPersona)
            .ToList();
    }

    public Reserva ObtenerPorId(int id)
    {
        Reserva? reserva = _context.Reservas
            .Include(r => r.Persona)            
            .Include(r => r.EventoDeportivo) 
            .FirstOrDefault(r => r._id == id);

        if (reserva == null)
        {
            throw new EntidadNotFoundException();
        }
        return reserva;
    }

    public IEnumerable<Reserva> ObtenerPorEvento(int idEvento)
    {
        return _context.Reservas
            .Include(r => r.Persona)           
            .Include(r => r.EventoDeportivo)    
            .Where(res => res._eventoDeportivoId == idEvento)
            .ToList();
    }

    public void EliminarPorPersona(int id)
    {
        _context.Reservas
            .Where(res => res._personaId == id)
            .ExecuteDelete();
    }

    public void EliminarPorEvento(int id)
    {
        _context.Reservas
            .Where(res => res._eventoDeportivoId == id)
            .ExecuteDelete();
    }

    public void Agregar(Reserva res)
    {
        _context.Reservas.Add(res);
        _context.SaveChanges();
    }

    public void Actualizar(Reserva res)
    {
        Reserva? busq = _context.Reservas.Find(res._id);
        if (busq == null)
        {
            throw new EntidadNotFoundException();
        }
        busq._estadoAsistencia = res._estadoAsistencia;
        busq._eventoDeportivoId = res._eventoDeportivoId;
        busq._fechaAltaReserva = res._fechaAltaReserva;
        busq._personaId = res._personaId;

        _context.SaveChanges();
    }

    public void Eliminar(Reserva res)
    {
        _context.Reservas.Remove(res);
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        Reserva reserva = this.ObtenerPorId(id);
        Eliminar(reserva);
    }

    public bool ExisteId(int idPers, int idEv)
    {
        Reserva? res = _context.Reservas
            .FirstOrDefault(res => (res._personaId == idPers) && (res._eventoDeportivoId == idEv));
        return (res != null);
    }

    public bool ExisteId(int idRes)
    {
        try
        {
            return ObtenerPorId(idRes) != null;
        }
        catch (EntidadNotFoundException)
        {
            return false;
        }
    }

    public int GetAsistentes(int idEv)
    {
        return _context.Reservas
            .Count(res => res._eventoDeportivoId == idEv);
    }
}