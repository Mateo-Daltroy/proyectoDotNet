using System;
using Aplicacion.entidades;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using Aplicacion.excepciones;
using CentroEventos.Aplicacion.InterfacesRepo;
using Aplicacion.autorizacionProv;
using Aplicacion.interfacesServ;

namespace Repositorios.CRUDs;

public class CRUDReserva
{
    IRepositorioReserva _miRepo;
    IRepositorioEventoDeportivo _repoEv;
    IRepositorioPersona _repoPers;
    IIdManager _gestor;
    IServicioAutorizacion _auth;

    public CRUDReserva(IRepositorioReserva unRepo, IRepositorioEventoDeportivo repositorioEvento,
                           IRepositorioPersona persona, IIdManager manager)
    {
        this._miRepo = unRepo;
        this._repoEv = repositorioEvento;
        this._repoPers = persona;
        this._gestor = manager;
        this._auth = new ServicioAuthProvisional();
    }

    public void ReservaAlta(int idPers, int idEv, int idUser)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUser, Permiso.ReservaAlta)) { throw new FalloAutorizacionException(); }
            ValidadorReserva.validarDatos(idPers, idEv, DateTime.Now, _miRepo, _repoEv, _repoPers);
            int id = _gestor.ObtenerNuevoId();
            Reserva resGenerada = new(idPers, idEv, id);
            this._miRepo.Agregar(resGenerada);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ReservaBaja(int idRes)
    {
        try
        {
            if (!_miRepo.ExisteId(idRes)) { throw new EntidadNotFoundException(); }
            _miRepo.Eliminar(idRes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ReservaModificacion(Reserva Res)
    {
        try
        {
            if (!_miRepo.ExisteId(Res._id)) { throw new EntidadNotFoundException(); }
            _miRepo.Actualizar(Res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}
