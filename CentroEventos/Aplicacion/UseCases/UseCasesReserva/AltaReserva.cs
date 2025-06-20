using Aplicacion.interfacesServ;
using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.validadores;

namespace Aplicacion.UseCases.UseCasesReserva;

public class AltaReserva (IRepositorioReserva repositorio, IRepositorioPersona _repoPers, IRepositorioEventoDeportivo _repoEv) : ReservaUseCase(repositorio)
{
    public void Ejecutar(int idPers, int idEv/*, int idUser*/)
    {
        Console.WriteLine("Adentro del metodo");
        try
        {
            string mensaje = "";
            if (!ValidadorReserva.validarDatos(idPers, idEv, DateTime.Now, repo, _repoEv, _repoPers, ref mensaje))
            {
                throw new ValidacionException(mensaje);
            }
            Reserva resGenerada = new(idPers, idEv);
            Console.WriteLine("che pero esto no tiene nigun sentido");
            this.repo.Agregar(resGenerada);
        }
        catch (Exception e)
        {
            Console.WriteLine("gilazo");
            Console.WriteLine(e.Message);
        }
    }
}