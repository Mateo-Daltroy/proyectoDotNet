using System;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.validadores;


public static class ValidacionPersona
{

    public static bool ValidarPersona(IRepositorioPersona repo, String dni, String nombre, String mail, String apellido, String telefono, ref string mensaje)
    {
        if (repo.ExisteDocumento(dni))
        {
            mensaje = new DuplicadoException().Message();
            return false;
        }

        if (string.IsNullOrWhiteSpace(dni))
        {
            mensaje = "El dni no debe estar vacio.";
            return false;
        }

        if (dni.Contains("."))
        {
            mensaje = "el dni no debe tener puntos.";
            return false;
        }

        if (repo.ExisteMail(mail))
        {
            mensaje = new DuplicadoException().Message();
            return false;
        }

        if (string.IsNullOrWhiteSpace(mail))
        {
            mensaje = "el mail no debe esta vacio.";
            return false;
        }

        if (!mail.Contains("@") || !mail.Contains("."))
        {
            mensaje = "el formato del mail no es correcto.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(nombre))
        {
            mensaje = "el nombre no debe estar vacio.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            mensaje = "el apellido no debe estar vacio";
            return false;
        }

        if (string.IsNullOrWhiteSpace(telefono))
        {
            mensaje = "el telefono no debe esta vacio";
            return false;
        }
        return true;

    }

}