using System;
using Aplicacion.entidades;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioReserva
{
    void Agregar(Reserva res);
    Reserva ObtenerPorId(int id); 
    // saque el nulleable "?" porque me generaba una warning de null en validadorReserva
    // probablemente si no lo encuentra deberia hacer un throw EntidadNotFoundException 
    IEnumerable<Reserva> ObtenerTodos();
    void Actualizar(Reserva res);
    void Actualizar(int id);
    void Eliminar(int id);
    void Eliminar(Reserva res);
    bool ExisteId(int idPers, int idEv); //retorna si existe un evento bajo el id, lo necesito para validar una reserva - mate
    bool ExisteId(int idRes); 
    int GetAsistentes(int idEv); //retorna la cantidad de asistentes a un evento
}
