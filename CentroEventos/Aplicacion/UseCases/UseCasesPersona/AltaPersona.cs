using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCases;
using Aplicacion.UseCases.UseCasesReserva;
using Aplicacion.validadores;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.UseCases.UseCasesPersona;

public class AltaPersona (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{

    public void Ejecutar(Persona p)
    {
        try
        {
            if (!ValidacionPersona.ValidarDni(p.Dni))
        {
            throw new ValidacionException("El formato del Dni no es correcto.");
        }
        if (!ValidacionPersona.ValidarNombre(p.Nombre))
        {
            throw new ValidacionException("El formato del Nombre no es correcto.");
        }
        if (!ValidacionPersona.ValidarApellido(p.Apellido))
        {
            throw new ValidacionException("El formato del Apellido no es correcto.");
        }
        if (!ValidacionPersona.ValidarMail(p.Mail))
        {
            throw new ValidacionException("El formato del Mail no es correcto.");
        }
        if (!ValidacionPersona.ValidarTelefono(p.Telefono))
        {
            throw new ValidacionException("El formato del Telefono no es correcto.");
        }

            repositorio.registrarPersona(p);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }

    }
    
    
}