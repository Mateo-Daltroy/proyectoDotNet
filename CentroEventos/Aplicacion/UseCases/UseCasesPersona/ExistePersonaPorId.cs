using Aplicacion.UseCases.UseCases;
using Aplicacion.UseCases.UseCasesReserva;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ExistePersonaPorId (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public Boolean ExisteId(int id)
    {
        var persona = repositorio.ExistePersonaPorId(id);
        return persona != null;
    }
}