using Aplicacion.entidades;

namespace Aplicacion.casoUso;

public class ObtenerReservaPorId
{
    public Reserva obtenerPorId(int id)
    {
        return _miRepo.ObtenerPorId(id);
    }
}