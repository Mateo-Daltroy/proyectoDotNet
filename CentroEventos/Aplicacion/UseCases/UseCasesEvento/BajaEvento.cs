using System.Threading.Tasks;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;

namespace Aplicacion.UseCases.UseCasesEvento;

public class BajaEvento (IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva, IServicioAutenticacion servicioAuth)
:EventoDeportivoUseCases(repositorio)
{
    //ELIMINAR TAMBIEN RESERVAS ASOCIADAS
    public async Task Ejecutar(int id, int idUsuario)
    {
        try
        {

            if (!await repositorio.ContieneAsync(id))
                throw new EntidadNotFoundException();

            repositorioReserva.EliminarPorEvento(id);
            await repositorio.EliminarAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}