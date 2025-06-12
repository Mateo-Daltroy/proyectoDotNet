using Aplicacion.entidades;
using Aplicacion.validadores;


namespace Aplicacion.casoUso;

public class AltaEvento
{
    public void Alta(EventoDeportivo evento, int idUsuario, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
                throw new FalloAutorizacionException();

            validadorEventoDeportivo.Validar(evento, _repoPersona);

            int nuevoId = _gestor.ObtenerNuevoId(_pathId);
            EventoDeportivo eventoFinal = new(
                id: nuevoId,
                nombre: evento._nombre,
                descripcion: evento._descripcion,
                fechaHoraInicio: evento._fechaHoraInicio,
                duracionHoras: evento._duracionHoras,
                cupoMaximo: evento._cupoMaximo,
                responsableId: evento._responsableId
            );

            _repo.Agregar(eventoFinal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}