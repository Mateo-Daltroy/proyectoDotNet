using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.Context;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using CentroEventos.Aplicacion.InterfacesRepo;
using CentroEventos.Repositorios.GestionIDs;

namespace CentroEventos.Repositorios.implementacionesRepo;

public class RepoPersonas : IRepositorioPersona, IServicioAutorizacion
{
    private CentroEventoContext _context;

    public RepoPersonas(CentroEventoContext context)
    {
        this._context = context;

    }

    public void AltaPersona(int id, Persona p)
    {
        using (var context = new CentroEventoContext())
        {
            
            Boolean context.personas.

        }
        

    }

}