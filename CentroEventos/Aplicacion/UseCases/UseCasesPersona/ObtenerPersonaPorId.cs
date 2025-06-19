using System;
using Aplicacion.entidades;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ObtenerPersonaPorId(IRepositorioPersona repositorio) : PersonaUseCase(repositorio)
{
    public Persona Ejecutar(int id)
    {
        return repositorio.getPersonaConId(id);
    }

}
