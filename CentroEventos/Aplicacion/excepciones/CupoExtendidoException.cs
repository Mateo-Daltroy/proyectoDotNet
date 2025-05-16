using System;

namespace Aplicacion.excepciones;

public class CupoExtendidoException : Exception
{
    // Constructor sin parámetros
    public CupoExtendidoException() 
        : base("Reserva invalida, el cupo ya esta lleno.") { }

    // Constructor con mensaje personalizado
    public CupoExtendidoException(string mensaje) 
        : base(mensaje) { }

    // Constructor con mensaje y excepción interna
    public CupoExtendidoException(string mensaje, Exception innerException) 
        : base(mensaje, innerException) { }
}
