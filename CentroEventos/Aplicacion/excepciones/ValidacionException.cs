using System;

namespace Aplicacion.excepciones;

public class ValidacionException : Exception
{
     public ValidacionException() 
        : base("Error en el ingreso de datos.") { }


    public ValidacionException(string mensaje) 
        : base(mensaje) { }


    public ValidacionException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
