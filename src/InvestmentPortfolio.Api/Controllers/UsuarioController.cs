
using InvestmentPortfolio.Application.DTOs;
using InvestmentPortfolio.Application.UseCases.AtivoUseCases;
using InvestmentPortfolio.Application.UseCases.UsuarioUseCases;
using Microsoft.AspNetCore.Authorization;
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
                return Ok(_cadastrarUsuarioUseCase.Execute(usuarioDto));
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
        public async Task<IActionResult> ObterPorId(Guid id, [FromServices] ObterUsuarioPorIdUseCase obterUsuarioPorIdUseCase)
        {
            try
            {
                var usuario = await obterUsuarioPorIdUseCase.Execute(id);
                if (usuario is null) return NotFound();

                return Ok(new { usuario });
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
                var usuarios = await obterTodosUsuariosUseCase.Execute();
                if (usuarios.Count == 0) return NoContent();

                return Ok(new { usuarios });
            }
            catch
            {
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UsuarioDto usuarioDto, [FromServices] AtualizarUsuarioUseCase atualizarUsuarioUseCase)
        {
            try
            {
                await atualizarUsuarioUseCase.Execute(id, usuarioDto);

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

        [HttpPost("authenticate"), AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] UsuarioRequestAutenticaoDto usuarioDto, [FromServices] AutenticarUsuarioUseCase autenticarUsuarioUseCase)
        {
            try
            {
                return Ok(await autenticarUsuarioUseCase.Execute(usuarioDto));
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
