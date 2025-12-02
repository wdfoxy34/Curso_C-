using System.Text.Json;
using Api_navarro.Domain.Entities;
using Api_navarro.Domain.Interfaces;
using Api_navarro.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api_navarro.API.Controllers
{
    [ApiController]
    [Route("api/curso")]
    public class CursoController: ControllerBase
    {
        private readonly CursoUsecase _usecase;

        public CursoController(CursoUsecase usecase)
        {
            _usecase = usecase;
        }

        [HttpGet("buscar/")]
        public async Task<IActionResult> Get(string tipo, string valor, string? filtro)
        {
            try
            {
                var result = await _usecase.BuscarAsync(tipo, valor, filtro);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cadastrar/")]
        public async Task<IActionResult> Cadastrar([FromBody] JsonElement data)
        {
            try
            {
                string name = data.GetProperty("name").GetString();
                string descricao = data.GetProperty("descricao").GetString();
                string tipo = data.GetProperty("tipo").GetString();
                decimal valor = Convert.ToDecimal(data.GetProperty("valor").GetString());
                var result = await _usecase.AddAsync(name, descricao, tipo, valor);

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            };
        }
    }
}
