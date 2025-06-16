using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ObetenerEventoPorId (IRepositorioEventoDeportivo repositorio):EventoDeportivoUseCases(repositorio)
{
    public EventoDeportivo obtenerPorId(int id)
    {

        return _repo.ObtenerPorId(id);

    }
}