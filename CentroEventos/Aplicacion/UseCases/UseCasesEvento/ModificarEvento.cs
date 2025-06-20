using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;

namespace Aplicacion.UseCases.UseCasesEvento;

public class ModificarEvento (IRepositorioEventoDeportivo repositorio, IRepositorioPersona repositorioPersona):EventoDeportivoUseCases(repositorio)
//CHEQUEAR SI REPOSITORIO PERSONA ES NECESARIO PARA OPERACIONES ASOCIADAS AL RESPONSABLE DEL EVENTO
{
    public void Ejecutar(EventoDeportivo evento, int idUsuario, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        try
        {

            if (!repositorio.ContieneAsync(evento._id).Result)
                throw new EntidadNotFoundException();

            EventoDeportivo existente = repositorio.ObtenerPorIdAsync(evento._id).Result;
            if (existente._fechaHoraInicio < DateTime.Now)
                throw new OperacionInvalidaException("No se puede modificar un evento ya iniciado o pasado.");

            validadorEventoDeportivo.Validar(evento, repositorioPersona); 

            repositorio.ActualizarAsync(evento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}