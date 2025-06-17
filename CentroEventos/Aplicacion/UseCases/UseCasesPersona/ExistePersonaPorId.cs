using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ExistePersonaPorId (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public Boolean Ejecutar(int id)
    {
        return repositorio.ExisteId(id);
    }
}