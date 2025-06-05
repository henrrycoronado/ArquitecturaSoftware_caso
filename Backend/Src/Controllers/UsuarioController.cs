using Microsoft.AspNetCore.Mvc;
using AppBackend.Entities;
using AppBackend.UseCases;

namespace AppBackend.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCases _usuarioUseCases;

        public UsuarioController(IUsuarioUseCases usuarioUseCases)
        {
            _usuarioUseCases = usuarioUseCases;
        }

        [HttpGet("/Usuarios")]
        public IActionResult GetUsuarios()
        {
            var resp = _usuarioUseCases.GetUsuarios();
            return Ok(resp);
        }

        [HttpPost("/Usuarios/Crear")]
        public IActionResult GetUsuarios([FromBody] NewUsuario user)
        {
            var resp = _usuarioUseCases.CreateUsuario(user.nombre, user.ci);
            if(resp){
                return Ok("Usuario creado con exito");
            }
            return Ok("usuario no creado, revisa tus entradas que no existan");
        }

        [HttpGet("/Usuarios/{id}")]
        public IActionResult GetUsuario(int id)
        {
            var resp = _usuarioUseCases.GetUsuario(id);
            if(resp == null){
                return Ok("usuario no encontrado");
            }
            return Ok(resp);
        }

        [HttpGet("/Usuarios/{id}/MisInscripciones")]
        public IActionResult GetInscripciones(int id)
        {
            var resp = _usuarioUseCases.GetInscripciones(id);
            return Ok(resp);
        }
        
    }
    public class NewUsuario{
        public string nombre { get; set; } = null!;
        public string ci { get; set; } = null!;
    }