using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ListarTodasLasPersonas (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public String EJecutar()
    {

        return repositorio.listarTodos();
        
    }
}