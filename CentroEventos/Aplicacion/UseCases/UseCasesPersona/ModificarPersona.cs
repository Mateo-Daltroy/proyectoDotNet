using Aplicacion.entidades;
using Aplicacion.UseCases;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ModificarPersona (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public void modificarPersona(Persona p)
    {
        repo.Actualizar(p._dni ,p);
    }
}