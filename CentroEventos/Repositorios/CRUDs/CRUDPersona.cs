using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using Repositorios.GestionIDs;

namespace Repositorios.CRUDs;

public class CRUDPersona : IRepositorioPersona, IServicioAutorizacion
{
    private readonly string _pathRepo = Path.Combine(
        Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
        "Personas.txt");
    private IdManagerPersona managerId = new IdManagerPersona();
    
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

    public Boolean ExisteDocumento(String documento)
    {
        foreach (Persona p in ObtenerTodos())
        {
            if (p.Dni == documento)
            {
                return true;
            }
        }
        throw new EntidadNotFoundException();
            
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
        throw new EntidadNotFoundException();

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

    public void registrarPersona(Persona p)
    {

        try
        {
            using StreamWriter escritor = new StreamWriter(_pathRepo, append: true);
            escritor.WriteLine(managerId.ObtenerNuevoId + "," + p.UnaLinea);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al agregar persona: {e.Message}");
        }

    }

    public Boolean PoseeElPermiso (int id, Permiso permiso){ 
        List<string> palabras = new List<string>();
        using (StreamReader sr = new StreamReader(_pathRepo))
        {
            
            string linea;
            while ((linea = sr.ReadLine()) != null)
            {
                if (linea.StartsWith(id.ToString())) 
                {
                    palabras.AddRange(linea.Split(' '));
                    break;
                }
            }
        }
        foreach (String palabra in palabras){

            if (permiso.ToString().Equals(palabra)){
                return true;
            }

        }
        return false;

    }

}
