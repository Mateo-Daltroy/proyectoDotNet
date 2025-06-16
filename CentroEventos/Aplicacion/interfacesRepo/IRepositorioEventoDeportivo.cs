using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.entidades;

namespace Aplicacion.interfacesRepo;

public interface IRepositorioEventoDeportivo : IDisposable
{
    Task AgregarAsync(EventoDeportivo ev);
    Task<EventoDeportivo> ObtenerPorIdAsync(int id);
    Task ActualizarAsync(EventoDeportivo ev);
    Task EliminarAsync(int id);
    Task<IEnumerable<EventoDeportivo>> ObtenerTodosAsync();
    Task<bool> ContieneAsync(int id);
}