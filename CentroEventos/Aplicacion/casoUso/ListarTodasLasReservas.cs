using Aplicacion.entidades;

namespace Aplicacion.casoUso;

public class ListarTodasLasReservas
{
    public IEnumerable<Reserva> ListarTodas()
    {
        return (_miRepo.ObtenerTodos());
    }
}