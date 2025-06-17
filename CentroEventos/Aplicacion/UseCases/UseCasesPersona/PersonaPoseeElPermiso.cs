using Aplicacion.autorizacionProv;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class PersonaPoseeElPermiso (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {
        return repo.PoseeElPermiso(id,permiso);
    }
}