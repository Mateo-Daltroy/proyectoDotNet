using System;
using Aplicacion.validadores;
using Aplicacion.interfacesRepo;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion.entidades
{
    public class EventoDeportivo
    {
        [Key] public int _id { get; set;}
        public string _nombre { get; set; }
        public string _descripcion { get; set; }
        public DateTime _fechaHoraInicio { get; set; }
        public double _duracionHoras { get; set; }
        public int _cupoMaximo { get; set; }
        public int _responsableId { get; set; }

        public virtual Persona ?Responsable { get; set; } //responsable del evento
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>(); //reservas del evento

        public EventoDeportivo(
            string nombre,
            string descripcion,
            DateTime fechaHoraInicio,
            double duracionHoras,
            int cupoMaximo,
            int responsableId)
        {
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._fechaHoraInicio = fechaHoraInicio;
            this._duracionHoras = duracionHoras;
            this._cupoMaximo = cupoMaximo;
            this._responsableId = responsableId;
            this.Reservas = new List<Reserva>(); 
        }

        protected EventoDeportivo() // Lo pide Entity Framework Core
        {
            _nombre = string.Empty;
            _descripcion = string.Empty;
            Reservas = new List<Reserva>(); 
        }            

        // Métodos originales
        public DateTime ObtenerFechaHoraFin()
        {
            return _fechaHoraInicio.AddHours(_duracionHoras);
        }

        public bool TieneCupoDisponible(int participantesActuales)
        {
            return participantesActuales < _cupoMaximo;
        }

        public bool TieneCupoDisponible()
        {
            return Reservas.Count < _cupoMaximo;
        }

        public override String ToString()
        {
            return $"idEvento: {_id}, Evento: {_nombre}, Descripcion: {_descripcion}, Fecha y Hora: {_fechaHoraInicio}, Duracion: {_duracionHoras} horas, Cupo Maximo: {_cupoMaximo}, Responsable ID: {_responsableId}";
        }
    }
}