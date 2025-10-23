using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaCitas.BusinessLogic.Services;

namespace SistemaCitas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadesController : Controller
    {
        private readonly ServicesCitas _services;
        private readonly IMapper _mapper;

        public EspecialidadesController(ServicesCitas services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("ListarEspecialidades")]
        public IActionResult ListarEspecialidades()
        {
            var list = _services.ListarEspecialidades();
            return Ok(list);
        }
    }
}
