using System;
using System.Globalization;
using Aplicacion.AutorizacionProv;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using System;
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.entidades;

public class Persona
{
    // Propiedades originales
    [Key] public int _id { get; set; }
    public string _dni { get;  set; }
    public String _nombre { get;  set; }
    public string _apellido { get;  set; }
    public string _mail { get;  set; }
    public string _telefono { get;  set; }
    public string _contraseña { get; set; }


    public virtual ICollection<Permiso> _permisos { get; set; } = new List<Permiso>();
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>(); // Sus reservas


    public Persona(string dni, string nombre, string apellido, string mail, string telefono, string contraseña)
    {
        _dni = dni;
        _nombre = nombre;
        _apellido = apellido;
        _mail = mail;
        _telefono = telefono;
        _contraseña = contraseña;

        _permisos = new List<Permiso>(); // 

        Reservas = new List<Reserva>();
    }

    protected Persona()
    {

        _dni = string.Empty;
        _nombre = string.Empty;
        _apellido = string.Empty;
        _mail = string.Empty;
        _telefono = string.Empty;
        _contraseña = string.Empty;

        _permisos = new List<Permiso>();

        Reservas = new List<Reserva>();
    }

    public override String ToString()
    {
        return $"Dni: {this._dni}, Nombre: {this._nombre}, Apellido: {this._apellido}, Mail: {this._mail}, Telefono: {this._telefono}";
    }

    public bool tienePermiso(string nombrePermiso)
        {
            return _permisos.Any(p => p._nombre == nombrePermiso);
        }

    public void agregarPermiso(Permiso permiso)
    {
        this._permisos.Add(permiso);
    }

    public void eliminarPermiso(Permiso permiso)
    {
        this._permisos.Remove(permiso);
    }

    public void modificarDni(string dni)
    {
        this._dni = dni;
    }

    public void modificarNombre(string nombre)
    {
        this._nombre = nombre;
    }

    public void modificarApellido(string apellido)
    {
        this._apellido = apellido;
    }

    public void modificarMail(string mail)
    {
        this._mail = mail;
    }

    public void modificarTelefono(string telefono)
    {
        this._telefono = telefono;
    }

    public void modificarContraseña(String contraseña)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2"));
            this._contraseña = sb.ToString();
        }   
    }
}