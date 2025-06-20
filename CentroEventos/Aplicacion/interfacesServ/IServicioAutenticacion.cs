using System;
using Aplicacion.entidades;

namespace Aplicacion.interfacesServ;

public interface IServicioAutenticacion
{
    public static int cont = 0;
    Task<Persona?> AutenticarAsync(string email, string contraseña);
    bool TienePermisoAsync(string nombrePermiso);
    Task<Persona?> ObtenerUsuarioActualAsync();
    Task IniciarSesionAsync(Persona persona);
    Task CerrarSesionAsync();
    bool EstaAutenticado { get; }
    Persona? UsuarioActual { get; }

    // METODOS DE PERMISOS
    Task<List<Permiso>> ObtenerPermisosUsuarioActualAsync();
    Task<List<Permiso>> ObtenerPermisosDisponiblesUsuarioActualAsync();
    Task<bool> UsuarioActualTienePermisoAsync(string nombrePermiso);
}