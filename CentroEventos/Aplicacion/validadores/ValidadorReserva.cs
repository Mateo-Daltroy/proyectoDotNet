using System;
using System.Security.Cryptography;
using Aplicacion.entidades;
using CentroEventos.Aplicacion.InterfacesRepo;

namespace Aplicacion.validadores;

public class ValidadorReserva
{

    private IRepositorioReserva _repoRes;
    private IRepositorioEventoDeportivo _repoEv;
    private IRepositorioPersona _repoPers;
    public ValidadorReserva(IRepositorioReserva repoRes, IRepositorioEventoDeportivo repoEv, IRepositorioPersona repoPers) {
        this._repoRes = repoRes;
        this._repoEv = repoEv;
        this._repoPers = repoPers;
    }
    public static void validarDatos(int idPers, int idEv, )

}
