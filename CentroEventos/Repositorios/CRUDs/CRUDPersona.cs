using System;
using System.Diagnostics.Contracts;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.validadores;
using CentroEventos.Repositorios.GestionIDs;
using CentroEventos.Repositorios.implementacionesRepo;


namespace Repositorios.CRUDs;

public class CRUDPersona
{

    public void AgregarPersona(Persona p)
    {
        try
        {
            ValidacionPersona.ValidarPersona(p, new RepoPersonasTxt());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Data);
            return;
        }
        RepoPersonasTxt repo = new RepoPersonasTxt();
        repo.registrarPersona(p);




    }


}
