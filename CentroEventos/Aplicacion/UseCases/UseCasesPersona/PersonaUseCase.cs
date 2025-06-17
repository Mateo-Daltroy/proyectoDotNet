using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCasesReserva;

namespace Aplicacion.UseCases.UseCasesPersona;

public abstract class PersonaUseCase(IRepositorioPersona repoPersona)
{
    protected IRepositorioPersona repo { get; } = repoPersona;
}