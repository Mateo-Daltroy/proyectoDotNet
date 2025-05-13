using System;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.Entidades
{
    public class EventoDeportivo
    {
        // Propiedades
        public int Id { get; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public double DuracionHoras { get; set; }
        public int CupoMaximo { get; set; }
        public int ResponsableId { get; }

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

            Id = IdManager.ObtenerNuevoId("id_eventos.txt");  //NO HARDCODEAR PATH
            Nombre = nombre;
            Descripcion = descripcion;
            FechaHoraInicio = fechaHoraInicio;
            DuracionHoras = duracionHoras;
            CupoMaximo = cupoMaximo;
            ResponsableId = responsableId; //MODIFICAR PARA USAR LA INTERFAZ
        }

        public int Id{
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public DateTime FechaHoraInicio
        {
            get { return _fechaHoraInicio; }
            set { _fechaHoraInicio = value; }
        }

        public double DuracionHoras
        {
            get { return _duracionHoras; }
            set { _duracionHoras = value; }
        }

        public int CupoMaximo
        {
            get { return _cupoMaximo; }
            set { _cupoMaximo = value; }
        }

        public int ResponsableId
        {
            get { return _responsableId; }
        }

        public DateTime ObtenerFechaHoraFin()
        {
            return FechaHoraInicio.AddHours(DuracionHoras);
        }

        public bool TieneCupoDisponible(int participantesActuales)
        {
            return participantesActuales < CupoMaximo;
        }
    }
}