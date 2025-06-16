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
        /*
        using StreamWriter escritor = new StreamWriter(_pathRepo, append: true);
        try
        {
            escritor.WriteLine(ResToString(res));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al agregar reserva: {e.Message}");
        }
        finally
        {
            escritor.Close();
        }
        */
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
        /*
        foreach (Reserva res in ObtenerTodos())
        {
            if (res._id == id) return res;
        }
        throw new EntidadNotFoundException($"Reserva con ID {id} no encontrada.");
        */
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
        /*
        string tempFilePath = _pathRepo + ".tmp";
        bool actualizado = false;
        using StreamReader lector = new StreamReader(_pathRepo);
        using StreamWriter escritor = new StreamWriter(tempFilePath);
        try
        {
            string? linea;
            while ((linea = lector.ReadLine()) != null)
            {
                try
                {
                    Reserva resAct = StringToRes(linea);
                    escritor.WriteLine(resAct._id == res._id ? ResToString(res) : linea);
                    actualizado |= resAct._id == res._id;
                }
                catch (ValidacionException)
                {
                    Console.WriteLine("Advertencia: línea salteada porque no respetaba el formato");
                }
            }
            if (!actualizado)
            {
                throw new EntidadNotFoundException($"Reserva con ID {res._id} no encontrada para actualizar.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al actualizar reserva: {e.Message}");
        }
        finally
        {
            lector.Close();
            escritor.Close();
            File.Replace(tempFilePath, _pathRepo, null);
        }
        */
    }

    public void Eliminar(Reserva res)
    {
        var context = new CentroEventoContext();
        context.Reservas.Remove(res);
        context.SaveChanges();
        /*
        string tempFilePath = _pathRepo + ".tmp";
        bool found = false;
        using (StreamReader lector = new StreamReader(_pathRepo))
        using (StreamWriter escritor = new StreamWriter(tempFilePath))
        try
        {
            string? linea;
            while ((linea = lector.ReadLine()) != null)
            {
                Reserva resAct = StringToRes(linea);
                if (resAct._id != res._id)
                {
                    escritor.WriteLine(linea);
                }
                else
                {
                    found = true;
                }
            }
            if (!found)
            {
                throw new EntidadNotFoundException();
            }
            File.Delete(_pathRepo);
            File.Move(tempFilePath, _pathRepo);
        }
        catch (ValidacionException)
        {
            Console.WriteLine("El repositorio Reservas.txt fue corrompido");
        }
        catch (EntidadNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            lector.Close();
            escritor.Close();
        }
        */
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
        /*
        StreamReader _lector = new StreamReader(_pathRepo);
        try
        {
            string? linea;
            while ((linea = _lector.ReadLine()) != null)
            {
                try
                {
                    Reserva res = StringToRes(linea);
                    if (res._personaId == idPers && res._eventoDeportivoId == idEv)
                    {
                        return true;
                    }
                }
                catch (ValidacionException)
                {
                    Console.WriteLine("Linea salteada en Reservas.txt porque no respetaba el formato");
                }
            }
        }
        finally
        {
            _lector.Close();
        }
        return false;
        */
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
        /*
        int count = 0;
        foreach (Reserva res in ObtenerTodos())
        {
            if (res._eventoDeportivoId == idEv) count++;
        }
        return count;
        */
    }

    public IEnumerable<Reserva> ObtenerTodos()
    {
        return new CentroEventoContext().Reservas;
        /*
        List<Reserva> reservas = new List<Reserva>();
        using StreamReader lector = new StreamReader(_pathRepo);
        try
        {
            string? linea;
            while ((linea = lector.ReadLine()) != null)
            {
                try
                {
                    reservas.Add(StringToRes(linea));
                }
                catch (ValidacionException)
                {
                    Console.WriteLine("Advertencia: línea salteada porque no respetaba el formato");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("El repositorio no fue encontrado. Creando uno nuevo...");
            File.Create(_pathRepo).Close();
        }
        finally
        {
            lector.Close();
        }
        return reservas;
        */
    }
}