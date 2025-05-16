using System;

namespace Aplicacion.autorizacionProv;

public interface IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario, Permiso per);

}
