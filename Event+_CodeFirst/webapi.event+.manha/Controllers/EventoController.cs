using Azure.Core;
using Microsoft.AspNetCore.Authorization;
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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles ="Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
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
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}
