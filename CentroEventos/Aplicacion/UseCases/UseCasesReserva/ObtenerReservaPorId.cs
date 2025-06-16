using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesReserva;

public class ObtenerReservaPorId (IRepositorioReserva repositorio) : ReservaUseCase(repositorio)
{
    public Reserva Ejecutar(int id)
    {
        return repo.ObtenerPorId(id);
    }
}