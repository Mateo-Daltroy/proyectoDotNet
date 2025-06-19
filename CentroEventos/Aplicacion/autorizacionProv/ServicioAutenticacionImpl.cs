using Aplicacion.entidades;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using System.Security.Cryptography;
using System.Text;

namespace Aplicacion.AutorizacionProv;

public class ServicioAutenticacionImpl : IServicioAutenticacion
{
    private readonly IRepositorioPersona _repositorioPersona;
    private Persona? _usuarioActual;

    public ServicioAutenticacionImpl (IRepositorioPersona repositorioPersona)
    {
        _repositorioPersona = repositorioPersona;
    }

    public bool EstaAutenticado => _usuarioActual != null;
    public Persona? UsuarioActual => _usuarioActual;

    public async Task<Persona?> AutenticarAsync(string email, string contraseña)
    {
        try
        {
            int personaId = _repositorioPersona.ValidarUserYPass(email, contraseña);
            
            if (personaId > 0)
            {
                var persona = _repositorioPersona.getPersonaConId(personaId);
                return persona;
            }
            
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> TienePermisoAsync(int personaId, string nombrePermiso)
    {
        try
        {
            // USAR el método de tu entidad Persona directamente
            var persona = _repositorioPersona.getPersonaConId(personaId);
            return persona?.tienePermiso(nombrePermiso) ?? false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<Persona?> ObtenerUsuarioActualAsync()
    {
        if (_usuarioActual != null)
        {
            try
            {
                // RECARGAR para obtener permisos actualizados
                _usuarioActual = _repositorioPersona.getPersonaConId(_usuarioActual._id);
            }
            catch (Exception)
            {
                // Mantener instancia actual si hay error
            }
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
}
// Que rol cumple esto de aca abajo? no estaba comentado
/*
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
*/

