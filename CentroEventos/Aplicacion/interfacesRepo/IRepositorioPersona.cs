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
    public void Actualizar(String dni, Persona per);
    public String getPersonaConId(int id);
    public String listarTodos();
    public Boolean PoseeElPermiso(int id, Permiso permiso);
    public List<String> ListarNombresDePersonas(List<int> listaId);
    public void eliminarPermiso(int id, Permiso permiso);
    public void agregarPermiso(int id, Permiso permiso);
}
