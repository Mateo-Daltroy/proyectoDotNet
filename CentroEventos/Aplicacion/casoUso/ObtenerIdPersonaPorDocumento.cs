namespace Aplicacion.casoUso;

public class ObetenerIdPersonaPorDocumento
{
    public int getIdConDocumento(String documento)
    {
        int id = -1;
        try
        {
            id = _miRepo.getIdConDocumento(documento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Data);
        }
        return id;
    }
}