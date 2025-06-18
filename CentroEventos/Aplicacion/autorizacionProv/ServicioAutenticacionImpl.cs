using System;
using Aplicacion.entidades;
using Repositorios.Context;
using Aplicacion.interfacesServ;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace Aplicacion.autorizacionProv;

public class ServicioAutentitacionImpl : IServicioAutenticacion
{
    private readonly CentroEventoContext _context;
    private Persona? _usuarioActual;

    public ServicioAutenticacion(CentroEventoContext context)
    {
        _context = context;
    }

    public bool EstaAutenticado => _usuarioActual != null;
    public Persona? UsuarioActual => _usuarioActual;

    public async Task<Persona?> AutenticarAsync(string email, string contraseña)
    {
        // Hash de la contraseña ingresada
        string contraseñaHash = HashearContraseña(contraseña);

        var persona = await _context.Personas
            .Include(p => p._permisos)
            .FirstOrDefaultAsync(p => p._mail == email && p._contraseña == contraseñaHash);

        return persona;
    }

    public async Task<bool> TienePermisoAsync(int personaId, string nombrePermiso)
    {
        var persona = await _context.Personas
            .Include(p => p._permisos)
            .FirstOrDefaultAsync(p => p._id == personaId);

        return persona?.tienePermiso(nombrePermiso) ?? false;
    }

    public async Task<Persona?> ObtenerUsuarioActualAsync()
    {
        if (_usuarioActual != null)
        {
            // Recargar desde la BD para obtener permisos actualizados
            _usuarioActual = await _context.Personas
                .Include(p => p._permisos)
                .FirstOrDefaultAsync(p => p._id == _usuarioActual._id);
        }
        return _usuarioActual;
    }

    public Task IniciarSesionAsync(Persona persona)
    {
        _usuarioActual = persona;
        return Task.CompletedTask;
    }

    public Task CerrarSesionAsync()
    {
        _usuarioActual = null;
        return Task.CompletedTask;
    }

    private string HashearContraseña(string contraseña)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}

