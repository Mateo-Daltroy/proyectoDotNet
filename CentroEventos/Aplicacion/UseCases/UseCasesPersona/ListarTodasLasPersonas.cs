using Aplicacion.interfacesRepo;
using Aplicacion.entidades;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ListarTodasLasPersonas (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public List<Persona> Ejecutar()
    {

        return repositorio.listarTodos();
        
    }
}