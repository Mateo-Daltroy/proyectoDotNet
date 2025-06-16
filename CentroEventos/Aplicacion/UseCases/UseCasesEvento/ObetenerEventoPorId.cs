using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ObetenerEventoPorId
{
    public EventoDeportivo obtenerPorId(int id)
    {

        return _repo.ObtenerPorId(id);

    }
}