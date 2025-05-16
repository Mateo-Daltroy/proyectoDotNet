using System;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioPersona
{
    public Boolean ExisteId(int unId);
    public Boolean ExisteMail (String mail);
}
