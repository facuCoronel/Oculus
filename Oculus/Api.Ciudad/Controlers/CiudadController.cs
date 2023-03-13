using Api.Ciudad.Servicios.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Api.Ciudad.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        IServicioCiudad _sc;

        public CiudadController(IServicioCiudad sc)
        {
            _sc = sc;
        }

        [HttpGet("ConsultarCiudad")]
        public async Task<IActionResult> get()
        {
            var result = await _sc.get();

            if (!result.Error)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpPost("InsertarCiudad")]
        public async Task<IActionResult> post(Ciudades ciudad)
        {
            var result = await _sc.save(ciudad);

            if (!result.Error)
            {
                return Ok(result);

            }
            else return BadRequest(result);
        }

    }
}
