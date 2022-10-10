using APIMsFinanceiro.Attributes;
using Microsoft.AspNetCore.Mvc;

// Healt Check
namespace APIMsFinanceiro.Contorllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        //[HttpGet("healt-check")]
        [HttpGet("")]
        //[ApiKey]
        public IActionResult Get()
        {
            //return Ok( new { });
            return Ok();
        }

    }
}
