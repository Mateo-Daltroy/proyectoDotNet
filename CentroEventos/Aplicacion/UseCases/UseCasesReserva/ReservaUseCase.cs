using System;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesReserva;

public abstract class ReservaUseCase (IRepositorioReserva repositorio)
{
    protected IRepositorioReserva repo { get; } = repositorio;
}
