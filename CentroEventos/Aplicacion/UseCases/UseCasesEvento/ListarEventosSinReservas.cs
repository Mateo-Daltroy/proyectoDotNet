using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarEventosSinReservas (IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva):EventoDeportivoUseCases(repositorio)
{
    public IEnumerable<EventoDeportivo> ejecutar()
    {
        List<EventoDeportivo> l = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in repositorio.ObtenerTodos())
        {
            if (repositorioReserva.GetAsistentes(e._id) == 0)
            {
                l.Add(e);
            }
        }
        return l;
    }
}