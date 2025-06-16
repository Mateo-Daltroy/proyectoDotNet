using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCases;
using Aplicacion.UseCases.UseCasesReserva;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicacion.UseCases.UseCasesPersona;

public class BajaPersona(IRepositorioPersona repositorio) : PersonaUseCase(repositorio)
{
    public void Ejecutar(int id)
    {
        try
        {
            repositorio.Eliminar(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}