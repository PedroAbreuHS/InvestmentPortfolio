using InvestmentPortfolio.Application.DTOs;
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
                _cadastrarPortfolioUseCase.Execute(portfolioDto);

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
