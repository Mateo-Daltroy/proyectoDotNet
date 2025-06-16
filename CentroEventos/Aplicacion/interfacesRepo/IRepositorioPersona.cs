using System;
using Aplicacion.autorizacionProv;
using Aplicacion.entidades;
using CentroEventos.Aplicacion.InterfacesRepo;

namespace Aplicacion.UseCases.UseCasesReserva;

public interface IRepositorioPersona
{
    public void AltaPersona(Persona p);
    public void BajaPersona(int id);
    public Persona ExistePersonaPorId(int id);
    public List<Persona> ListarTodasLasPersonas();
}
