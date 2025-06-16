using Aplicacion.autorizacionProv;
using Aplicacion.excepciones;
namespace Aplicacion.UseCases.UseCasesReserva;

public class BajaReserva
{
    public void ReservaBaja(int idRes, int idUser)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUser, Permiso.ReservaBaja)) { throw new FalloAutorizacionException(); }
            if (!_miRepo.ExisteId(idRes)) { throw new EntidadNotFoundException(); }
            _miRepo.Eliminar(idRes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}