using System;
using Aplicacion.entidades;
using CentroEventos.Aplicacion.InterfacesRepo;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioPersona
{
    public Boolean ExisteMail(String mail);
    public Boolean ExisteId(int id);
    public int getIdConMail(String mail);
    public int getIdConDocumento(String documento);
    public void registrarPersona(Persona p, IIdManager idManager);
    public Boolean ExisteDocumento(String documento);
}
