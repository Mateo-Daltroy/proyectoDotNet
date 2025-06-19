using Aplicacion.interfacesRepo;
public class AsignarPermisoAPersona
{
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioPermiso _repoPermiso; 
    public void Ejecutar(int personaId, string nombrePermiso)
    {
        var permiso = _repoPermiso.obtenerPorNombre(nombrePermiso);
        if (permiso != null)
        {
            _repoPersona.agregarPermiso(personaId, permiso);
        }
    }
}