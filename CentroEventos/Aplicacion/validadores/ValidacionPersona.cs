using System;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.validadores;


public static class ValidacionPersona
{

    /*public static void ValidarPersona (Persona persona, IRepositorioPersona repoPersona){
        
        if (persona.Nombre == null || persona.Nombre == "" || persona.Apellido == null ||
        persona.Apellido == "" || persona.Dni == null || persona.Dni == "" || persona.Telefono == null ||
        persona.Telefono == "" || persona.Mail == null || persona.Mail == "")
        {

            throw new ValidacionException();
        }
        if (repoPersona.ExisteMail(persona.Mail)){

            throw new DuplicadoException("El mail ingresado ya fue registrado.");
        }
        if (repoPersona.ExisteDocumento(persona.Dni)){

            throw new DuplicadoException("El documento ingresado ya fue registrado.");
        }
    
    }*/

    public static bool ValidarDni(string dni)
    {
        if (string.IsNullOrWhiteSpace(dni))
        {
            return false;
        }

        if (dni.Contains("."))
        {
            return false;
        }

        return true;
    }

    public static bool ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            return false;
        }

        // Puedes agregar más validaciones si es necesario
        return true;
    }

    public static bool ValidarApellido(string apellido)
    {
        if (string.IsNullOrWhiteSpace(apellido))
        {
            return false;
        }

        // Puedes agregar más validaciones si es necesario
        return true;
    }

    public static bool ValidarMail(string mail)
    {
        if (string.IsNullOrWhiteSpace(mail))
        {
            return false;
        }

        // Validación simple de formato de mail
        if (!mail.Contains("@") || !mail.Contains("."))
        {
            return false;
        }

        return true;
    }

    public static bool ValidarTelefono(string telefono)
    {
        if (string.IsNullOrWhiteSpace(telefono))
        {
            return false;
        }

        // Puedes agregar más validaciones si es necesario
        return true;
    }
}
