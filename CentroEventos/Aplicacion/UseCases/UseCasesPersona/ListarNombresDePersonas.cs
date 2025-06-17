using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ListarNombresDePersonas (IRepositorioPersona repositorio): PersonaUseCase (repositorio)

{
    public List<String> Ejecutar(List<int> listaId)
    {
        return repositorio.ListarNombresDePersonas(listaId);
    }
}