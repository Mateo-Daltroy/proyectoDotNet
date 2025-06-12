using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using Aplicacion.validadores;
using CentroEventos.Repositorios.GestionIDs;
using Aplicacion.autorizacionProv;
using CentroEventos.Aplicacion.InterfacesRepo;
using System.Runtime.InteropServices;

namespace Repositorios.CRUDs;

public class CRUDEventoDeportivo
{
    private readonly IRepositorioEventoDeportivo _repo;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioReserva _repoReserva;
    private readonly IIdManager _gestor;
    private readonly IServicioAutorizacion _auth;

    private readonly string _pathId = Path.Combine(
        Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
        "EventosId.txt"
    );

    public CRUDEventoDeportivo(IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, IRepositorioReserva repoReserva, IIdManager gestor)
    {
        _repo = repoEvento;
        _repoPersona = repoPersona;
        _repoReserva = repoReserva;
        _gestor = gestor;
        _auth = new ServicioAuthProvisional(); // solo devuelve true para user id 1
    }


    

    public void Modificacion(EventoDeportivo evento, int idUsuario, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoModificacion))
                throw new FalloAutorizacionException();

            if (!_repo.Contiene(evento._id))
                throw new EntidadNotFoundException();

            EventoDeportivo existente = _repo.ObtenerPorId(evento._id);
            if (existente._fechaHoraInicio < DateTime.Now)
                throw new OperacionInvalidaException("No se puede modificar un evento ya iniciado o pasado.");

            validadorEventoDeportivo.Validar(evento, _repoPersona);

            _repo.Actualizar(evento);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public IEnumerable<EventoDeportivo> Listado()
    {
        return _repo.ObtenerTodos();
    }

    public IEnumerable<EventoDeportivo> listadoSinReservas()
    {
        List<EventoDeportivo> l = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in _repo.ObtenerTodos())
        {
            if (_repoReserva.GetAsistentes(e._id) == 0)
            {
                l.Add(e);
            }
        }
        return l;
    }

    public IEnumerable<EventoDeportivo> ListadoPasado()
    {
        List<EventoDeportivo> l = new List<EventoDeportivo>();
        foreach (EventoDeportivo e in _repo.ObtenerTodos())
        {
            if (e._fechaHoraInicio < DateTime.Now)
            {
                l.Add(e);
            }
        }
        return l;
    }

    public IEnumerable<EventoDeportivo> ListarEventosConCupoDisponible(IRepositorioReserva repoReserva)
    {
        List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();

        foreach (EventoDeportivo evento in _repo.ObtenerTodos())
        {
            int participantesActuales = repoReserva.GetAsistentes(evento._id);
            if (evento.TieneCupoDisponible(participantesActuales))
            {
                eventosConCupo.Add(evento);
            }

        }

        return eventosConCupo;
    }

    public EventoDeportivo obtenerPorId(int id)
    {

        return _repo.ObtenerPorId(id);

    }

}
