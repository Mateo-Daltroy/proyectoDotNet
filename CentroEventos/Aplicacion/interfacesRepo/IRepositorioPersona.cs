using System;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioPersona
{
// mati gil
    public Boolean ExisteId(int unId);
    public Boolean ExisteMail (String mail);
}
