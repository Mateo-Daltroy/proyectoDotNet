using System;

namespace Aplicacion.entidades;

using CentroEventos.Aplicacion.InterfacesRepo;
using validadores;

public class Reserva
{
    public int _id { get; }
    public int _personaId { get; }
    public int _eventoDeportivoId { get; }
    public DateTime _fechaAltaReserva { get; set; }
    public Asistencia _estadoAsistencia { get; set; }

    public Reserva (int unaPer, int elEv, IIdManager proveedor) 
    {
            ValidadorReserva.validarDatos(unaPer, elEv, DateTime.Now);
            // validarDatos tira una excep, se tiene que manejar arriba porque no podes prevenir
            // que el constructor cree el objeto, asi que tiene mas sentido simplemente no escribirlo
            this._personaId = unaPer;
            this._eventoDeportivoId = elEv;
            this._fechaAltaReserva = DateTime.Now;
            this._estadoAsistencia = Asistencia.Pendiente;
            this._id = proveedor.obtenerNuevoId("Placeholder"); // To-Do: poner el path
    }

    public string toString() 
    {
        return($"idRes: {_id, -3} idPers: {_personaId, -3}, idEv: {_eventoDeportivoId, -3}, fecha: {_fechaAltaReserva.toString("d")}, estado: {_estadoAsistencia, -9}")
    }

}
