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
int Id;


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
    Id = cRUDPersona.getIdConDocumento(DniLog);
    if (Id == -1)
    {
        Console.WriteLine("DNI no registrado, recuerde que las cuentas se crean en secretaria");
    }
}


// Si el Id es de usuario, mostramos inmediatemente los eventos disponibles
Console.WriteLine("Cuenta conectada, mostrando los eventos disponibles: ");
List<string> eventos = cRUDEventoDeportivo.ListarEventosConCupoDisponible();
foreach (string ev in eventos)
{
    Console.WriteLine(ev);
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