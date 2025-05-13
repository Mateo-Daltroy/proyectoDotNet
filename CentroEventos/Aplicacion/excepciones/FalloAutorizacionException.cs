using System;

namespace Aplicacion.excepciones;

public class FalloAutorizacionException : Exception
{
    // Constructor sin parámetros
    public FalloAutorizacionException() 
        : base("El usuario no posee la autorizacion necesaria para la operacion deseada.") { }

    // Constructor con mensaje personalizado
    public FalloAutorizacionException(string mensaje) 
        : base(mensaje) { }

    // Constructor con mensaje y excepción interna
    public FalloAutorizacionException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
