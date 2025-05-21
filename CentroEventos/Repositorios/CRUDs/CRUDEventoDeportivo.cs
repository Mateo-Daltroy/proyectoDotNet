using Aplicacion.entidades;
using Aplicacion.excepciones;
using Aplicacion.interfacesRepo;
using Aplicacion.interfacesServ;
using Aplicacion.validadores;
using CentroEventos.Repositorios.GestionIDs;
using Aplicacion.autorizacionProv;
using CentroEventos.Aplicacion.InterfacesRepo;

namespace Repositorios.CRUDs;

public class CRUDEventoDeportivo
{
    private readonly IRepositorioEventoDeportivo _repo;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IIdManager _gestor;
    private readonly IServicioAutorizacion _auth;

    private readonly string _pathId = Path.Combine(
        Directory.GetParent(Environment.CurrentDirectory)?.FullName ?? "",
        "EventosId.txt"
    );

    public CRUDEventoDeportivo(IRepositorioEventoDeportivo repoEvento, IRepositorioPersona repoPersona, IIdManager gestor)
    {
        _repo = repoEvento;
        _repoPersona = repoPersona;
        _gestor = gestor;
        _auth = new ServicioAuthProvisional(); // solo devuelve true para user id 1
    }

    public void Alta(EventoDeportivo evento, int idUsuario, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoAlta))
                throw new FalloAutorizacionException();

            validadorEventoDeportivo.Validar(evento, _repoPersona);

            int nuevoId = _gestor.ObtenerNuevoId(_pathId);
            EventoDeportivo eventoFinal = new(
                id: nuevoId,
                nombre: evento._nombre,
                descripcion: evento._descripcion,
                fechaHoraInicio: evento._fechaHoraInicio,
                duracionHoras: evento._duracionHoras,
                cupoMaximo: evento._cupoMaximo,
                responsableId: evento._responsableId
            );

            _repo.Agregar(eventoFinal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Baja(int id, int idUsuario)
    {
        try
        {
            if (!_auth.PoseeElPermiso(idUsuario, Permiso.EventoBaja))
                throw new FalloAutorizacionException();

            if (!_repo.Contiene(id))
                throw new EntidadNotFoundException();

            _repo.Eliminar(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
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

    public IEnumerable<EventoDeportivo> ListarEventosConCupoDisponible(IRepositorioReserva repoReserva)
    {
        List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();
        foreach (var evento in _repo.ObtenerTodos())
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
