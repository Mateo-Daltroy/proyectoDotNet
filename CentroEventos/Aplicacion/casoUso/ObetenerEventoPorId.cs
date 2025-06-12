using Aplicacion.entidades;

namespace Aplicacion.casoUso;

public class ObetenerEventoPorId
{
    public EventoDeportivo obtenerPorId(int id)
    {

        return _repo.ObtenerPorId(id);

    }
}