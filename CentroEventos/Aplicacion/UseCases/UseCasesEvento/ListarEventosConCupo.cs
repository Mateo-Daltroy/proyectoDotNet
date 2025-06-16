using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarEventosConCupo (IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva):EventoDeportivoUseCases(repositorio)
{
    public IEnumerable<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();

        foreach (EventoDeportivo evento in repositorio.ObtenerTodos())
        {
            int participantesActuales = repositorioReserva.GetAsistentes(evento._id);
            if (evento.TieneCupoDisponible(participantesActuales))
            {
                eventosConCupo.Add(evento);
            }

        }

        return eventosConCupo;
    }

}