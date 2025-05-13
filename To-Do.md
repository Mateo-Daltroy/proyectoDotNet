
# Entidades a Implementar (en CentroEventos.Aplicacion)
● Persona: Representa a cualquier individuo relacionado con el centro deportivo.
- [ ] Id (int, único, debe ser autoincremental gestionado por el repositorio)
- [ ] DNI (string, único)
- [ ] Nombre (string)
- [ ] Apellido (string)
- [ ] Email (string, único)
- [ ] Telefono (string)

● EventoDeportivo: Representa una instancia específica de un evento deportivo programado en
- [ ] fecha y hora determinadas.
- [ ] Id (int, único, debe ser autoincremental gestionado por el repositorio)
- [ ] Nombre (string - ej: "Clase de Spinning Avanzado", "Partido final de Vóley")
- [ ] Descripcion (string)
- [ ] FechaHoraInicio (DateTime - Fecha y hora exactas de inicio del evento)
- [ ] DuracionHoras (double - Duración del evento en horas, ej: 1.5 para una hora y media)
- [ ] CupoMaximo (int - Cantidad máxima de participantes permitidos)
- [ ] ResponsableId (int - Id de la Persona a cargo del evento)

● Reserva: Representa la inscripción de una persona a un evento deportivo específico.
- [ ] Id (int, único, debe ser autoincremental gestionado por el repositorio)
- [ ] PersonaId (int - Id de la Persona que hace la reserva)
- [ ] EventoDeportivoId (int - Id de la EventoDeportivo reservado)
- [ ] FechaAltaReserva (DateTime - Fecha y hora en que se realizó la inscripción)
- [ ] EstadoAsistencia (enum: Pendiente, Presente, Ausente)

Implementar el método ToString() de forma conveniente en las entidades para facilitar la visualización
en la consola

#
