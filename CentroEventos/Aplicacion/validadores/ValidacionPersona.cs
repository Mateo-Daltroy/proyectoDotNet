using System;
using Aplicacion.entidades;

namespace Aplicacion.Validaciones;

public static class ValidacionPersona
{

    public static Boolean ValidarPersona (Persona persona){
        if (persona.Dni == null || persona.Nombre == null || persona.Apellido == null || persona.Mail == null || persona.Telefono == null)
        {
            return false;
        }return true;
    }

}
