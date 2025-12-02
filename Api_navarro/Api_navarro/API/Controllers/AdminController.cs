using Api_navarro.UseCases;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api_navarro.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminUsecase _usecase;
        public AdminController(AdminUsecase usecase)
        {
            _usecase = usecase;
        }

        [HttpGet("buscar/")]
        public async Task<IActionResult> Get(string tipo, string valor)
        {
            try
            {
                var result = await _usecase.BuscarAsync(tipo, valor);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] JsonElement dados)
        {
            try
            {
                string nome = dados.GetProperty("nome").GetString()!;
                string email = dados.GetProperty("email").GetString()!;
                string cpf = dados.GetProperty("cpf").GetString()!;
                string telefone = dados.GetProperty("telefone").GetString()!;
                string senha = dados.GetProperty("senha").GetString()!;

                var result = await _usecase.AdicionarAsync(
                    nome, email, cpf, telefone, senha
                    );

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
