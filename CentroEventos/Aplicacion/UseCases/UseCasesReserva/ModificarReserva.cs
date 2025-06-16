using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;

namespace Aplicacion.UseCases.UseCasesReserva;

public class ModificarReserva
{
    public void ReservaModificacion(Reserva Res, int idUser)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUser, Permiso.ReservaModificacion)) { throw new FalloAutorizacionException(); }
            if (!_miRepo.ExisteId(Res._id)) { throw new EntidadNotFoundException(); }
            _miRepo.Actualizar(Res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}