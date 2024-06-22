
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases.UsuarioUseCases;
using InvestmentPortfolio.Application.UseCases;
using InvestmentPortfolio.Application.UseCases.UsuarioUseCases;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CadastrarUsuarioUseCase _cadastrarUsuarioUseCase;

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] UsuarioDto ativoDto, [FromServices] CadastrarUsuarioUseCase cadastrarUsuarioUseCase)
        {
            try
            {
                await cadastrarUsuarioUseCase.Execute(ativoDto);

                return Created(string.Empty, null);
            }
            catch (ArgumentException e)
            {

                return BadRequest(new { e.Message });
            }
            catch
            {

                return StatusCode(500, new { ErrorMessage = "Internal Server Error." });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id, [FromServices] ObterUsuarioPorIdUseCase obterUsuarioPorIdUseCase)
        {
            try
            {
                var ativo = await obterUsuarioPorIdUseCase.Execute(id);
                if (ativo is null) return NotFound();

                return Ok(new { ativo });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromServices] ObterTodosUsuariosUseCase obterTodosUsuariosUseCase)
        {
            try
            {
                var ativos = await obterTodosUsuariosUseCase.Execute();
                if (ativos.Count == 0) return NoContent();

                return Ok(new { ativos });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UsuarioDto ativoDto, [FromServices] AtualizarUsuarioUseCase atualizarUsuarioUseCase)
        {
            try
            {
                await atualizarUsuarioUseCase.Execute(id, ativoDto);

                return NoContent();
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { e.Message });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remover(Guid id, [FromServices] RemoverUsuarioUseCase removerUsuarioUseCase)
        {
            try
            {
                await removerUsuarioUseCase.Execute(id);

                return NoContent();
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { e.Message });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }
    }
}
