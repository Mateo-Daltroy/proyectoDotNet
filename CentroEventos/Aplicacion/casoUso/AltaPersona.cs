using Aplicacion.entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.casoUso;

public class AltaPersona
{
    public void AgregarPersona(DbContext db, Persona p)
    {
        using (var context = new db);
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }
        
    }
}