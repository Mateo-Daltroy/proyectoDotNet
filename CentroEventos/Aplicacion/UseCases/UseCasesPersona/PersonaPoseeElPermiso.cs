using Aplicacion.autorizacionProv;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class PersonaPoseeElPermiso (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public Boolean Ejecutar(int id, Permiso permiso)
    {
        return repositorio.PoseeElPermiso(id,permiso);
    }
}