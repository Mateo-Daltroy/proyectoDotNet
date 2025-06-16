using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesReserva;

public class ObtenerReservaPorId
{
    public Reserva obtenerPorId(int id)
    {
        return _miRepo.ObtenerPorId(id);
    }
}