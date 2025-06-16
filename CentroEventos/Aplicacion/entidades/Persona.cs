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
    public string _dni { get; private set; }
    public String _nombre { get; private set; }
    public string _apellido { get; private set; }
    public string _mail { get; private set; }
    public string _telefono { get; private set; }
    
    private List<Permiso> _permisos;

    public Persona(string dni, string nombre, string apellido, string mail, string telefono)
    {
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
        _dni = string.Empty;
        _nombre = string.Empty;
        _apellido = string.Empty;
        _mail = string.Empty;
        _telefono = string.Empty;
        _permisos = new List<Permiso>();
    }        

    public override string ToString()
    {
        return $"Dni:{_dni}, Nombre:{_nombre}, Apellido:{_apellido}, Mail:{_mail}, Telefono:{_telefono}";
    }

}
