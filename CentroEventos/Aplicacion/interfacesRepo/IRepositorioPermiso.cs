using Aplicacion.entidades;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioPermiso
{
    List<Permiso> obtenerTodos();
    Permiso? obtenerPorId(int id);
    Permiso? obtenerPorNombre(string nombre);
    List<Permiso> obtenerPermisosDePersona(int personaId);
    List<Permiso> obtenerPermisosDisponiblesParaPersona(int personaId);
}