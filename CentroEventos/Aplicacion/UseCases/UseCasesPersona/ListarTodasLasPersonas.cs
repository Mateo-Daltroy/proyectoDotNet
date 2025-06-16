namespace Aplicacion.UseCases.UseCasesPersona;

public class ListarTodasLasPersonas
{
    public String ListadoCompleto()
    {

        return _miRepo.listarTodos();
    }
}