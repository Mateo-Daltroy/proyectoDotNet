using System;
using Aplicacion.entidades;

namespace Aplicacion.interfacesServ;

public interface IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario, Permiso per);

}
