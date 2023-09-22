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
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presenca;
        public PresencasEventoController()
        {
            _presenca = new PresencasEventoRepository();
        }

        [HttpPost]
        public IActionResult Post(Guid idEvento, Guid idUsuario)
        {
            try
            {
                _presenca.ParticiparEvento(idEvento, idUsuario);
                return Ok("Presença cadastrada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_presenca.ListarPresencas(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid idEvento, Guid idUsuario)
        {
            try
            {
                _presenca.CancelarParticipacao(idEvento, idUsuario);
                return Ok("Participação cancelada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}
