using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ListarTodasLasPersonas (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public String ListadoCompleto()
    {

        return repositorio.listarTodos();
        
    }
}