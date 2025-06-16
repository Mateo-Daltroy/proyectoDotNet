using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesReserva;

public class ListarTodasLasReservas (IRepositorioReserva repositorio) : ReservaUseCase(repositorio)
{
    public IEnumerable<Reserva> Ejecutar()
    {
        return (repo.ObtenerTodos());
    }
}