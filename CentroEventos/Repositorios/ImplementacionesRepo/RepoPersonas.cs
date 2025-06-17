using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using Aplicacion.UseCases.UseCasesReserva;
using CentroEventos.Aplicacion.InterfacesRepo;
using Repositorios.Context;
using Repositorios.ImplementacionesRepo;
using System;
using System.Text;
using System.Security.Cryptography;

namespace Repositorios.ImplementacionesRepo;

public class RepoPersonas : IRepositorioPersona
{

    public void registrarPersona(Persona p)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(per => per._dni == p._dni || per._mail == p._mail);
            if (persona == null)
            {
                context.Personas.Add(p);
                context.SaveChanges();

            }
            else
            {
                throw new DuplicadoException("ya existe una persona con ese dni o mail");
            }
        }
    }

    public void Eliminar(int id)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            if (persona != null)
            {
                new RepoReservas().EliminarPorPersona(id);
                context.Personas.Remove(persona);
                context.SaveChanges();
            }
            else throw new EntidadNotFoundException("no se encontro una persona con ese id.");
        }
    }

    public void Actualizar(Persona pe)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._dni == pe._dni);
            if (persona != null)
            {
                persona.modificarNombre(pe._nombre);
                persona.modificarApellido(pe._apellido);
                persona.modificarMail(pe._mail);
                persona.modificarTelefono(pe._telefono);

            }
            context.SaveChanges();
        }
    }

    public void agregarPermiso(int id, Permiso permiso)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            if (persona != null)
            {
                persona.agregarPermiso(permiso);
                context.SaveChanges();
            }
        }
    }

    public void eliminarPermiso(int id, Permiso permiso)
    {

        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            if (persona != null)
            {
                persona.eliminarPermiso(permiso);
                context.SaveChanges();
            }
        }

    }

    public Boolean ExisteId(int id)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            return persona != null;
        }
    }

    public Boolean ExisteMail(String mail)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._mail.Equals(mail));
            return persona != null;
        }
    }

    public Boolean ExisteDocumento(string documento)
    {
        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p._dni == documento);
            return persona != null;
        }
    }

    public String listarTodos()
    {

        using (var context = new CentroEventoContext())
        {
            List<Persona> lista = context.Personas.ToList();
            String todos = "";

            foreach (Persona p in lista)
            {
                todos += p.ToString() + "\n";
            }
            return todos;
        }

    }

    public List<String> ListarNombresDePersonas(List<int> listaId)
    {
        using (var context = new CentroEventoContext())
        {
            List<String> listaNombres = new List<String>();
            foreach (int id in listaId)
            {
                var persona = context.Personas.FirstOrDefault(p => p._id == id);
                if (persona != null) listaNombres.Add(persona._nombre);

            }
            return listaNombres;
        }

    }

    public int getIdConMail(String mail)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._mail.Equals(mail));
            if (persona != null) return persona._id;
            return -1;
        }
    }
    public int getIdConDocumento(String documento)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._dni.Equals(documento));
            if (persona != null) return persona._id;
            return -1;
        }
    }

    public String getPersonaConId(int id)
    {
        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            if (persona != null) return persona._nombre + persona._apellido;
            return "";

        }
    }

    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {

        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            if (persona != null)
            {
                foreach (Permiso perm in persona._permisos)
                {
                    if (perm == permiso)
                    {
                        return true;
                    }
                }
            }
            return false;


        }

    }

    public int ValidarUserYPass(String mail, String contraseña)
    {
        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p._mail == mail);
            if (persona != null)
            {

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                        sb.Append(b.ToString("x2"));
                    String passHash = sb.ToString();
                    if (persona._contraseña == passHash) return true;

                }
                return true;
            }
        }
    }
}