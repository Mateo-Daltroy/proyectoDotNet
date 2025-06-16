using System;
using System.Collections.Generic;
using System.IO;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Repositorios.ImplementacionesRepo;

public class RepoReservas : IRepositorioReserva
{
 
    private readonly string _pathRepo = Path.Combine(
    Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName,
    "Repositorios",
    "Reservas.txt"
);

    public void Agregar(Reserva res)
    {
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
    }

    public Reserva ObtenerPorId(int id)
    {
        foreach (Reserva res in ObtenerTodos())
        {
            if (res._id == id) return res;
        }
        throw new EntidadNotFoundException($"Reserva con ID {id} no encontrada.");
    }

    public void Actualizar(Reserva res)
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
    }

    public void Actualizar(int id)
    {
        Reserva reserva = this.ObtenerPorId(id);
        Actualizar(reserva);
    }

    public void Eliminar(Reserva res)
    {
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
    }

    public void Eliminar(int id)
    {
        Reserva reserva = this.ObtenerPorId(id);
        Eliminar(reserva);
    }

    public bool ExisteId(int idPers, int idEv)
    {
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
        int count = 0;
        foreach (Reserva res in ObtenerTodos())
        {
            if (res._eventoDeportivoId == idEv) count++;
        }
        return count;
    }
    public IEnumerable<Reserva> ObtenerTodos()
    {
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
    }

    private static Reserva StringToRes(string unaLinea)
    {
        try
        {
            string[] partes = unaLinea.Split(',');
            return new Reserva(
                int.Parse(partes[0]),             // IdRes
                int.Parse(partes[1]),             // IdPers
                int.Parse(partes[2]),             // IdEvento
                DateTime.Parse(partes[3]),        // Fecha
                Enum.Parse<Asistencia>(partes[4]) // Asistencia
            );
        }
        catch (Exception)
        {
            throw new ValidacionException();
        }
    }

    private static string ResToString(Reserva unaRes)
    {
        return $"{unaRes._id},{unaRes._personaId},{unaRes._eventoDeportivoId},{unaRes._fechaAltaReserva:yyyy-MM-ddTHH:mm:ss},{unaRes._estadoAsistencia}";
    }
}