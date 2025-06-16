using System.Threading.Tasks;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;

namespace Aplicacion.UseCases.UseCasesEvento;

public class AltaEvento (IRepositorioEventoDeportivo repositorio, IRepositorioPersona repositorioPersona, ServicioAuthProvisional servicioAuth):EventoDeportivoUseCases(repositorio)
{
    public async Task Ejecutar(EventoDeportivo evento, int idUsuario, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        try
        {
            if (!servicioAuth.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
                throw new FalloAutorizacionException();

            validadorEventoDeportivo.Validar(evento, repositorioPersona);

            EventoDeportivo eventoFinal = new(
                nombre: evento._nombre,
                descripcion: evento._descripcion,
                fechaHoraInicio: evento._fechaHoraInicio,
                duracionHoras: evento._duracionHoras,
                cupoMaximo: evento._cupoMaximo,
                responsableId: evento._responsableId
            );

            await repositorio.AgregarAsync(eventoFinal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}