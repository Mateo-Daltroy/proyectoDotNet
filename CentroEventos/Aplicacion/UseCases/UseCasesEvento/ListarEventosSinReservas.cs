using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarEventosSinReservas (IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva):EventoDeportivoUseCases(repositorio)
{
    public IEnumerable<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> l = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in repositorio.ObtenerTodosAsync().Result)
        {
            if (repositorioReserva.GetAsistentes(e._id) == 0)
            {
                l.Add(e);
            }
        }
        return l;
    }
}