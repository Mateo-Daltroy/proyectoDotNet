using System;
using Aplicacion.entidades;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using Aplicacion.excepciones;
using CentroEventos.Aplicacion.InterfacesRepo;
using Aplicacion.autorizacionProv;

namespace Aplicacion.interfacesServ;

public class CreadorReservas
{
    IRepositorioReserva _miRepo;
    IRepositorioEventoDeportivo _repoEv;
    IRepositorioPersona _repoPers;
    IIdManager _gestor;
    IServicioAutorizacion _auto;

    public CreadorReservas(IRepositorioReserva unRepo, IRepositorioEventoDeportivo repositorioEvento,
                           IRepositorioPersona persona, IIdManager manager)
    {
        this._miRepo = unRepo;
        this._repoEv = repositorioEvento;
        this._repoPers = persona;
        this._gestor = manager;
        this._auto = new ServicioAuthProvisional();
    }

    public void GenerarReserva(int idPers, int idEv, int idUser)
    {
        DateTime ahora = DateTime.Now;
        try 
        {
            _auto.PoseeElPermiso(idUser, new ReservaAltaPer());
            ValidadorReserva.validarDatos(idPers, idEv, ahora, _miRepo, _repoEv, _repoPers);
            int id = _gestor.obtenerNuevoId("todo-path");
            Reserva resGenerada = new(idPers, idEv, id);
            this._miRepo.Agregar(resGenerada);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        } 
    }

}
