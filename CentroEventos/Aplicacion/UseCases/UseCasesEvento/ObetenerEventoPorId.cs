using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ObtenerEventoPorId (IRepositorioEventoDeportivo repositorio):EventoDeportivoUseCases(repositorio)
{
    public EventoDeportivo Ejecutar(int id)
    {

        return repositorio.ObtenerPorId(id);

    }
}