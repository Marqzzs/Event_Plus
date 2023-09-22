using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private IComentariosEventoRepository _comentariosEvento;

        public ComentarioEventoController()
        {
            _comentariosEvento = new ComentariosEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(ComentariosEvento comentario)
        {
            try
            {
                _comentariosEvento.Comentar(comentario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentariosEvento.ListarPorEvento(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosEvento.Deletar(id);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
