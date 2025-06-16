using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ModificarEvento
{
    public void Modificacion(EventoDeportivo evento, int idUsuario, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoModificacion))
                throw new FalloAutorizacionException();

            if (!_repo.Contiene(evento._id))
                throw new EntidadNotFoundException();

            EventoDeportivo existente = _repo.ObtenerPorId(evento._id);
            if (existente._fechaHoraInicio < DateTime.Now)
                throw new OperacionInvalidaException("No se puede modificar un evento ya iniciado o pasado.");

            validadorEventoDeportivo.Validar(evento, _repoPersona);

            _repo.Actualizar(evento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}