using System;

namespace Aplicacion.autorizacionProv;

public class ServicioAuthProvisional : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario, Permiso per)
    {
        if (idUsuario == 1) return true;
        else return false; 
    }
}
