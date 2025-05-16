using System;
using Aplicacion.autorizacionProv;

namespace Aplicacion.interfacesServ;

public interface IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario, Permiso per);

}
