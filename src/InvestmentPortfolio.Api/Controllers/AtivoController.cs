using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases;
using InvestmentPortfolio.Application.UseCases.AtivoUseCases;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Adicionar([FromBody] AtivoDto ativoDto, [FromServices] CadastrarAtivoUseCase cadastrarAtivoUseCase)
        {
            try
            {
                cadastrarAtivoUseCase.Execute(ativoDto);

                return Created(string.Empty, null);
            }
            catch (ArgumentException e)
            {

                return BadRequest( new { e.Message } );
            }
            catch
            {

                return StatusCode(500, new { ErrorMessage = "Internal Server Error." } );
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id, [FromServices] ObterAtivoPorIdUseCase obterAtivoPorIdUseCase)
        {
            try
            {
                var ativo = await obterAtivoPorIdUseCase.Execute(id);
                if (ativo is null) return NotFound();

                return Ok(new { ativo });
            }
            catch 
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromServices] ObterTodosAtivosUseCase obterTodosAtivosUseCase)
        {
            try
            {
                var ativos = await obterTodosAtivosUseCase.Execute();
                if (ativos.Count == 0) return NoContent();

                return Ok(new { ativos });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtivoDto ativoDto, [FromServices] AtualizarAtivoUseCase atualizarAtivoUseCase)
        {
            try
            {
                await atualizarAtivoUseCase.Execute(id, ativoDto);
                
                return NoContent();
            }
            catch(ArgumentException e)
            {
                return BadRequest( new { e.Message });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remover(Guid id, [FromServices] RemoverAtivoUseCase removerAtivoUseCase)
        {
            try
            {
                await removerAtivoUseCase.Execute(id);

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
