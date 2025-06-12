using Aplicacion.entidades;

namespace Aplicacion.casoUso;

public class ListarPersonasAsistidasAEvento
{
    public IEnumerable<int> asistioAEvento(int idEv)
    {
        List<Reserva> reservas = (List<Reserva>)_miRepo.ObtenerTodos();
        List<int> cumplen = new();
        foreach (Reserva res in reservas)
        {
            if (res._eventoDeportivoId == idEv && res._estadoAsistencia == Asistencia.Presente)
                cumplen.Add(res._id);
        }
        return cumplen;
    }
}