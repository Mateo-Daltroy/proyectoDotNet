using System;

namespace Aplicacion.excepciones;

public class ValidacionException : Exception
{
    // Constructor sin parámetros
    public ValidacionException() 
        : base("Error en el ingreso de datos.") { }

    // Constructor con mensaje personalizado
    public ValidacionException(string mensaje) 
        : base(mensaje) { }

    // Constructor con mensaje y excepción interna
    public ValidacionException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
