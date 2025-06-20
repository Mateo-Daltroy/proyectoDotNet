using System;

namespace Aplicacion.excepciones;

public class EntidadNotFoundException : Exception
{

    public EntidadNotFoundException() 
        : base("No hay ningun usuario registrado bajo el ID ingresado.") { }


    public EntidadNotFoundException(string mensaje) 
        : base(mensaje) { }

 
    public EntidadNotFoundException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
