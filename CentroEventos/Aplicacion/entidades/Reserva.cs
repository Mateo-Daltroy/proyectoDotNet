using System;

namespace Aplicacion.entidades;

using System.ComponentModel.DataAnnotations;
//using Aplicacion.InterfacesRepo;
using validadores;

public class Reserva
{
    [Key] public int _id { get; set; }
    public int _personaId { get; set; }
    public int _eventoDeportivoId { get; set; }
    public DateTime _fechaAltaReserva { get; set; }
    public Asistencia _estadoAsistencia { get; set; }


    public virtual Persona ?Persona { get; set; } // La persona que reservó
    public virtual EventoDeportivo ?EventoDeportivo { get; set; } // El evento reservado

    public Reserva (int unaPer, int elEv) 
    {

        this._personaId = unaPer;
        this._eventoDeportivoId = elEv;
        this._fechaAltaReserva = DateTime.Now;
        this._estadoAsistencia = Asistencia.Pendiente;
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
