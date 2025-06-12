namespace Aplicacion.casoUso;

public class ListarNombresDePersonas
{
    public List<String> devuelveListaNombres(List<int> listaId)
    {
        List<String> listaNombres = new List<string>();
  
        foreach (int id in listaId)
        {
            listaNombres.Add(_miRepo.getNombreConId(id));
        }
        return listaNombres;
    }
}