using Aplicacion.autorizacionProv;

namespace Aplicacion.casoUso;

public class PersonaPoseeElPermiso
{
    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {
        return _miRepo.PoseeElPermiso(id,permiso);
    }
}