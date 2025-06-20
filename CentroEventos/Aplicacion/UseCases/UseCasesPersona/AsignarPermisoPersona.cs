using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCasesPersona;
public class AsignarPermisoAPersona (IRepositorioPersona _repoPersona, IRepositorioPermiso _repoPermiso) : PersonaUseCase(_repoPersona)
{ 
    public void Ejecutar(int personaId, string nombrePermiso)
    {
        var permiso = _repoPermiso.obtenerPorNombre(nombrePermiso);
        if (permiso != null)
        {
            _repoPersona.agregarPermiso(personaId, permiso);
        }
    }
}