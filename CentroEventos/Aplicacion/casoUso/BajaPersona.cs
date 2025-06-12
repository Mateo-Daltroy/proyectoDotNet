namespace Aplicacion.casoUso;

public class BajaPersona
{
    public void EliminarPersona(int id)
    {
        _miRepo.Eliminar(id);
    }
}