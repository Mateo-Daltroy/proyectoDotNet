using System;
using System.Diagnostics.Contracts;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;

namespace Repositorios.CRUDs;

public class CRUDPersona : IRepositorioPersona, IServicioAutorizacion
{

    public Boolean ExisteDocumento (int documento){
        //EntidadNotFoundException
        return true; //cuando termine de hacer todo lo de Persona, hago esto bien
    }

    public Boolean ExisteMail (String mail){
        return true; //lo mismo
    }

    public void registrarPersona (Persona p){

    }

    public Boolean PoseeElPermiso (int id, Permiso permiso){ 
        List<string> palabras = new List<string>();
        using (StreamReader sr = new StreamReader("rutaDelArchivo"))
        {
            
            string linea;
            while ((linea = sr.ReadLine()) != null)
            {
                if (linea.StartsWith(id.ToString())) 
                {
                    palabras.AddRange(linea.Split(' '));
                    break;
                }
            }
        }
        foreach (String palabra in palabras){

            if (permiso.ToString().Equals(palabra)){
                return true;
            }

        }
        return false;

    }

}
