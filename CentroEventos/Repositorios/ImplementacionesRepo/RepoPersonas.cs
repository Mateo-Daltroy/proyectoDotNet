using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using Aplicacion.UseCases.UseCasesReserva;
using CentroEventos.Aplicacion.InterfacesRepo;
using CentroEventos.Repositorios.GestionIDs;
using Repositorios.Context;

namespace CentroEventos.Repositorios.implementacionesRepo;

public class RepoPersonas : IRepositorioPersona
{

    public void AltaPersona(Persona p)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.personas.FirstOrDefault(per => per.Dni == p.Dni || per.Mail == p.Mail);
            if (persona == null)
            {
                context.personas.Add(p);
                context.SaveChanges();

            }
            else
            {
                throw new DuplicadoException("ya existe una persona con ese dni o mail");
            }
        }
    }

    public void BajaPersona(int id)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.personas.FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                context.personas.Remove(persona);
                context.SaveChanges();
            }
            else throw new EntidadNotFoundException("no se encontro una persona con ese id.");
        }
    }

    public Persona? ExistePersonaPorId(int id)
    {
        using (var context = new CentroEventoContext())
        {
            var persona = context.personas.FirstOrDefault(p => p.Id == id);
            return persona;
        }
    }

    public List<Persona> ListarTodasLasPersonas()
    {
        
    }

}