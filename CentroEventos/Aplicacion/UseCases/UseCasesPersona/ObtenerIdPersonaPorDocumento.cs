using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesPersona;

public class ObetenerIdPersonaPorDocumento (IRepositorioPersona repositorio): PersonaUseCase (repositorio)
{
    public int getIdConDocumento(String documento)
    {
        int id = -1;
        try
        {
            id = repo.getIdConDocumento(documento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Data);
        }
        return id;
    }
}