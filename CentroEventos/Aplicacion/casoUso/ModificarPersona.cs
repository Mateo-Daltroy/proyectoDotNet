namespace Aplicacion.casoUso;

public class ModificarPersona
{
    public void modificarPersona(Persona p)
    {
        _miRepo.Actualizar(p);
    }
}