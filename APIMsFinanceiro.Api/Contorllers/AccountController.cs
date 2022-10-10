using APIMsFinanceiro.Extensions;
using APIMsFinanceiro.Services;
using APIMsFinanceiro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIMsFinanceiro.Contorllers
{
    
    [ApiController]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("v1/accounts/login")]
        public IActionResult Login(
            [FromBody] LoginViewModel login,
            [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErros()));

            if (login.ClientId != Configuration.ClientId ||
                login.ClientSecret != Configuration.ClientSecret)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválido!"));

            var token = tokenService.GenerateToken(login);

            return Ok(new ResultViewModel<dynamic>( new
            {
                token
            }));
        }
    }
}
