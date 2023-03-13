using AccesoDatos;
using Api.Provincia.Servicios.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Provincia;

namespace Api.Privincia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        IServicioProvincia _sp;

        public ProvinciaController(IServicioProvincia sp)
        {
            _sp = sp;
        }

        [HttpGet("ListarProvincias")]
        public async Task<IActionResult> Get()
        {
            var get = await _sp.Get();

            if (!get.Error)
            {
                return Ok(get);
            }
            else return BadRequest(get);
        }

        [HttpPost("InsertarProvincia")]
        public async Task<IActionResult> Save(Provincias Provincia)
        {
            var insert = await _sp.Save(Provincia);

            if(!insert.Error)
            {
                return Ok(insert);
            }else return BadRequest(insert);
        }
    }
}
