using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.validadores;
using CentroEventos.Repositorios.GestionIDs;
using CentroEventos.Repositorios.implementacionesRepo;


namespace Repositorios.CRUDs;

public class CRUDPersona
{
    private RepoPersonasTxt _miRepo;
    private IdManager _repoId;

    public CRUDPersona(RepoPersonasTxt miRepo, IdManager repoId)
    {
        this._miRepo = miRepo;
        this._repoId = repoId;

    }

    public Boolean ExisteId(int id)
    {
        return _miRepo.ExisteId(id);
    }

    public int getIdConDocumento(String documento)
    {
        int id = -1;
        try
        {
            id = _miRepo.getIdConDocumento(documento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Data);
        }
        return id;
    }

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
        repo.registrarPersona(p, _repoId);
    }

    public void modificarPersona(Persona p)
    {
        RepoPersonasTxt repo = new RepoPersonasTxt();
        repo.Actualizar(p);
    }

    public void EliminarPersona(int id)
    {
        RepoPersonasTxt repo = new RepoPersonasTxt();
        repo.Eliminar(id);
    }

    public List<String> devuelveListaNombres(List<int> listaId)
    {
        List<String> listaNombres = new List<string>();
        RepoPersonasTxt repo = new RepoPersonasTxt();
        foreach (int id in listaId)
        {
            listaNombres.Add(repo.getNombreConId(id));
        }
        return listaNombres;
    }

    public String ListadoCompleto()
    {
        RepoPersonasTxt repo = new RepoPersonasTxt();

        return repo.listarTodos();
    }

    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {
        return _miRepo.PoseeElPermiso(id,permiso);
    }
}
