

using Aplicacion.autorizacionProv;
using Aplicacion.excepciones;

namespace Aplicacion.UseCases.UseCasesEvento;

public class Ejecutar (IRepositorioEventoDeportivo repositorio, IRepositorioReserva repositorioReserva):EventoDeportivoUseCases(repositorio)
{
    //ELIMINAR TAMBIEN RESERVAS ASOCIADAS
    public void Baja(int id, int idUsuario)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
                throw new FalloAutorizacionException();

            if (!repositorio.Contiene(id))
                throw new EntidadNotFoundException();

            repositorioReserva.EliminarPorEvento(id);
            repositorio.Eliminar(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}