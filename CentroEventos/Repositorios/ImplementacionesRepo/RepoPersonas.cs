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

namespace CentroEventos.Repositorios.implementacionesRepo;

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
                new RepoReservas.EliminarPorPersona(id);
                context.Personas.Remove(persona);
                context.SaveChanges();
            }
            else throw new EntidadNotFoundException("no se encontro una persona con ese id.");
        }
    }

    public void Actualizar(int documento, Persona p)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p._dni == documento);
            if (persona != null)
            {
                if (p._dni != "")
                {
                    persona._dni = p._dni;
                }

                if (p._nombre != "")
                {
                    persona._nombre = p._nombre;
                }

                if (p._apellido != "")
                {
                    persona._apellido = p._apellido;
                }

                if (p._mail != "")
                {
                    persona._mail = p._mail;
                }
                
                if (p._telefono!="") {
                    persona._telefono = p._telefono;
                }
            }
        }
    }

    public Boolean ExisteId(int id)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p.Id == id);
            return persona != null;
        }
    }

    public Boolean ExisteMail(String mail)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p.Mail.Equals(mail));
            return persona != null;
        }
    }

    public Boolean ExisteDocumento(string documento)
    {
        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p.Dni == documento);
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

    public Persona getPersonaConId(int id)
    {
        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            return persona;

        }
    }

    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {

        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p._id == id);
            return true;
            // sin hacer //////////////////////////////////////////////////////////////////////////
            
        }

    }

}