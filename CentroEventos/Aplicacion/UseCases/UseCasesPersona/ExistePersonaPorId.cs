using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCases;
using Aplicacion.UseCases.UseCasesReserva;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ExistePersonaPorId (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public Boolean Ejecutar(int id)
    {
        return repositorio.ExisteId(id);
        
    }
}