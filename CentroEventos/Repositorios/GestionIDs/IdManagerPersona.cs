using System;
using Aplicacion.interfacesRepo;
using CentroEventos.Aplicacion.InterfacesRepo;

namespace Repositorios.GestionIDs;

public class IdManagerPersona: IIdManager
{

    public int obtenerNuevoId(string idFilePath){
            int nuevoId = 1;

            if (File.Exists(idFilePath))
            {
                string contenido = File.ReadAllText(idFilePath);
                if (int.TryParse(contenido, out int idActual))
                {
                    nuevoId = idActual + 1;
                }
            }

            File.WriteAllText(idFilePath, nuevoId.ToString());
            return nuevoId;
        }

}
