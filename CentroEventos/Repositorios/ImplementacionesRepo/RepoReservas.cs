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
    public void EliminarPorPersona(int id)
    {
        new CentroEventoContext()
            .Reservas
            .Where(res => res._personaId == id)
            .ExecuteDelete();
    }

    public void EliminarPorEvento(int id)
    {
        new CentroEventoContext()
            .Reservas
            .Where(res => res._eventoDeportivoId == id)
            .ExecuteDelete();
    }

    public void Agregar(Reserva res)
    {
        var contexto = new CentroEventoContext();
        contexto.Reservas.Add(res);

        contexto.SaveChanges();
    }

    public Reserva ObtenerPorId(int id)
    {
        Reserva? reserva = new CentroEventoContext()
            .Reservas
            .Find(id);
        if (reserva == null)
        {
            throw new EntidadNotFoundException();
        }
        return(reserva);
    }

    public void Actualizar(Reserva res)
    {
        var context = new CentroEventoContext();
        Reserva? busq = context.Reservas.Find(res._id);
        if (busq == null)
        {
            throw new EntidadNotFoundException();
        }
        busq._estadoAsistencia = res._estadoAsistencia;
        busq._eventoDeportivoId = res._eventoDeportivoId;
        busq._fechaAltaReserva = res._fechaAltaReserva;
        busq._personaId = res._personaId;

        context.SaveChanges();
    }

    public void Eliminar(Reserva res)
    {
        var context = new CentroEventoContext();
        context.Reservas.Remove(res);
        context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        Reserva reserva = this.ObtenerPorId(id);
        Eliminar(reserva);
    }

    public bool ExisteId(int idPers, int idEv)
    {
        var context = new CentroEventoContext();

        // Esta debe ser la implementacion menos eficiente posible pero bueno señores, es lo que hay
        return context
        .Reservas
        .Where(res => (res._personaId == idPers) && (res._eventoDeportivoId == idEv))
        .ToList()
        .Count == 1;
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
        var context = new CentroEventoContext();

        return context
        .Reservas
        .Count(res => res._eventoDeportivoId == idEv);
    }

    public IEnumerable<Reserva> ObtenerTodos()
    {
        return new CentroEventoContext().Reservas;
    }
}