using Aplicacion.entidades;
using Aplicacion.validadores;

namespace Aplicacion.casoUso;

public class AltaPersona
{
    public void AgregarPersona(Persona p)
    {
        try
        {
            ValidacionPersona.ValidarPersona(p, _miRepo);
            _miRepo.registrarPersona(p, _repoId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }
        
    }
}