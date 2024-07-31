using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases.AtivoUseCases;
using InvestmentPortfolio.Application.UseCases.PortfolioUseCases;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly CadastrarPortfolioUseCase _cadastrarPortfolioUseCase;

        public PortfolioController(CadastrarPortfolioUseCase cadastrarPortfolioUseCase)
        {
            _cadastrarPortfolioUseCase = cadastrarPortfolioUseCase;
        }

        [HttpPost]
        public IActionResult Adicionar(PortfolioDto portfolioDto)
        {
            try
            {                
                return Ok(_cadastrarPortfolioUseCase.Execute(portfolioDto));
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
        public async Task<IActionResult> ObterPorId(Guid id, [FromServices] ObterPortfolioPorIdUseCase obterPortfolioPorIdUseCase)
        {
            try
            {
                var portfolio = await obterPortfolioPorIdUseCase.Execute(id);
                if (portfolio is null) return NotFound();

                return Ok(new { portfolio });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromServices] ObterTodosPortfoliosUseCase obterTodosPortfoliosUseCase)
        {
            try
            {
                var portfolios = await obterTodosPortfoliosUseCase.Execute();
                if (portfolios.Count == 0) return NoContent();

                return Ok(new { portfolios });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] PortfolioDto portfolioDto, [FromServices] AtualizarPortfolioUseCase atualizarPortfolioUseCase)
        {
            try
            {
                await atualizarPortfolioUseCase.Execute(id, portfolioDto);

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
        public async Task<IActionResult> Remover(Guid id, [FromServices] RemoverPortfolioUseCase removerPortfolioUseCase)
        {
            try
            {
                await removerPortfolioUseCase.Execute(id);

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
