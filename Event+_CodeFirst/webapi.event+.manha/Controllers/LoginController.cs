using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;
using webapi.event_.manha.ViewModels;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha incorretos");
                }
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),

                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.TiposUsuario!.Titulo!)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event+-chave-autenticacao-webapi"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                            //emissor do token
                            issuer: "webapi.event+.manha",

                            //Destinatario do token
                            audience: "webapi.event+.manha",

                            //Dados definidos nas Claims(informações)
                            claims: claims,

                            //Tempo de expiração do token
                            expires: DateTime.Now.AddMinutes(5),

                            //Credenciais do token
                            signingCredentials: creds
                    );
                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
