using System;
using Aplicacion.entidades;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioPersona
{
    // mati gil
    public Boolean ExisteMail(String mail);

    public int getIdConMail(String mail);
    public int getIdConDocumento(String documento);
    public void registrarPersona(Persona p);
    public Boolean ExisteDocumento(String documento);
}
