using System;
using System.Globalization;
using Aplicacion.autorizacionProv;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;

namespace Aplicacion.entidades;

public class Persona
{
    public int _id { get; private set; }
    public string? _dni { get; private set; }
    public String _nombre { get; private set; }
    public string _apellido { get; private set; }
    public string _mail { get; private set; }
    public string _telefono { get; private set; }
    
    private List<Permiso> _permisos;

    public Persona(string dni, string nombre, string apellido, string mail, string telefono)
    {
        if (!ValidacionPersona.ValidarDni(dni))
        {
            throw new ValidacionException("El formato del Dni no es correcto.");
        }
        if (!ValidacionPersona.ValidarNombre(nombre))
        {
            throw new ValidacionException("El formato del Nombre no es correcto.");
        }
        if (!ValidacionPersona.ValidarApellido(apellido))
        {
            throw new ValidacionException("El formato del Apellido no es correcto.");
        }
        if (!ValidacionPersona.ValidarMail(mail))
        {
            throw new ValidacionException("El formato del Mail no es correcto.");
        }
        if (!ValidacionPersona.ValidarTelefono(telefono))
        {
            throw new ValidacionException("El formato del Telefono no es correcto.");
        }

        _dni = dni;
        _nombre = nombre;
        _apellido = apellido;
        _mail = mail;
        _telefono = telefono;
        _permisos = new();
    }

    protected Persona()
        {
            // Constructor protegido sin parametros para Entity Framework Core
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
        return $"Dni:{Dni}, Nombre:{Nombre}, Apellido:{Apellido}, Mail:{Mail}, Telefono:{Telefono}";
    }


    public String UnaLinea()
    {
        return ($"{Id},{Dni},{Nombre},{Apellido},{Mail},{Telefono}");
    }

    public String UnaLineaSinId()
    {
        return ($"{Dni},{Nombre},{Apellido},{Mail},{Telefono}");
    }


}
