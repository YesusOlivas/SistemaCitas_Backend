using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaCitas.API.Models;
using SistemaCitas.BusinessLogic.Services;
using SistemaCitas.Entities.Entities;

namespace SistemaCitas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ServicesCitas _services;
        private readonly IMapper _mapper;

        public UsuarioController(ServicesCitas services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost("IniciarSesion")]
        public IActionResult IniciarSesion([FromBody] UsuarioViewModel usuarios)
        {
            var mapped = _mapper.Map<Usuarios>(usuarios);
            var login = _services.IniciarSesion(mapped);
            return Ok(login);
        }
    }
}
