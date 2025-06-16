using Aplicacion.interfacesRepo;
using Aplicacion.UseCases.UseCases;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ListarTodasLasPersonas (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public String ListadoCompleto()
    {

        return repositorio.listarTodos();
        
    }
}