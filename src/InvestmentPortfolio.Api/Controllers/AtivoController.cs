using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly CadastrarAtivoUseCase _cadastrarAtivoUseCase;

        public AtivoController(CadastrarAtivoUseCase cadastrarAtivoUseCase)
        {
            _cadastrarAtivoUseCase = cadastrarAtivoUseCase;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] AtivoDto ativoDto)
        {
            try
            {
                _cadastrarAtivoUseCase.Execute(ativoDto);

                return Ok();
            }
            catch (ArgumentException e)
            {

                return BadRequest( new { e.Message } );
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
