using System;

namespace Aplicacion.excepciones;

public class OperacionInvalidaException : Exception
{

    public OperacionInvalidaException() 
        : base("Operacion no permitida, viola con las reglas de negocio.") { }

    public OperacionInvalidaException(string mensaje) 
        : base(mensaje) { }

    public OperacionInvalidaException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
