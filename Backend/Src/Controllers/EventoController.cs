using Microsoft.AspNetCore.Mvc;
using AppBackend.Entities;
using AppBackend.UseCases;

namespace AppBackend.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoUseCases _eventoUseCases;
        private readonly IUsuarioUseCases _usuarioUseCases;
        private readonly IInscripcionUseCases _inscripcionUseCases;

        public EventoController(IEventoUseCases eventoUseCases, IUsuarioUseCases usuarioUseCases, IInscripcionUseCases inscripcionUseCases)
        {
            _eventoUseCases = eventoUseCases;
            _usuarioUseCases = usuarioUseCases;
            _inscripcionUseCases = inscripcionUseCases;
        }

        [HttpGet]
        public IActionResult GetEventos()
        {
            var eventos = _eventoUseCases.GetEventos();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvento(int id)
        {
            var evento = _eventoUseCases.GetEvento(id);
            if (evento == null)
                return NotFound("Evento no encontrado");
            return Ok(evento);
        }

        [HttpPost("registrar")]
        public IActionResult RegistrarEnEvento([FromBody] RegistrarEventoRequest request)
        {
            var evento = _eventoUseCases.GetEvento(request.IdEvento);
            if (evento == null)
                return NotFound("Evento no encontrado");
            if (evento.Fecha < DateTime.Now)
                return BadRequest("No se puede registrar en eventos pasados");
            if (evento.registros.Any(u => u.Ci == request.CiUsuario))
                return BadRequest("El usuario ya está registrado en este evento");
            if (evento.registros.Count >= evento.Capacidad)
                return BadRequest("El evento ha alcanzado su capacidad máxima");
            var usuario = _usuarioUseCases.GetUsuarios().FirstOrDefault(u => u.Ci == request.CiUsuario);
            if (usuario == null)
            {
                usuario = new Usuario { Nombre = request.NombreUsuario, Ci = request.CiUsuario };
                _usuarioUseCases.CreateUsuario(usuario);
            }
            var inscripcion = new Inscripcion { IdUsuario = usuario.Id, IdEvento = evento.Id, Estado = true };
            _inscripcionUseCases.CreateInscripcion(inscripcion);
            evento.registros.Add(usuario);
            _eventoUseCases.UpdateEvento(evento);
            return Ok("Registro exitoso");
        }

        [HttpGet("{id}/usuarios")]
        public IActionResult GetUsuariosRegistrados(int id)
        {
            var evento = _eventoUseCases.GetEvento(id);
            if (evento == null)
                return NotFound("Evento no encontrado");
            return Ok(evento.registros);
        }
    }

    public class RegistrarEventoRequest
    {
        public int IdEvento { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string CiUsuario { get; set; } = null!;
    }