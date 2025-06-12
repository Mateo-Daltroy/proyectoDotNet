namespace Aplicacion.casoUso;

public class ExistePersonaPorId
{
    public Boolean ExisteId(int id)
    {
        return _miRepo.ExisteId(id);
    }
}