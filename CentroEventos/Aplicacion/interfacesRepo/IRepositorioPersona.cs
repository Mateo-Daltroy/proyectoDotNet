using System;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using CentroEventos.Aplicacion.InterfacesRepo;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioPersona
{
    public Boolean ExisteMail(String mail);
    public Boolean ExisteId(int id);
    public int getIdConMail(String mail);
    public int getIdConDocumento(String documento);
    public void registrarPersona(Persona p);
    public Boolean ExisteDocumento(String documento);
    public void Eliminar(int id);
    public void Actualizar(Persona per);
    public String getNombreConId(int id);
    public String listarTodos();
    public Boolean PoseeElPermiso(int id, Permiso permiso);
<<<<<<< HEAD
    public List<String> ListarNombresDePersonas(List<int> listaId);
=======

>>>>>>> cf0af105ff67dc2bd3f52fc7a99cb4c666c4d8af

}
