using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
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
            if (!ValidacionPersona.ValidarPersona(repositorio, p._dni, p._nombre, p._mail, p._apellido, p._telefono, ref  mensaje)) {
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