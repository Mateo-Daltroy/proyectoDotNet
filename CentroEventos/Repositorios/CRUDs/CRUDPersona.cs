using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using CentroEventos.Aplicacion.InterfacesRepo;
using CentroEventos.Repositorios.GestionIDs;



namespace Repositorios.CRUDs;

public class CRUDPersona
{
    private IRepositorioPersona _miRepo;
    private IIdManager _repoId;

    public CRUDPersona(IRepositorioPersona miRepo, IIdManager repoId)
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
            ValidacionPersona.ValidarPersona(p, _miRepo);
            _miRepo.registrarPersona(p, _repoId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }
        
    }

    public void modificarPersona(Persona p)
    {
        _miRepo.Actualizar(p);
    }

    public void EliminarPersona(int id)
    {
        _miRepo.Eliminar(id);
    }

    public List<String> devuelveListaNombres(List<int> listaId)
    {
        List<String> listaNombres = new List<string>();
  
        foreach (int id in listaId)
        {
            listaNombres.Add(_miRepo.getNombreConId(id));
        }
        return listaNombres;
    }

    public String ListadoCompleto()
    {

        return _miRepo.listarTodos();
    }

    public Boolean PoseeElPermiso(int id, Permiso permiso)
    {
        return _miRepo.PoseeElPermiso(id,permiso);
    }
}
