using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases;
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
    }
}
