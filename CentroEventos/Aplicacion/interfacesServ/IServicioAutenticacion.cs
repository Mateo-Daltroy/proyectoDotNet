using System;
using Aplicacion.entidades;

namespace Aplicacion.interfacesServ;

public interface IServicioAutenticacion
{
    Task<Persona?> AutenticarAsync(string email, string contraseña);
    Task<bool> TienePermisoAsync(int personaId, string nombrePermiso);
    Task<Persona?> ObtenerUsuarioActualAsync();
    Task IniciarSesionAsync(Persona persona);
    Task CerrarSesionAsync();
    bool EstaAutenticado { get; }
    Persona? UsuarioActual { get; }
}