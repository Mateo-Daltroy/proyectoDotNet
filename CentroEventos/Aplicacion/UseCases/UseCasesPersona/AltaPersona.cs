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
            String mensaje = "";
            if (!ValidacionPersona.ValidarPersona(repositorio, p.Dni, p.Nombre, p.Mail, p.Apellido, p.telefono, mensaje)) {
                throw new ValidacionException(mensaje);
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