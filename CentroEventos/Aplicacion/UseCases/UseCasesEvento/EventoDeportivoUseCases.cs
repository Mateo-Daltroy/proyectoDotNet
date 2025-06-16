using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases;

public abstract class EventoDeportivoUseCases(IRepositorioEventoDeportivo repositorio)
{
protected IRepositorioEventoDeportivo Repositorio { get; } = repositorio;
}