using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ModificarEvento (IRepositorioEventoDeportivo repositorio, IRepositorioPersona repositorioPersona):EventoDeportivoUseCases(repositorio)
//CHEQUEAR SI REPOSITORIO PERSONA ES NECESARIO PARA OPERACIONES ASOCIADAS AL RESPONSABLE DEL EVENTO
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoModificacion))
                throw new FalloAutorizacionException();

            if (!repositorio.Contiene(evento._id))
                throw new EntidadNotFoundException();

            EventoDeportivo existente = repositorio.ObtenerPorId(evento._id);
            if (existente._fechaHoraInicio < DateTime.Now)
                throw new OperacionInvalidaException("No se puede modificar un evento ya iniciado o pasado.");

            validadorEventoDeportivo.Validar(evento, repositorioPersona); 

            repositorio.Actualizar(evento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}