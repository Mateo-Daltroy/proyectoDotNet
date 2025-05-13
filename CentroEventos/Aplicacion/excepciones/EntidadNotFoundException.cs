using System;

namespace Aplicacion.excepciones;

public class EntidadNotFoundException : Exception
{
    // Constructor sin parámetros
    public EntidadNotFoundException() 
        : base("No hay ningun usuario registrado bajo el ID ingresado.") { }

    // Constructor con mensaje personalizado
    public EntidadNotFoundException(string mensaje) 
        : base(mensaje) { }

    // Constructor con mensaje y excepción interna
    public EntidadNotFoundException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
