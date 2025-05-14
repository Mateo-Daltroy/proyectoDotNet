using System;
using System.Globalization;
using Aplicacion.validadores;

namespace Aplicacion.entidades;

public class Persona
{
    private string? _dni;
    private string _nombre;
    private string _apellido;
    private string _mail;
    private string _telefono;

    public Persona(string? dni, string nombre, string apellido, string mail, string telefono)
    {
        _dni = dni;
        _nombre = nombre;
        _apellido = apellido;
        _mail = mail;
        _telefono = telefono;
    }

    public bool RegistrarPersona (Persona p){
        
        return ValidacionPersona.ValidarPersona(p);

    }

    public string? Dni
    {
        get { return _dni; }
        set { _dni = value; }
    }

    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    public string Apellido
    {
        get { return _apellido; }
        set { _apellido = value; }
    }

    public string Mail
    {
        get { return _mail; }
        set { _mail = value; }
    }

    public string Telefono
    {
        get { return _telefono; }
        set { _telefono = value; }
    }
}
