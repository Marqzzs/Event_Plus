using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;

        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(TiposEvento tiposEvento)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(tiposEvento);
                return StatusCode(201);
            }
            catch (Exception e)
            {  
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tiposEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, TiposEvento tiposEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(id, tiposEvento);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
