using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesReserva;

public class ListarTodasLasReservas
{
    public IEnumerable<Reserva> ListarTodas()
    {
        return (_miRepo.ObtenerTodos());
    }
}