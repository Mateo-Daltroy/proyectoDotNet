using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarTodosLosEventos
{
    public IEnumerable<EventoDeportivo> Listado()
    {
        return _repo.ObtenerTodos();
    }

    public IEnumerable<EventoDeportivo> listadoSinReservas()
    {
        List<EventoDeportivo> l = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in _repo.ObtenerTodos())
        {
            if (_repoReserva.GetAsistentes(e._id) == 0)
            {
                l.Add(e);
            }
        }
        return l;
    }
}