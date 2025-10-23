using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaCitas.BusinessLogic.Services;

namespace SistemaCitas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ServicesCitas _services;
        private readonly IMapper _mapper;

        public CitasController(ServicesCitas services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("ListarCitas")]
        public IActionResult ListarCitasPorCliente(int clienteId)
        {
            var list = _services.ListarCitasPorCliente(clienteId);
            return Ok(list);
        }
    }
}