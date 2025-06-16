using Aplicacion.entidades;
using Aplicacion.UseCases.UseCases;
using Aplicacion.UseCases.UseCasesReserva;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.UseCases.UseCasesPersona;

public class AltaPersona (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{

    public void Ejecutar(Persona p)
    {
        try
        {

            repositorio.AltaPersona(p);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }

    }
    
    
}