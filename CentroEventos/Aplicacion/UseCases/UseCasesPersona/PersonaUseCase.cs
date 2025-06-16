using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCasesReserva;

namespace Aplicacion.UseCases.UseCases;

public abstract class PersonaUseCase(IRepositorioPersona repoPersona)
{
    protected IRepositorioPersona repo { get; } = repoPersona;
}