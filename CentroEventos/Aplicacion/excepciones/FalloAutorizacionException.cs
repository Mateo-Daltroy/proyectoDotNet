using System;

namespace Aplicacion.excepciones;

public class FalloAutorizacionException : Exception
{

    public FalloAutorizacionException() 
        : base("El usuario no posee la autorizacion necesaria para la operacion deseada.") { }


    public FalloAutorizacionException(string mensaje) 
        : base(mensaje) { }

 
    public FalloAutorizacionException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
