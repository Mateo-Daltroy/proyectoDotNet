namespace Aplicacion.UseCases.UseCasesPersona;

public class ExistePersonaPorId
{
    public Boolean ExisteId(int id)
    {
        return _miRepo.ExisteId(id);
    }
}