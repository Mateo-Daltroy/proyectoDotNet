using System;
using Aplicacion.interfacesServ;

namespace Aplicacion.autorizacionProv;

public class ServicioAuthProvisional : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario, Permiso per) => (idUsuario == 1);
}
