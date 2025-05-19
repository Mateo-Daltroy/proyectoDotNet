using System;
using Aplicacion.excepciones;

namespace Repositorios.GestionIDs;

public class IdManagerTxt
{
    private string _Archivo;

    public IdManagerTxt(string tipoArchivo)
    // Recibe simplemente Persona, Reserva, EventoDeportivo
    {
        if (tipoArchivo.Equals("Reserva") || tipoArchivo.Equals("Persona") || tipoArchivo.Equals("EventoDeportivo"))
        //Casco ve esto y se mata
        {
            this._Archivo = Environment.CurrentDirectory + tipoArchivo + ".txt";
        }
        else
        {
            throw new ValidacionException();
        }
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
