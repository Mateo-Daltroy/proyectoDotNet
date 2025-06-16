using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarEventosPasados
{
    public IEnumerable<EventoDeportivo> ListadoPasado()
    {
        List<EventoDeportivo> l = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in _repo.ObtenerTodos())
        {
            if (e._fechaHoraInicio < DateTime.Now)
            {
                l.Add(e);
            }
        }
        return l;
    }
}