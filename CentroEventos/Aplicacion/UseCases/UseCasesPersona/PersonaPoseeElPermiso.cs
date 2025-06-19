using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class PersonaPoseeElPermiso (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public Boolean Ejecutar(int id, String permiso)
    {
        return repositorio.PoseeElPermiso(id, permiso);
    }
}