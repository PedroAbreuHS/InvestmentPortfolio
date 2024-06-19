
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases.UsuarioUseCases;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CadastrarUsuarioUseCase _cadastrarUsuarioUseCase;

        public UsuarioController(CadastrarUsuarioUseCase cadastrarUsuarioUseCase)
        {
            _cadastrarUsuarioUseCase = cadastrarUsuarioUseCase;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                _cadastrarUsuarioUseCase.Execute(usuarioDto);

                return Ok();
            }
            catch (ArgumentException e)
            {

                return BadRequest(new { e.Message });
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }
    }
}
