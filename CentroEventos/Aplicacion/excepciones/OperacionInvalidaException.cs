using System;

namespace Aplicacion.excepciones;

public class OperacionInvalidaException : Exception
{
    // Constructor sin parámetros
    public OperacionInvalidaException() 
        : base("Operacion no permitida, viola con las reglas de negocio.") { }

    // Constructor con mensaje personalizado
    public OperacionInvalidaException(string mensaje) 
        : base(mensaje) { }

    // Constructor con mensaje y excepción interna
    public OperacionInvalidaException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
