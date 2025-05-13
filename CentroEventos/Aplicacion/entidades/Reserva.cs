using System;
using Console;

namespace Aplicacion.entidades;

public class Reserva
{
    public int _id { get; }
    public int _personaId { get; }
    public int _eventoDeportivoId { get; }
    public DateTime _fechaAltaReserva { get; set; }
    public Asistencia _estadoAsistencia { get; set; }

    public Reserva (int unaPer, int elEv) 
    {
        try {
            //ValidadorReserva.validarDatos(unaPer, elEv, new DateTime Now);
            this._personaId = unaPer;
            this._eventoDeportivoId = elEv;
            this._fechaAltaReserva = new DateTime Now;
            this._estadoAsistencia = Pendiente;
            this._id = IdManager.obtenerNuevoId("Placeholder"); // To-Do: poner el path
        } catch {
            Console.writeln("To-Do excepcion");
        }
    }

    @Override
    public string toString() 
    {
        return($"idRes: {_id, -3} idPers: {_personaId, -3}, idEv: {_eventoDeportivoId, -3}, fecha: {_fechaAltaReserva.toString("d")}, estado: {_estadoAsistencia, -9}")
    }

}
