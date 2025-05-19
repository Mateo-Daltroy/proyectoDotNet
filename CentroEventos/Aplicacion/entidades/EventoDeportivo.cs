using System;

/*
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;
*/
// los imports no se hacen asi por lo general, siendo que tu clase esta en CentroEventos.Aplicacion
// harias un import del Aplicacion.directorio, recordando que no estan nombrados con mayuscula primero
// mira CreadorReservas en interfacesServ para ver un codigo que hace muchos imports dentro de la misma solucion

using Aplicacion.validadores;
using Aplicacion.interfacesRepo;


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
            int responsableId,
            IRepositorioPersona repositorioPersona)
        {
            // Validaciones
            if (!ValidadorEventoDeportivo.ValidarNombre(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            if (!ValidadorEventoDeportivo.ValidarDescripcion(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
            if (!ValidadorEventoDeportivo.ValidarFechaHoraInicio(fechaHoraInicio))
                throw new ArgumentException("La fecha y hora de inicio debe ser igual o posterior a la actual.", nameof(fechaHoraInicio));
            if (!ValidadorEventoDeportivo.ValidarDuracionHoras(duracionHoras))
                throw new ArgumentException("La duración debe ser mayor que cero.", nameof(duracionHoras));
            if (!ValidadorEventoDeportivo.ValidarCupoMaximo(cupoMaximo))
                throw new ArgumentException("El cupo máximo debe ser mayor que cero.", nameof(cupoMaximo));
            if (!repositorioPersona.ExistePersona(responsableId))
                throw new ArgumentException("El responsable no existe.", nameof(responsableId));

            this._id = IdManager.obtenerNuevoId("id_eventos.txt");  //NO HARDCODEAR PATH
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
    }
}