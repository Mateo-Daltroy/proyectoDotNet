using System.Threading.Tasks;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesEvento;

public class BajaEvento (IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva, ServicioAuthProvisional servicioAuth)
:EventoDeportivoUseCases(repositorio)
{
    //ELIMINAR TAMBIEN RESERVAS ASOCIADAS
    public async Task Ejecutar(int id, int idUsuario)
    {
        try
        {
            /*
            if (!servicioAuth.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
                throw new FalloAutorizacionException();
                */
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