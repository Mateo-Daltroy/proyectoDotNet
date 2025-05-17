using System;
using CentroEventos.Aplicacion.InterfacesRepo;

namespace Repositorios.GestionIDs;

public class IdManagerReservaTxt : IIdManager
{
    private string _miPath = Environment.CurrentDirectory + "/idReserva.txt";

    public int ObtenerNuevoId()
    {
        FileInfo fileInfo = new FileInfo(_miPath);
        StreamWriter strW = new StreamWriter(_miPath);
        StreamReader strR = new StreamReader(_miPath);
        if (!fileInfo.Exists)
        {
            fileInfo.Create();
            strW.Write(0);
        }
        int idNuevo = (int)strR.Read();
        idNuevo++;
        strW.Write(idNuevo);
        return (idNuevo);
    }

}
