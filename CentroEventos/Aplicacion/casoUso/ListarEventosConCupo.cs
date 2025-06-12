using Aplicacion.entidades;

namespace Aplicacion.casoUso;

public class ListarEventosConCupo
{
    public IEnumerable<EventoDeportivo> ListarEventosConCupoDisponible(IRepositorioReserva repoReserva)
    {
        List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();

        foreach (EventoDeportivo evento in _repo.ObtenerTodos())
        {
            int participantesActuales = repoReserva.GetAsistentes(evento._id);
            if (evento.TieneCupoDisponible(participantesActuales))
            {
                eventosConCupo.Add(evento);
            }

        }

        return eventosConCupo;
    }

}