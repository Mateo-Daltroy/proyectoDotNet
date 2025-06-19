using Aplicacion.interfacesServ;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;

namespace Aplicacion.UseCases.UseCasesReserva;

public class AltaReserva (IRepositorioReserva repositorio, IRepositorioPersona _repoPers, IRepositorioEventoDeportivo _repoEv) : ReservaUseCase(repositorio)
{
    public void Ejecutar(int idPers, int idEv/*, int idUser*/)
    {
        try
        {
            //if (!_auth.PoseeElPermiso(idUser, Permiso.ReservaAlta)) { throw new FalloAutorizacionException(); }
            string mensaje = "";
            if (!ValidadorReserva.validarDatos(idPers, idEv, DateTime.Now, repo, _repoEv, _repoPers, ref mensaje))
            {
                throw new ValidacionException(mensaje);
            }
            //int id = _gestor.ObtenerNuevoId(_pathId);
            Reserva resGenerada = new(idPers, idEv);
            this.repo.Agregar(resGenerada);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}