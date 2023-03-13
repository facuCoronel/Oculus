using Api.Cliente.Servicios.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Cliente.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        IServicioCliente _sc;

        public ClienteController(IServicioCliente sc)
        {
            _sc = sc;
        }


        [HttpGet]
        public async Task<IActionResult> getCliente()
        {
            var result = await _sc.GetClientes();
            if (!result.Error)
            {
                return Ok(result);
            }else return BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> postCliente(string nombre, int tel, int idCiudad)
        {
            var result = await _sc.InsertarCliente(nombre, tel, idCiudad);

            if (!result.Error)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> putCliente(int idCliente, string? nombre, int tel, int idCiudad)
        {
            var result = await _sc.Update(idCliente,nombre, tel,idCiudad);

            if (!result.Error)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
