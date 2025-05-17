using System;

namespace Repositorios.GestionIDs;

public class IdManagerTxt
{
    private string _Archivo;

    public IdManagerTxt(string tipoArchivo)
    {
        this._Archivo = Environment.CurrentDirectory + tipoArchivo;
    }

    public int ObtenerNuevoId()
    {
        FileInfo fileInfo = new FileInfo(_Archivo);
        StreamWriter strW = new StreamWriter(_Archivo);
        StreamReader strR = new StreamReader(_Archivo);
        if (!fileInfo.Exists)
        {
            fileInfo.Create();
            strW.WriteLine(0);
        }
        if (int.TryParse(strR.ReadLine(), out int idNuevo))
        {
            idNuevo++;
        }
        strW.WriteLine(idNuevo);
        return (idNuevo);
    }
}
