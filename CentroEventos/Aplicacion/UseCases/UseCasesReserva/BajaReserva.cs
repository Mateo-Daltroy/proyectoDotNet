using Aplicacion.autorizacionProv;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
namespace Aplicacion.UseCases.UseCasesReserva;

public class BajaReserva (IRepositorioReserva repositorio) : ReservaUseCase(repositorio)
{
    public void Ejecutar(int idRes/*, int idUser*/)
    {
        try
        {
            //if (!_auth.PoseeElPermiso(idUser, Permiso.ReservaBaja)) { throw new FalloAutorizacionException(); }
            if (!repo.ExisteId(idRes)) { throw new EntidadNotFoundException(); }
            repo.Eliminar(idRes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}