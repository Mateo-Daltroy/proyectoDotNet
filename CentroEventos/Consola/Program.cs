// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Diagnostics;
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
CRUDEventoDeportivo cRUDEventoDeportivo = new CRUDEventoDeportivo(repoTempEv, repoTempPers, repoTempRes,gestor);


// Display
Console.WriteLine("-----------------------------------------------");
Console.WriteLine("|        Bienvenido a la consola del 	      |");
Console.WriteLine("|       Centro Deportivo Universitario!	      |");
Console.WriteLine("-----------------------------------------------");
while (Id == -1)
{
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
    List<EventoDeportivo> eventos = (List<EventoDeportivo>)cRUDEventoDeportivo.ListarEventosConCupoDisponible(repoTempRes);
    foreach (EventoDeportivo ev in eventos)
    {
        Console.WriteLine(ev.ToString());
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
        Console.WriteLine("| 15 |    	 Cerrar la consola	      |");
        Console.WriteLine("-----------------------------------------------");
        Console.Write("| -> ");
        input = "invalido";
        while (input.Equals("invalido") || opcion == -1)
        {
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
        switch (opcion)
        {
            case 1:
                // Registrar Persona
                Console.Write("DNI: ");
                string dni = Console.ReadLine() ?? "";
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine() ?? "";
                Console.Write("Apellido: ");
                string apellido = Console.ReadLine() ?? "";
                Console.Write("Email: ");
                string email = Console.ReadLine() ?? "";
                Console.Write("Telefono: ");
                string telefono = Console.ReadLine() ?? "";
                Persona nuevaPersona = new(dni, nombre, apellido, email, telefono); // suponiendo que tenés este constructor
                cRUDPersona.AgregarPersona(nuevaPersona);
                break;

            case 2:
                // Modificar Persona
                Console.Write("DNI de la persona a modificar: ");
                string dniMod = Console.ReadLine() ?? "";

                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine() ?? "";
                Console.Write("Nuevo apellido: ");
                string nuevoApellido = Console.ReadLine() ?? "";
                Console.Write("Nuevo telefono: ");
                string nuevoTelefono = Console.ReadLine() ?? "";
                Console.Write("Nuevo email: ");
                string nuevoEmail = Console.ReadLine() ?? "";
                Persona personaModificada = new(cRUDPersona.getIdConDocumento(dniMod), dniMod, nuevoNombre, nuevoApellido, nuevoTelefono, nuevoEmail); // dni no se cambia
                cRUDPersona.modificarPersona(personaModificada);
                break;

            case 3:
                // Eliminar Persona
                Console.Write("DNI de la persona a eliminar: ");
                string dniEliminar = Console.ReadLine() ?? "";
                int id = cRUDPersona.getIdConDocumento(dniEliminar);
                cRUDPersona.EliminarPersona(id);
                break;

            case 4:
                // Listar Personas
                Console.WriteLine(cRUDPersona.ListadoCompleto());
                break;

            case 5:
                // Registrar Reserva
                Console.Write("ingresa DNI Persona: ");
                string dniPersona = Console.ReadLine() ?? "";
                int idPersona = cRUDPersona.getIdConDocumento(dniPersona);

                List<EventoDeportivo> eventosConCupo = (List<EventoDeportivo>)cRUDEventoDeportivo.ListarEventosConCupoDisponible(repoTempRes); // Listar eventos disponibles
                foreach (EventoDeportivo ev in eventosConCupo)
                {
                    Console.WriteLine(ev.ToString());
                }
                Console.Write("Ingrese el ID de uno de los anteriores eventos disponibles en el que quiera realizar la reserva: ");
                int idEventoRes = int.Parse(Console.ReadLine() ?? "-1");

                cRUDReserva.ReservaAlta(idPersona, idEventoRes, Id);
                break;

            case 6:
                // Modificar Reserva
                List<Reserva> listadoReservas = (List<Reserva>)cRUDReserva.ListarTodas(); // Listar eventos disponibles
                Console.WriteLine("Listado de reservas:");
                foreach (Reserva ev in listadoReservas) {
                    Console.WriteLine(ev.ToString());
                }

                Console.Write("Ingrese el ID de la reserva elegida a modificar: ");
                int idReserva = int.Parse(Console.ReadLine() ?? "-1");

                // Mostrar opciones válidas
                Console.WriteLine("Ingrese el nuevo estado de asistencia:");
                Console.WriteLine("Opciones válidas:");
                foreach (var nombre1 in Enum.GetNames(typeof(Asistencia)))
                {
                    Console.WriteLine($"- {nombre1}");
                }

                // Leer del teclado
                Console.Write("Ingrese nuevo estado de la reserva -> ");
                string inputEstado = Console.ReadLine() ?? "";

                // Intentar parsear
                if (Enum.TryParse<Asistencia>(inputEstado, ignoreCase: true, out Asistencia nuevoEstado))
                {
                    // Obtener reserva y modificar
                    Reserva reservaModificada = cRUDReserva.obtenerPorId(idReserva);
                    reservaModificada._estadoAsistencia = nuevoEstado;

                    // (Asegurate de guardar la modificación con el método correspondiente)
                    cRUDReserva.ReservaModificacion(reservaModificada, Id);
                }
                else
                {
                    Console.WriteLine("Estado inválido. Intente nuevamente.");
                }
                break;

            case 7:
                // Eliminar Reserva
                List<Reserva> listadoReservas2 = (List<Reserva>)cRUDReserva.ListarTodas(); // Listar eventos disponibles
                Console.WriteLine("Listado de reservas:");

            foreach (Reserva re in listadoReservas2) {
                    Console.WriteLine(re.ToString());
                }

                Console.Write("Ingrese el ID de la reserva elegida a eliminar: ");
                int idResEliminar = int.Parse(Console.ReadLine() ?? "-1");
                cRUDReserva.ReservaBaja(idResEliminar, Id);
                break;

            case 8:
                // Listar Reservas
                foreach (var res in cRUDReserva.ListarTodas())
                {
                    Console.WriteLine(res.ToString()); // asegurate de tener override de ToString() en Reserva
                }
                break;

            case 9:
                // Registrar Evento Deportivo
                Console.Write("Nombre: ");
                string nombreEv = Console.ReadLine() ?? "";
                Console.Write("Descripción: ");
                string descEv = Console.ReadLine() ?? "";
                Console.Write("Fecha y hora (yyyy-MM-dd HH:mm): ");
                DateTime fecha = DateTime.Parse(Console.ReadLine() ?? "");
                Console.Write("Duración en horas: ");
                int duracion = int.Parse(Console.ReadLine() ?? "-1");
                Console.Write("Cupo máximo: ");
                int cupo = int.Parse(Console.ReadLine() ?? "-1");
                Console.Write("Documento del Responsable: ");
                int doc = int.Parse(Console.ReadLine() ?? "-1");
                int idresp = repoTempPers.getIdConDocumento(doc.ToString());

                EventoDeportivo nuevoEvento = new(nombreEv, descEv, fecha, duracion, cupo, idresp);
                //EL SIGUIENTE METODO ALTA() SE ENCARGARA DE ASIGNARLE EL ID CORRESPONDIENTE A EVENTO
                cRUDEventoDeportivo.Alta(nuevoEvento, Id, new ValidadorEventoDeportivo());
                break;

            case 10:
                // Modificar Evento Deportivo
                List<EventoDeportivo> eventosConCupo2 = (List<EventoDeportivo>)cRUDEventoDeportivo.Listado(); // Listar eventos disponibles
                Console.WriteLine("Eventos disponibles para modificar:" );
                foreach (EventoDeportivo ev in eventosConCupo2) {
                    Console.WriteLine(ev.ToString());
                }
                Console.Write("Ingrese el ID de uno de los anteriores eventos que quiera modificar: ");
                int idEvModificar = int.Parse(Console.ReadLine() ?? "-1");
                EventoDeportivo eventoMod = repoTempEv.ObtenerPorId(idEvModificar);
                
                Console.Write("Nuevo nombre: ");
                string nombreNuevoEv = Console.ReadLine() ?? "";
                if (!nombreNuevoEv.Equals(""))
                {
                    eventoMod._nombre = nombreNuevoEv;
                }

                Console.Write("Nueva descripción: ");
                string descNuevoEv = Console.ReadLine() ?? "";
                if (!descNuevoEv.Equals(""))
                {
                    eventoMod._descripcion = descNuevoEv;
                }

                Console.Write("Nueva fecha y hora (yyyy-MM-dd HH:mm): ");
                String nuevaFechaa = Console.ReadLine() ?? "";
                if (!nuevaFechaa.Equals(""))
                {
                    DateTime nuevaFecha = DateTime.Parse(nuevaFechaa);
                    eventoMod._fechaHoraInicio = nuevaFecha;
                }

                Console.Write("Nueva duración en horas: ");
                String nuevaDuracion = Console.ReadLine() ?? "";
                if (!nuevaDuracion.Equals(""))
                {
                    eventoMod._duracionHoras = int.Parse(nuevaDuracion);
                }

                Console.Write("Nuevo cupo: ");
                String nuevoCupo = Console.ReadLine() ?? "";
                if (!nuevoCupo.Equals(""))
                {
                    eventoMod._cupoMaximo = int.Parse(nuevoCupo);
                }

                Console.Write("ID Responsable: ");
                String idResponsable = Console.ReadLine() ?? "";
                if (!idResponsable.Equals(""))
                {
                    eventoMod._responsableId = int.Parse(idResponsable);
                }
                cRUDEventoDeportivo.Modificacion(eventoMod, Id, new ValidadorEventoDeportivo());
                break;

            case 11:
                // Eliminar Evento Deportivo
                List<EventoDeportivo> listadoEventos2 = (List<EventoDeportivo>)cRUDEventoDeportivo.listadoSinReservas(); // Listar eventos disponibles

                Console.WriteLine("Eventos disponibles para eliminar:");
                foreach (EventoDeportivo e in listadoEventos2) {
                    Console.WriteLine(e.ToString());
                }
                Console.Write("Ingrese el ID de uno de los anteriores eventos que quiera eliminar: ");
                int idEvEliminar = int.Parse(Console.ReadLine() ?? "-1");
                cRUDEventoDeportivo.Baja(idEvEliminar, Id);
                break;

            case 12:
                // Listar Eventos Deportivos
                foreach (var ev in cRUDEventoDeportivo.Listado())
                {
                    Console.WriteLine(ev.ToString()); // asegurate de tener override de ToString() en EventoDeportivo
                }
                break;

            case 13:
                // Listar asistencia a un evento
                List<EventoDeportivo> listadoEventos = (List<EventoDeportivo>)cRUDEventoDeportivo.Listado(); // Listar eventos disponibles
                Console.WriteLine("Eventos pasados:");
                foreach (EventoDeportivo e in listadoEventos)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.Write("Ingrese el ID de uno de los anteriores eventos pasados: ");
                int idListarAsistencia = int.Parse(Console.ReadLine() ?? "-1");
                List<int> idAsistentes = (List<int>)cRUDReserva.asistioAEvento(idListarAsistencia);
                foreach (int id2 in idAsistentes)
                {
                    String p = repoTempPers.getNombreConId(id2);
                    Console.WriteLine(p+" participo en el evento." ); 
                }
                break;

            case 14:
                // Listar eventos con cupo
                foreach (var eventoo in cRUDEventoDeportivo.ListarEventosConCupoDisponible(repoTempRes))
                {
                    Console.WriteLine(eventoo.ToString());
                }
                break;

            case 15:
                // Salir
                Console.WriteLine("Saliendo...");
                break;
        }

    }
}