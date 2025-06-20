using System;

namespace Aplicacion.excepciones;

public class DuplicadoException : Exception
{

    public DuplicadoException() 
        : base("Ya existe el elemento que desea crear. (persona/reserva)") { }


    public DuplicadoException(string mensaje) 
        : base(mensaje) { }


    public DuplicadoException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
