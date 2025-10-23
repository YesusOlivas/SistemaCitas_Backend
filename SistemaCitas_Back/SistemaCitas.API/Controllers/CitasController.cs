using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaCitas.API.Models;
using SistemaCitas.BusinessLogic.Services;
using SistemaCitas.Entities.Entities;

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

        [HttpPost("InsertarCita")]
        public IActionResult InsertarCitas([FromBody] CitasViewModel citas)
        {
            var mapped = _mapper.Map<Citas>(citas);
            var insert = _services.InsertarCitas(mapped);
            return Ok(insert);
        }

        [HttpPost("CancelarCita")]
        public IActionResult CancelarCita([FromBody] CitasViewModel citas)
        {
            var mapped = _mapper.Map<Citas>(citas);
            var cancel = _services.CancelarCita(mapped);
            return Ok(cancel);
        }
    }
}