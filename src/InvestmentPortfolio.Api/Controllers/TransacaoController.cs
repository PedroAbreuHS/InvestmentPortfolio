using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases.AtivoUseCases;
using InvestmentPortfolio.Application.UseCases.TransacaoUseCase;
using InvestmentPortfolio.Application.UseCases.TransacaoUseCases;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly CadastrarTransacaoUseCase _cadastrarTransacaoUseCase;

        public TransacaoController(CadastrarTransacaoUseCase cadastrarTransacaoUseCase)
        {
            _cadastrarTransacaoUseCase = cadastrarTransacaoUseCase;
        }

        [HttpPost]
        public IActionResult Adicionar(TransacaoDto transacaoDto)
        {
            try
            {
                _cadastrarTransacaoUseCase.Execute(transacaoDto);

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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id, [FromServices] ObterTransacaoPorId obterTransacaoPorId)
        {
            try
            {
                var transacao = await obterTransacaoPorId.Execute(id);
                if (transacao is null) return NotFound();

                return Ok(new { transacao });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromServices] ObterTodasTransacoesUseCase obterTodasTransacoesUseCase)
        {
            try
            {
                var transacoes = await obterTodasTransacoesUseCase.Execute();
                if (transacoes.Count == 0) return NoContent();

                return Ok(new { transacoes });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] TransacaoDto transacaoDto, [FromServices] AtualizarTransacaoUseCase atualizarTransacaoUseCase)
        {
            try
            {
                await atualizarTransacaoUseCase.Execute(id, transacaoDto);

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
        public async Task<IActionResult> Remover(Guid id, [FromServices] RemoverTransacaoUseCase removerTransacaoUseCase)
        {
            try
            {
                await removerTransacaoUseCase.Execute(id);

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
