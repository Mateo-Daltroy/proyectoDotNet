using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesReserva;

public class ListarPersonasAsistidasAEvento (IRepositorioReserva repositorio) : ReservaUseCase(repositorio)
{
    public IEnumerable<int> Ejecutar(int idEv)
    {
        List<Reserva> reservas = (List<Reserva>)repo.ObtenerTodos();
        List<int> cumplen = new();
        foreach (Reserva res in reservas)
        {
            if (res._eventoDeportivoId == idEv && res._estadoAsistencia == Asistencia.Presente)
                cumplen.Add(res._id);
        }
        return cumplen;
    }
}