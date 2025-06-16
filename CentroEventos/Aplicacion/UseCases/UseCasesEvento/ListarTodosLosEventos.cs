using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarTodosLosEventos (IRepositorioEventoDeportivo repositorio):EventoDeportivoUseCases(repositorio)
{
    public IEnumerable<EventoDeportivo> Listado()
    {
        return repositorio.ObtenerTodos();
    }
}