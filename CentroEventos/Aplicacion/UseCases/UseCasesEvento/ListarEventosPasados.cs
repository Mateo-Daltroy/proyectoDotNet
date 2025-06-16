using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ListarEventosPasados (IRepositorioEventoDeportivo repositorio):EventoDeportivoUseCases(repositorio)
{
    public IEnumerable<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> l = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in repositorio.ObtenerTodos())
        {
            if (e._fechaHoraInicio < DateTime.Now)
            {
                l.Add(e);
            }
        }
        return l;
    }
}