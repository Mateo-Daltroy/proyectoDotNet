// See https://aka.ms/new-console-template for more information
using Aplicacion.entidades;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;
using CentroEventos.Aplicacion.InterfacesRepo;
using CentroEventos.Repositorios.GestionIDs;
using CentroEventos.Repositorios.implementacionesRepo;
using Repositorios.CRUDs;
using Repositorios.ImplementacionesRepo;

// Variables Globales
string input;
int Id = -1;


//_Inicializar Bases de Datos_
IRepositorioReserva repoTempRes = new RepoReservasTxt();
IRepositorioPersona repoTempPers = new RepoPersonasTxt();
IRepositorioEventoDeportivo repoTempEv = new RepoEventoDeportivoTxt();
IIdManager gestor = new IdManager();
CRUDReserva cRUDReserva = new CRUDReserva(repoTempRes, repoTempEv, repoTempPers, gestor);
CRUDPersona cRUDPersona = new CRUDPersona(repoTempPers, gestor);
CRUDEventoDeportivo cRUDEventoDeportivo = new CRUDEventoDeportivo(repoTempEv, repoTempPers, gestor);


// Display
Console.WriteLine("-----------------------------------------------");
Console.WriteLine("|        Bienvenido a la consola del 	     |");
Console.WriteLine("|       Centro Deportivo Universitario! 	     |");
Console.WriteLine("-----------------------------------------------");
while (Id == -1) {
    Console.WriteLine();
    Console.WriteLine("Ingrese su dni sin puntos para acceder a su usuario y ver los eventos disponibles");
    Console.Write("| -> ");
    input = "invalido";
    int DniLog = -1;
    while (input.Equals("invalido")) 
    {
        input = Console.ReadLine() ?? "invalido";
        try
        {
            DniLog = Int32.Parse(input);
        }
        catch
        {
            Console.WriteLine("Ingresar solo los numeros, sin puntos por favor");
            input = "invalido";
        }
    }
    if (DniLog == 1) Id = 1;
    else
    {
        Id = cRUDPersona.getIdConDocumento(DniLog.ToString());
        if (Id == -1)
        {
            Console.WriteLine("DNI no registrado, recuerde que las cuentas se crean en secretaria");
        }
    }
}

// Si el Id es de usuario, mostramos inmediatemente los eventos disponibles
if (Id != 1)
{
    Console.WriteLine("Cuenta conectada, mostrando los eventos disponibles: ");
    List<string> eventos = (List<string>) cRUDEventoDeportivo.ListarEventosConCupoDisponible(repoTempRes);
    foreach (string ev in eventos)
    {
        Console.WriteLine(ev);
    }
}
else
// Entra en la interfaz de Admin
{
    int opcion = 0;
    while (opcion != 15)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| 	Seleccionar la opcion que desee	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| Op.|             Descripcion		      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  1 | 		Registrar Persona	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  2 | 	   Modificar datos de Persona 	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  3 | 		Eliminar Persona	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  4 | 	     Listar todas las Personas 	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  5 | 		Registrar Reserva	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  6 | 	   Modificar datos de Reserva 	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  7 | 		Eliminar Reserva	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  8 | 	     Listar todas las Reservas 	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("|  9 |      Registrar Evento Deportivo        |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| 10 |  Modificar datos de Evento Deportivo   |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| 11 | 	     Eliminar Evento Deportivo        |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| 12 | 	 Listar todos los Eventos Deportivos  |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| 13 | 	   Listar asistencia a un Evento      |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| 14 |   Listar eventos con cupo disponible   |");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("| 15 |   Cerrar la consola   |");
        Console.WriteLine("-----------------------------------------------");
        Console.Write("| -> ");
        input = "invalido";
        while (input.Equals("invalido") || opcion == -1) {
            input = Console.ReadLine() ?? "invalido";
            try
            {
                opcion = Int32.Parse(input);
            }
            catch
            {
                input = "invalido";
                Console.WriteLine("Introducir un numero por favor");
            }
            if (opcion < 0 || opcion > 15)
            {
                opcion = -1;
                Console.WriteLine("Introducir un numero valido");
            }
        }
        // Aca iria el case que llama a todas las funciones
    }
}






/*
// no se para que era este codigo asi que por las dudas no lo borro
Persona mostrarRegistro(){
    Console.Write("Ingrese sus datos: \n"); // Console.WriteLine te ahorra los \n
    Console.Write("DNI: ");
    String? dni = Console.ReadLine();
    Console.Write("\n");
    Console.Write("Nombre: ");
    String? nombre = Console.ReadLine();
    Console.Write("\n");
    Console.Write("Apellido: ");
    String? apellido = Console.ReadLine();
    Console.Write("\n");
    Console.Write("Mail: ");
    String? mail = Console.ReadLine();
    Console.Write("\n");
    Console.Write("Telefono: ");
    String? telefono = Console.ReadLine();
    Console.Write("\n");
    return new Persona(dni, nombre, apellido, mail, telefono);
}
int opcionN = Int32.Parse(opcion ?? "3") ;
*/