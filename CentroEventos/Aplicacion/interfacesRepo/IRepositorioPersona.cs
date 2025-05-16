using System;
using Aplicacion.entidades;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioPersona
{
// mati gil
    public Boolean ExisteDocumento(int documento);
    public Boolean ExisteMail (String mail);
    public void registrarPersona (Persona p);
}
