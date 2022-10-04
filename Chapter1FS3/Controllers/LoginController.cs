using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Chapter1FS3.Interfaces;
using Chapter1FS3.Models;
using Chapter1FS3.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Chapter1FS3.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;

        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iusuarioRepository = iUsuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuario UsuarioBuscado = _iusuarioRepository.Login(dadosLogin.Email, dadosLogin.Senha);
                if (UsuarioBuscado == null)
                {
                    return Unauthorized(new {msg = "Email e/ou senha incorretos"});
                }
                var minhasCalims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chapter1-autenticacao"));
                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer: "chapter1.webapi",
                    audience: "chapter1.webapi",
                    claims: minhasCalims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credenciais
                    );
                return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(meuToken) });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
