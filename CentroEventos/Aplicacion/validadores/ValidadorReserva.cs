using System;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.validadores;

public static class ValidadorReserva
{
    public static bool validarDatos(int idPers, int idEv, DateTime date, IRepositorioReserva repoRes, IRepositorioEventoDeportivo repoEv, IRepositorioPersona repoPers, ref string mens) 
    {
        if (!repoPers.ExisteId(idPers) || !repoEv.ContieneAsync(idEv).Result) 
        {
            mens = new EntidadNotFoundException().Message;
            return false;
            //throw new EntidadNotFoundException();
        }
        if (repoRes.ExisteId(idPers, idEv))
        {
            mens = new DuplicadoException().Message;
            return false;
            //throw new DuplicadoException();
        }
        if (repoRes.GetAsistentes(idEv) >= repoEv.ObtenerPorIdAsync(idEv).Result._cupoMaximo)
        {
            mens = new CupoExtendidoException().Message;
            return false;
        }
        return true;
    }

}
