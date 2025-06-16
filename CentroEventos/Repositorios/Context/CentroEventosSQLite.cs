using Repositorios.Context;

namespace CentroEventos;

public class CentroEventosSQLite
   // Esta clase es para inicializar la base de datos SQLite
   // y crearla si no existe.
   // Se debe llamar al método Inicializar() al inicio de la aplicación.

   // Requiere que el paquete NuGet Microsoft.EntityFrameworkCore.Sqlite esté instalado.

{
   public static void Inicializar()
    {
        using var context = new CentroEventoContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
    }
}