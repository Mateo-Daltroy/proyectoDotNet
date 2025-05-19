using System;
using System.Globalization;
using Aplicacion.autorizacionProv;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;

namespace Aplicacion.entidades;

public class Persona
{
    public int _id { get; }
    public string? _dni { get; }
    public String _nombre { get; }
    public string _apellido { get; }
    public string _mail{ get; }
    public string _telefono{ get; }
    // No seria preferible usar un set?
    private List<Permiso> _permisos;

    public Persona(int id,string? dni, string nombre, string apellido, string mail, string telefono)
    {
        _id = id;
        _dni = dni;
        _nombre = nombre;
        _apellido = apellido;
        _mail = mail;
        _telefono = telefono;
        _permisos = new();
    }

    public Persona(string? dni, string nombre, string apellido, string mail, string telefono)
    {
        _dni = dni;
        _nombre = nombre;
        _apellido = apellido;
        _mail = mail;
        _telefono = telefono;
        _permisos = new();
    }

    public void RegistrarPersona(Persona p, IRepositorioPersona repoPersona)
    {

        try
        {
            ValidacionPersona.ValidarPersona(p, repoPersona);
            repoPersona.registrarPersona(p);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public string? Dni
    {
        get { return _dni; }

    }

    public string Nombre
    {
        get { return _nombre; }
        
    }

    public string Apellido
    {
        get { return _apellido; }

    }

    public string Mail
    {
        get { return _mail; }

    }

    public string Telefono
    {
        get { return _telefono; }
        
    }

    public int Id
    {
        get { return _id; }
        
    }

    public override string ToString()
    {
        return $"Dni:{Dni} Nombre:{Nombre}, Apellido:{Apellido}, Mail:{Mail}, Telefono:{Telefono}";
    }


    public String UnaLinea()
    {
        return ($"{Dni},{Nombre},{Apellido},{Mail},{Telefono}");
    }
}
