using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaCitas.API.Models;
using SistemaCitas.BusinessLogic.Services;
using SistemaCitas.Entities.Entities;

namespace SistemaCitas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly ServicesCitas _services;
        private readonly IMapper _mapper;

        public ClientesController(ServicesCitas services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost("RegistrarCliente")]
        public IActionResult RegistrarCliente([FromBody] ClienteViewModel cliente)
        {
            var mapped = _mapper.Map<Clientes>(cliente);
            var insert = _services.RegistrarCliente(mapped);
            return Ok(insert);
        }
    }
}
