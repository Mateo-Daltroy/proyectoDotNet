using System;
using System.IO;

namespace CentroEventos.Repositorios.GestionIDs
{
    public static class IdManager : IDManager
    // Clase para gestionar el ID de los eventos deportivos
    {
        // Lee el id actual del archivo, lo incrementa, lo guarda y retorna el nuevo id
        public static int ObtenerNuevoId(string idFilePath)
        {
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
}