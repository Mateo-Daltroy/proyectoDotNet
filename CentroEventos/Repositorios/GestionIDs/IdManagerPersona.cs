using System;
using Aplicacion.interfacesRepo;

namespace Repositorios.GestionIDs;


    public class IdManagerPersona : IIdManager
    {

        private readonly string _pathRepo = Path.Combine(
    Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
    "idPersonas.txt");

        public int ObtenerNuevoId()
        {
            int nuevoId = 1;

            if (File.Exists(_pathRepo))
            {
                string contenido = File.ReadAllText(_pathRepo);
                if (int.TryParse(contenido, out int idActual))
                {
                    nuevoId = idActual + 1;
                }
            }

            File.WriteAllText(_pathRepo, nuevoId.ToString());
            return nuevoId;
        }

    }

