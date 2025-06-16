using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarTodosLosEventos (IRepositorioEventoDeportivo repositorio):EventoDeportivoUseCases(repositorio)
{
    public IEnumerable<EventoDeportivo> Ejecutar()
    {
        return repositorio.ObtenerTodos();
    }
}