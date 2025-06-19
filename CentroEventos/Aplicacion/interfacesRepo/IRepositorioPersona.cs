using System;
using Aplicacion.entidades;


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
    public Persona getPersonaConId(int id);
    public List<Persona> listarTodos();
    public Boolean PoseeElPermiso(int id, String permiso);
    public List<String> ListarNombresDePersonas(List<int> listaId);
    public void eliminarPermiso(int id, Permiso permiso);
    public void agregarPermiso(int id, Permiso permiso);
    public int ValidarUserYPass(String mail, String contraseña);
}
