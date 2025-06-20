using Aplicacion.interfacesServ;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;

namespace Aplicacion.UseCases.UseCasesReserva;

public class ModificarReserva (IRepositorioReserva repositorio) : ReservaUseCase(repositorio)
{
    public void Ejecutar(Reserva Res/*, int idUser*/)
    {
        try
        {
            if (!repo.ExisteId(Res._id)) { throw new EntidadNotFoundException(); }
            repo.Actualizar(Res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}