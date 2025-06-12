

using Aplicacion.autorizacionProv;
using Aplicacion.excepciones;

namespace Apliacion.casoUso;

public class BajaEvento
{
    public void Baja(int id, int idUsuario)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
                throw new FalloAutorizacionException();

            if (!_repo.Contiene(id))
                throw new EntidadNotFoundException();

            _repo.Eliminar(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}