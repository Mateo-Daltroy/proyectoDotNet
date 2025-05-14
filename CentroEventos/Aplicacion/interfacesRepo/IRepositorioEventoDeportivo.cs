using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.InterfacesRepo;
public interface IRepositorioEventoDeportivo
{
    void Agregar(EventoDeportivo evento);
    EventoDeportivo? ObtenerPorId(int id);
    IEnumerable<EventoDeportivo> ObtenerTodos();
    void Actualizar(EventoDeportivo evento);
    void Eliminar(int id);
}