using System;
using System.Diagnostics.Contracts;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using Aplicacion.UseCases.UseCasesReserva;
using Repositorios.Context;
using Repositorios.ImplementacionesRepo;
using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Repositorios.ImplementacionesRepo;

public class RepoPersonas : IRepositorioPersona
{
    private readonly CentroEventoContext _context;

    public RepoPersonas (CentroEventoContext repo)
    {
        this._context = repo;
    }

    public void registrarPersona(Persona p)
    {
        //LA CONTRASEÑA SE HASHEA EN EL CASO DE USO
            var persona = _context.Personas.FirstOrDefault(per => per._dni == p._dni || per._mail == p._mail);
            if (persona == null)
            {
                _context.Personas.Add(p);
                _context.SaveChanges();

            }
            else
            {
                throw new DuplicadoException("ya existe una persona con ese dni o mail");
            }
        }


    public void Eliminar(int id)
    {
        Console.WriteLine($"id recibido {id}");
        var persona = _context.Personas.Find(id);
        if (persona != null)
        {
            new RepoReservas(_context).EliminarPorPersona(id);
            _context.Personas.Remove(persona);
            ///////////////////////////////////////////////////////////////////
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("INNER: " + ex.InnerException.Message);
                    // Si hay más niveles de inner exception:
                    if (ex.InnerException.InnerException != null)
                    {
                        Console.WriteLine("INNER 2: " + ex.InnerException.InnerException.Message);
                    }
                }
                throw;
            }
            ///////////////////////////////////////////////////////////////////
        }
        else
        {
            throw new EntidadNotFoundException("no se encontro una persona con ese id. ");
        }
    }
    

    public void Actualizar(Persona pe)
    {

            var persona = _context.Personas.FirstOrDefault(p => p._id == pe._id);
            if (persona != null)
            {
                persona.modificarNombre(pe._nombre);
                persona.modificarApellido(pe._apellido);
                persona.modificarMail(pe._mail);
                persona.modificarTelefono(pe._telefono);

            }
            _context.SaveChanges();
        }
    

    public void agregarPermiso(int id, Permiso permiso)
    {
            var persona = _context.Personas
            .Include(p => p._permisos)
            .FirstOrDefault(p => p._id == id);
            
        if (persona != null)
        {
            if (!persona._permisos.Any(p => p._id == permiso._id))
            {
                persona._permisos.Add(permiso);
                _context.SaveChanges();
            }
        }
    }


    public void eliminarPermiso(int id, Permiso permiso)
    {
            var persona = _context.Personas
            .Include(p => p._permisos)
            .FirstOrDefault(p => p._id == id);
            
        if (persona != null)
        {
            var permisoAEliminar = persona._permisos
                .FirstOrDefault(p => p._id == permiso._id);
                
            if (permisoAEliminar != null)
            {
                persona._permisos.Remove(permisoAEliminar);
                _context.SaveChanges();
            }
        }
    }

    

    public Boolean ExisteId(int id)
    { 
        var persona = _context.Personas.FirstOrDefault(p => p._id == id);
        return persona != null;
    }

    public Boolean ExisteMail(String mail)
    {
       
            var persona = _context.Personas.FirstOrDefault(p => p._mail.Equals(mail));
            return persona != null;
        }
    

    public Boolean ExisteDocumento(string documento)
    {

            var persona = _context.Personas.FirstOrDefault(p => p._dni == documento);
            return persona != null;
        
    }

    public List<Persona> listarTodos()
    {

            return _context.Personas
            .Include(p => p._permisos) //agrego esto para obtener los permisos, si queres lo mostras en la misma vista o en otra
            .ToList();
            
        }

    

    public List<String> ListarNombresDePersonas(List<int> listaId)
    {

            List<String> listaNombres = new List<String>();
            foreach (int id in listaId)
            {
                var persona = _context.Personas.FirstOrDefault(p => p._id == id);
                if (persona != null) listaNombres.Add(persona._nombre);

            }
            return listaNombres;
        }

    

    public int getIdConMail(String mail)
    {

            var persona = _context.Personas.FirstOrDefault(p => p._mail.Equals(mail));
            if (persona != null) return persona._id;
            return -1;
        }
    
    public int getIdConDocumento(String documento)
    {

            var persona = _context.Personas.FirstOrDefault(p => p._dni.Equals(documento));
            if (persona != null) return persona._id;
            return -1;
    }
    

    public Persona getPersonaConId(int id)
   {
        var persona = _context.Personas
            .Include(p => p._permisos)
            .FirstOrDefault(p => p._id == id);
            
        if (persona == null) 
            throw new EntidadNotFoundException();
        return persona;
    }


    public Boolean PoseeElPermiso(int id, String permiso)
    {
            var persona = _context.Personas
            .Include(p => p._permisos) 
            .FirstOrDefault(p => p._id == id);
            
        if (persona != null)
        {
            return persona._permisos.Any(perm => perm._nombre == permiso);
        }
        return false;
    }


    public int ValidarUserYPass(String mail, String contraseña)
    {


            var persona = _context.Personas.FirstOrDefault(p => p._mail == mail);
            if (persona != null)
            {

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                        sb.Append(b.ToString("x2"));
                    String passHash = sb.ToString();
                    if (persona._contraseña == passHash) return persona._id;

                }
            }
            return -1;
        }
    }
