using Microsoft.AspNetCore.Mvc;
using AppBackend.Entities;
using AppBackend.UseCases;

namespace AppBackend.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoUseCases _eventoUseCases;

        public EventoController(IEventoUseCases eventoUseCases)
        {
            _eventoUseCases = eventoUseCases;
        }

        [HttpGet("/Eventos")]
        public IActionResult GetEventos()
        {
            var resp = _eventoUseCases.GetEventos();
            return Ok(resp);
        }
        [HttpPost("/Eventos/Crear")]
        public IActionResult CrearEventos([FromBody] NewEvento evento)
        {
            var resp = _eventoUseCases.CreateEvento(evento.Nombre, evento.Fecha, evento.Capacidad, evento.Costo);
            if(resp){
                return Ok("evento creado con exito, puedes revisarlo en la lista");
            }
            return Ok("evento no creado, revisa tus parametros");
        }

        [HttpGet("/Eventos/{id}")]
        public IActionResult GetEvento(int id)
        {
            var resp = _eventoUseCases.GetEvento(id);
            if(resp!=null){
                return Ok(resp);
            }
            return Ok("Evento no encontrado");
        }

        [HttpPost("/Eventos/{id}/registrar")]
        public IActionResult RegistrarEnEvento(int id, string ci)
        {
            var resp = _eventoUseCases.RegistrarEnEvento(id, ci);
            if(resp){
                return Ok("Registrado con exito");
            }
            return Ok("No se pudo registrar, revisa tus parametros");
        }
    }

    public class NewEvento{
        public string Nombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int Capacidad { get; set; }
        public double? Costo { get; set; }
    }
