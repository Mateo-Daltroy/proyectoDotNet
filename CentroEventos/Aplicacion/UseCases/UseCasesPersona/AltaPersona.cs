using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCasesReserva;
using Aplicacion.validadores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Security.Cryptography;

namespace Aplicacion.UseCases.UseCasesPersona;

public class AltaPersona(IRepositorioPersona repositorio) : PersonaUseCase(repositorio)
{

    public void Ejecutar(Persona p)
    {
        try
        {
            String mensaje = "";
            if (!ValidacionPersona.ValidarPersona(repositorio, p._dni, p._nombre, p._mail, p._apellido, p._telefono, p._contraseña, ref mensaje))
            {
                throw new ValidacionException(mensaje);
            }
            p._contraseña = hashearPassword(p);
            repositorio.registrarPersona(p);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }

    }

    public String hashearPassword(Persona p)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(p._contraseña));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
            
        } 
    }
    
}