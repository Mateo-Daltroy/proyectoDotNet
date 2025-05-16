using CentroEventos.Aplicacion.Entidades;

namespace Aplicacion.interfacesRepo;
public interface IRepositorioEventoDeportivo
{
    void Agregar(EventoDeportivo evento);
    EventoDeportivo ObtenerPorId(int id); 
    // saque el nulleable "?" porque me generaba una warning de null en validadorReserva
    // probablemente si no lo encuentra deberia hacer un throw EntidadNotFoundException 
    IEnumerable<EventoDeportivo> ObtenerTodos();
    void Actualizar(EventoDeportivo evento);
    void Eliminar(int id);
    Boolean Contiene(int id); //retorna si existe un evento bajo el id, lo necesito para validar una reserva - mate
}