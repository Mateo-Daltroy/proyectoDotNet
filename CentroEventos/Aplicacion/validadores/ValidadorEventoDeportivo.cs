using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.validadores
{
    public class ValidadorEventoDeportivo
    {
        public static bool ValidarNombre(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre);
        }

        public static bool ValidarDescripcion(string descripcion)
        {
            return !string.IsNullOrWhiteSpace(descripcion);
        }

        public static bool ValidarFechaHoraInicio(DateTime fechaHoraInicio)
        {
            return fechaHoraInicio >= DateTime.Now;
        }

        public static bool ValidarDuracionHoras(double duracionHoras)
        {
            return duracionHoras > 0;
        }

        public static bool ValidarCupoMaximo(int cupoMaximo)
        {
            return cupoMaximo > 0;
        }
        public static bool ValidarResponsable(int responsableId, IRepositorioPersona repoPersona)
        {
            return repoPersona.ExisteId(responsableId));
        }

        public void Validar(EventoDeportivo evento, IRepositorioPersona repoPersona)
        {
            if (!ValidarNombre(evento._nombre))
                throw new ValidacionException("El nombre no puede estar vacío.");

            if (!ValidarDescripcion(evento._descripcion))
                throw new ValidacionException("La descripción no puede estar vacía.");

            if (!ValidarFechaHoraInicio(evento._fechaHoraInicio))
                throw new ValidacionException("La fecha de inicio debe ser igual o posterior a la actual.");

            if (!ValidarDuracionHoras(evento._duracionHoras))
                throw new ValidacionException("La duración debe ser mayor que cero.");

            if (!ValidarCupoMaximo(evento._cupoMaximo))
                throw new ValidacionException("El cupo máximo debe ser mayor que cero.");

            if (!ValidarResponsable(evento._responsableId, repoPersona))
                throw new EntidadNotFoundException("El responsable especificado no existe.");
        }

    }
}