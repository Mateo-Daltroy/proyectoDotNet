// See https://aka.ms/new-console-template for more information
using Aplicacion.entidades;
using Aplicacion.Validaciones;
using Aplicacion.ValidacionPersona;

Persona mostrarRegistro(){
Console.Write("Ingrese sus datos: \n");
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
Console.WriteLine("Bienvenido al sistema de registro de eventos");
Console.WriteLine("Presione 1 para registrarse.");
Console.WriteLine("Presione 2 para inciar sesion.");
Console.WriteLine("Presione 3 para salir.");
String? opcion = Console.ReadLine();

int opcionN;
try{
    opcionN = Int32.Parse(opcion);
}catch (FormatException){
    Console.WriteLine("Opcion no valida");
    return;
}

if (opcionN == 1){
    Persona usuario = mostrarRegistro();
    if (Persona.RegistrarPersona(usuario)){
        mostrarOpcionesUsuario();
    }
}else{
    if (opcionN == 2){
        if (mostrarInicioSesion()){

        }

    }
}