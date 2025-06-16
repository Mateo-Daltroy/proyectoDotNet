using System;
using System.Collections.Generic;
using System.IO;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Repositorios.ImplementacionesRepo;

public class RepoEventoDeportivo : IRepositorioEventoDeportivo
{
    private readonly string _pathRepo = Path.Combine(
    Path.Combine(
        Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
        "Repositorios"
    ),
    "Eventos.txt"
);

    public void Agregar(EventoDeportivo ev)
    {
        using StreamWriter escritor = new StreamWriter(_pathRepo, append: true);
        try
        {
            escritor.WriteLine(EventoToString(ev));
        }
        catch (Exception e)
        {
            throw new Exception ($"Error al agregar evento: {e.Message}");
        }
        finally
        {
            escritor.Close();
        }
    }

    public EventoDeportivo ObtenerPorId(int id)
    {
        foreach (EventoDeportivo ev in ObtenerTodos())
        {
            if (ev._id == id) return ev;
        }
        throw new EntidadNotFoundException($"Evento con ID {id} no encontrado.");
    }

    public void Actualizar(EventoDeportivo ev)
    {
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
                    EventoDeportivo evActual = StringToEvento(linea);
                    escritor.WriteLine(evActual._id == ev._id ? EventoToString(ev) : EventoToString(evActual));
                    actualizado |= evActual._id == ev._id;
                }
                catch (ValidacionException)
                {
                    throw new Exception ("Advertencia: línea salteada porque no respetaba el formato.");
                }
            }

            if (!actualizado)
                throw new EntidadNotFoundException($"Evento con ID {ev._id} no encontrado para actualizar.");
        }
        catch (Exception e)
        {
            throw new Exception ($"Error al actualizar evento: {e.Message}");
        }
        finally
        {
            lector.Close();
            escritor.Close();
            File.Replace(tempFilePath, _pathRepo, null);
        }
    }

    public void Eliminar(int id)
    {
        string tempFilePath = _pathRepo + ".tmp";
        bool eliminado = false;
        using StreamReader lector = new StreamReader(_pathRepo);
        using StreamWriter escritor = new StreamWriter(tempFilePath);
        try
        {
            string? linea;

            while ((linea = lector.ReadLine()) != null)
            {
                EventoDeportivo ev = StringToEvento(linea);
                if (ev._id != id)
                {
                    escritor.WriteLine(EventoToString(ev));
                }
                else
                {
                    eliminado = true;
                }
            }

            if (!eliminado)
                throw new EntidadNotFoundException($"No se encontró el evento con ID {id} para eliminar.");

            File.Replace(tempFilePath, _pathRepo, null);
        }
        catch (Exception e)
        {
            throw new Exception ($"Error al eliminar evento: {e.Message}");
        }
        finally
        {
            lector.Close();
            escritor.Close();
        }
    }

    public IEnumerable<EventoDeportivo> ObtenerTodos()
    {
        List<EventoDeportivo> lista = new();
        using StreamReader lector = new StreamReader(_pathRepo);
        if (!File.Exists(_pathRepo))
        {
            lector.Close();
            return lista;
        }

        string? linea;
        while ((linea = lector.ReadLine()) != null)
        {
            try
            {
                lista.Add(StringToEvento(linea));
            }
            catch (ValidacionException)
            {
                throw new Exception ("Línea corrupta ignorada en archivo Eventos.txt.");
            }
        }
        lector.Close();
        return lista;
    }

    public bool Contiene(int id)
    {
        return ObtenerTodos().Any(ev => ev._id == id);
    }


    private static string EventoToString(EventoDeportivo ev)
    {
        return $"{ev._id},{ev._nombre},{ev._descripcion},{ev._fechaHoraInicio:O},{ev._duracionHoras},{ev._cupoMaximo},{ev._responsableId}";
    }

    private static EventoDeportivo StringToEvento(string linea)
    {
        try
        {
            string[] partes = linea.Split(',');
            return new EventoDeportivo(
                id: int.Parse(partes[0]),
                nombre: partes[1],
                descripcion: partes[2],
                fechaHoraInicio: DateTime.Parse(partes[3]),
                duracionHoras: double.Parse(partes[4]),
                cupoMaximo: int.Parse(partes[5]),
                responsableId: int.Parse(partes[6])
            );
        }
        catch (Exception)
        {
            throw new ValidacionException("Error al parsear la línea del archivo de eventos.");
        }
    }

}

