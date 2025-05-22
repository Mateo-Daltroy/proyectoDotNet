using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using CentroEventos.Aplicacion.InterfacesRepo;
using CentroEventos.Repositorios.GestionIDs;

namespace CentroEventos.Repositorios.implementacionesRepo;

public class RepoPersonasTxt : IRepositorioPersona, IServicioAutorizacion
{

    private readonly string _pathRepo = Path.Combine(
        Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
        "Personas.txt");

    private readonly string _pathRepoId = Path.Combine(
        Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
        "idPersonas.txt");

    private IdManager managerId = new IdManager();

    /*public RepoPersonasTxt()
    {
        Console.WriteLine(_pathRepo);
        Console.WriteLine(_pathRepoId);
    }*/

    public Boolean ExisteId(int id)
    {
        foreach (Persona p in ObtenerTodos())
        {
            if (p._id == id)
            {
                return true;
            }
        }
        throw new EntidadNotFoundException();

    }

    public String listarTodos()
    {
        List<Persona> personas = ObtenerTodos().ToList();
        if (personas.Count == 0)
        {
            return string.Empty;
        }
        return string.Join(Environment.NewLine, personas.Select(p => p.ToString() + "\n"));
    }

    public void Eliminar(int id)
    {
        string tempFilePath = _pathRepo + ".tmp";
        bool found = false;
        try
        {
            using (StreamReader lector = new StreamReader(_pathRepo))
            using (StreamWriter escritor = new StreamWriter(tempFilePath))
            {
                string? linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    Persona persAct = StringToPers(linea);
                    if (persAct._id != id)
                    {
                        escritor.WriteLine(linea);
                    }
                    else
                    {
                        found = true;
                    }
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
            Console.WriteLine("El repositorio Personas.txt fue corrompido");
        }
        catch (EntidadNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    } 

    public void Actualizar(Persona per)
    {
        string tempFilePath = _pathRepo + ".tmp";
        bool actualizado = false;
        try
        {
            using StreamReader lector = new StreamReader(_pathRepo);
            using StreamWriter escritor = new StreamWriter(tempFilePath);
            string? linea;
            while ((linea = lector.ReadLine()) != null)
            {
                try
                {
                    Persona PersAct = StringToPers(linea);
                    escritor.WriteLine(PersAct._dni == per._dni ? per.UnaLinea() : linea);
                    actualizado |= PersAct._dni == per._dni;
                }
                catch (ValidacionException)
                {
                    Console.WriteLine("Advertencia: línea salteada porque no respetaba el formato");
                }
            }
            if (!actualizado)
            {
                throw new EntidadNotFoundException($"Persona con ID {per._id} no encontrada para actualizar.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al actualizar Persona: {e.Message}");
        }
        File.Replace(tempFilePath, _pathRepo, null);
    }



    public String getNombreConId(int id)
    {

        using (StreamReader sr = new StreamReader(_pathRepo))
        {

            string? linea;
            string[] partes = new string[6];
            while ((linea = sr.ReadLine()) != null)
            {
                if (linea.StartsWith(id.ToString()))
                {
                    partes = linea.Split(',');
                    break;
                }

            }
            return partes[2];

        }

    }

    public Boolean ExisteDocumento(String documento)
    {
        foreach (Persona p in ObtenerTodos())
        {
            if (p.Dni == documento)
            {
                return true;
            }
        }
        return false;

    }



    private static Persona StringToPers(string unaLinea)
    {
        try
        {
            string[] partes = unaLinea.Split(',');
            return new Persona(
                int.Parse(partes[0]),
                partes[1],
                partes[2],
                partes[3],
                partes[4],
                partes[5]
            );
        }
        catch (Exception)
        {
            throw new ValidacionException();
        }
    }

    public IEnumerable<Persona> ObtenerTodos()
    {
        List<Persona> reservas = new List<Persona>();
        try
        {
            using StreamReader lector = new StreamReader(_pathRepo);
            string? linea;
            while ((linea = lector.ReadLine()) != null)
            {
                try
                {
                    reservas.Add(StringToPers(linea));
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
        return reservas;
    }

    
    public int getIdConDocumento(String documento)
    {
        foreach (Persona p in ObtenerTodos())
        {
            if (p.Dni == documento)
            {
                return p.Id;
            }
        }
        throw new EntidadNotFoundException();

    }


    public Boolean ExisteMail(String mail)
    {
        foreach (Persona p in ObtenerTodos())
        {
            if (p.Mail == mail)
            {
                return true;
            }
        }
        return false;
        //throw new EntidadNotFoundException();

    }
    public int getIdConMail(String mail)
    {
        foreach (Persona p in ObtenerTodos())
        {
            if (p.Mail == mail)
            {
                return p.Id;
            }
        }
        throw new EntidadNotFoundException();

    }

    public void registrarPersona(Persona p, IIdManager managerId)
    {

        try
        {
            using StreamWriter escritor = new StreamWriter(_pathRepo, append: true);
            escritor.WriteLine(managerId.ObtenerNuevoId(_pathRepoId) + "," + p.UnaLinea());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al agregar persona: {e.Message}");
        }

    }

    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {
        List<string> palabras = new List<string>();
        using (StreamReader sr = new StreamReader(_pathRepo))
        {

            string? linea;
            while ((linea = sr.ReadLine()) != null)
            {
                if (linea.StartsWith(id.ToString()))
                {
                    palabras.AddRange(linea.Split(' '));
                    break;
                }
            }
        }
        foreach (String palabra in palabras)
        {

            if (permiso.ToString().Equals(palabra))
            {
                return true;
            }

        }
        return false;

    }

}