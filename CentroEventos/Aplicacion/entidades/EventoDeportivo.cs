using System;



using Aplicacion.validadores;
using Aplicacion.interfacesRepo;
using System.Data.Common;


namespace Aplicacion.entidades
{
    public class EventoDeportivo
    {
        // Propiedades
        public int _id { get; }
        public string _nombre { get; set; }
        public string _descripcion { get; set; }
        public DateTime _fechaHoraInicio { get; set; }
        public double _duracionHoras { get; set; }
        public int _cupoMaximo { get; set; }
        public int _responsableId { get; }

        // Constructor con validaciones
        public EventoDeportivo(
            int id,
            string nombre,
            string descripcion,
            DateTime fechaHoraInicio,
            double duracionHoras,
            int cupoMaximo,
            int responsableId)
        {
            // Validaciones se haran a la hora de hacer el ALTA
            this._id = id;
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._fechaHoraInicio = fechaHoraInicio;
            this._duracionHoras = duracionHoras;
            this._cupoMaximo = cupoMaximo;
            this._responsableId = responsableId; //MODIFICAR PARA USAR LA INTERFAZ
        }
        // CONSTRUCTOR SIN ID
        public EventoDeportivo(
            string nombre,
            string descripcion,
            DateTime fechaHoraInicio,
            double duracionHoras,
            int cupoMaximo,
            int responsableId)
        {
            // Validaciones se haran a la hora de hacer el ALTA
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._fechaHoraInicio = fechaHoraInicio;
            this._duracionHoras = duracionHoras;
            this._cupoMaximo = cupoMaximo;
            this._responsableId = responsableId; //MODIFICAR PARA USAR LA INTERFAZ
        }

        public DateTime ObtenerFechaHoraFin()
        {
            return _fechaHoraInicio.AddHours(_duracionHoras);
        }

        public bool TieneCupoDisponible(int participantesActuales)
        {
            return participantesActuales < _cupoMaximo;
        }

        public override String ToString()
        {
            return $"idEvento: {_id}, Evento: {_nombre}, Descripcion: {_descripcion}, Fecha y Hora: {_fechaHoraInicio}, Duracion: {_duracionHoras} horas, Cupo Maximo: {_cupoMaximo}, Responsable ID: {_responsableId}";
        }
    }
}