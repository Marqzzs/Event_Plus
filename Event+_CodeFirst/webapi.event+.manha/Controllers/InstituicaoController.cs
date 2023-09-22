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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastar(instituicao);
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
                return Ok(_instituicaoRepository.Listar());
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
                return Ok(_instituicaoRepository.BuscarPorId(id));
            }
            catch (Exception e )
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);
                return Ok();
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }
    }
}
