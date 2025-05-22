using System;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.validadores;

public static class ValidadorReserva
{
    public static void validarDatos(int idPers, int idEv, DateTime date, IRepositorioReserva repoRes, IRepositorioEventoDeportivo repoEv, IRepositorioPersona repoPers) 
    {
        if (!repoPers.ExisteId(idPers) || !repoEv.Contiene(idEv)) 
        {
            throw new EntidadNotFoundException();
        }
        if (repoRes.ExisteId(idPers, idEv))
        {
            throw new DuplicadoException();
        }
        if (repoRes.GetAsistentes(idEv) >= repoEv.ObtenerPorId(idEv)._cupoMaximo)
        {
            throw new CupoExtendidoException();
        }
    }

}
