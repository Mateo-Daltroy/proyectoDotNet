using System;

namespace Aplicacion.excepciones;

public class DuplicadoException : Exception
{
    // Constructor sin parámetros
    public DuplicadoException() 
        : base("Ya existe el elemento que desea crear. (persona/reserva)") { }

    // Constructor con mensaje personalizado
    public DuplicadoException(string mensaje) 
        : base(mensaje) { }

    // Constructor con mensaje y excepción interna
    public DuplicadoException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
