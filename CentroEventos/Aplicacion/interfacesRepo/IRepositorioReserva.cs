using System;
using Aplicacion.entidades;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioReserva
{
    void Agregar(Reserva evento);
    Reserva ObtenerPorId(int id); 
    // saque el nulleable "?" porque me generaba una warning de null en validadorReserva
    // probablemente si no lo encuentra deberia hacer un throw EntidadNotFoundException 
    IEnumerable<Reserva> ObtenerTodos();
    void Actualizar(Reserva evento);
    void Eliminar(int id);
    Boolean Contiene(int idPers, int idEv); //retorna si existe un evento bajo el id, lo necesito para validar una reserva - mate
    int GetAsistentes(int idEv);
}
