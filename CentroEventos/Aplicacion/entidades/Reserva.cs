using System;

namespace Aplicacion.entidades;

using CentroEventos.Aplicacion.InterfacesRepo;
using validadores;

public class Reserva
{
    public int _id { get; }
    public int _personaId { get; }
    public int _eventoDeportivoId { get; }
    public DateTime _fechaAltaReserva { get; }
    public Asistencia _estadoAsistencia { get; set; }

    public Reserva (int unaPer, int elEv, int id) 
    {
        // No se deberian crear reservas directamente desde new Reserva, 
        // usar el metodo de CreadorReservas, que asegura una validacion apropiada
        this._personaId = unaPer;
        this._eventoDeportivoId = elEv;
        this._fechaAltaReserva = DateTime.Now;
        this._estadoAsistencia = Asistencia.Pendiente;
        this._id = id;
    }

    public Reserva(int idPropio, int idPers, int idEv, DateTime fecha, Asistencia unEstado)
    {
        // Este metodo lo utiliza RepoReservasTxt para transformar los strings del .txt en instancias de Reserva
        this._personaId = idPers;
        this._eventoDeportivoId = idEv;
        this._fechaAltaReserva = fecha;
        this._estadoAsistencia = unEstado;
        this._id = idPropio;
    }

    protected Reserva()
    {
        // Constructor protegido sin parametros para Entity Framework Core
    }
    
    public override string ToString()
    {
        return ($"[idRes: {_id,-3} idPers: {_personaId,-3}, idEv: {_eventoDeportivoId,-3}, fecha: {_fechaAltaReserva}, estado: {_estadoAsistencia,-9}]");
    }

}
