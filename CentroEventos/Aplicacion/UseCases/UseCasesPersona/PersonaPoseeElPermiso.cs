using Aplicacion.autorizacionProv;

namespace Aplicacion.UseCases.UseCasesPersona;

public class PersonaPoseeElPermiso
{
    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {
        return _miRepo.PoseeElPermiso(id,permiso);
    }
}