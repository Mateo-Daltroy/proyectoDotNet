using System;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.validadores;


public static class ValidacionPersona{  

    public static void ValidarPersona (Persona persona, IRepositorioPersona repoPersona){
        if (persona.Nombre == null || persona.Nombre == "" || persona.Apellido == null ||
        persona.Apellido == "" || persona.Dni == null || persona.Dni == "" || persona.Telefono == null ||
        persona.Telefono == "" || persona.Mail == null || persona.Mail == ""){
            throw new ValidacionException();
        }
        if (repoPersona.ExisteMail(persona.Mail)){
            throw new DuplicadoException("El mail ingresado ya fue registrado.");
        }
        if (repoPersona.ExisteDocumento(persona.Dni)){
            throw new DuplicadoException("El documento ingresado ya fue registrado.");
        }

    }
}
