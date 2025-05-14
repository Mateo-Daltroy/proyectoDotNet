using System;
using Aplicacion.entidades;
using Aplicacion.excepciones;


namespace Aplicacion.validadores;


public static class ValidacionPersona{

    public static Boolean ValidarPersona (Persona persona){
        if (persona.Nombre == null || persona.Nombre == "" || persona.Apellido == null || persona.Apellido == "" || persona.Dni == null || persona.Dni == "" || persona.Telefono == null || persona.Telefono == "" || persona.Mail == null || persona.Mail == ""){
            throw new ValidacionException();
        }
        //hacer validacion de mail y dni

        return true;
    }
}
