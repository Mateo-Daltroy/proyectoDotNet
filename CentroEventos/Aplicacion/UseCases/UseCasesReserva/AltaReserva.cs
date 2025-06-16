using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.validadores;

namespace Aplicacion.UseCases.UseCasesReserva;

public class AltaReserva
{
    public void ReservaAlta(int idPers, int idEv, int idUser)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUser, Permiso.ReservaAlta)) { throw new FalloAutorizacionException(); }
            ValidadorReserva.validarDatos(idPers, idEv, DateTime.Now, _miRepo, _repoEv, _repoPers);
            int id = _gestor.ObtenerNuevoId(_pathId);
            Reserva resGenerada = new(idPers, idEv, id);
            this._miRepo.Agregar(resGenerada);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}