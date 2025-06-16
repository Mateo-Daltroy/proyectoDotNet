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
            var persona = context.Personas.FirstOrDefault(per => per.Dni == p.Dni || per.Mail == p.Mail);
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
            var persona = context.Personas.FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                context.Personas.Remove(persona);
                context.SaveChanges();
            }
            else throw new EntidadNotFoundException("no se encontro una persona con ese id.");
        }
    }

    public void Actualizar(int documento, Persona p)
    {

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
                var persona = context.Personas.FirstOrDefault(p => p.Id == id);
                if (persona != null) listaNombres.Add(persona.Nombre);

            }
            return listaNombres;
        }

    }

    public int getIdConMail(String mail)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p.Mail.Equals(mail));
            if (persona != null) return persona.Id;
            return -1;
        }
    }
    public int getIdConDocumento(String documento)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.Personas.FirstOrDefault(p => p.Dni.Equals(documento));
            if (persona != null) return persona.Id;
            return -1;
        }
    }

    public Persona getPersonaConId(int id)
    {
        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p.Id == id);
            return persona;

        }
    }

    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {

        using (var context = new CentroEventoContext())
        {

            var persona = context.Personas.FirstOrDefault(p => p.Id == id);
            return true;
            
        }

    }

}