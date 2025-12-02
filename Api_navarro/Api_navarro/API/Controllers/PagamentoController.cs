using Api_navarro.Domain.Entities;
using Api_navarro.Domain.Interfaces;
using Api_navarro.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api_navarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoUsecase _pagamentoUsecase;
        private readonly ICursoRepository _cursoRepo;
        private readonly IClientRepository _clientRepo;
        private readonly IPagamentoRepository _pagamentoRepo;

        public PagamentoController(
            PagamentoUsecase pagamentoUsecase,
            ICursoRepository cursoRepo,
            IClientRepository clientRepo,
            IPagamentoRepository pagamentoRepo)
        {
            _pagamentoUsecase = pagamentoUsecase;
            _cursoRepo = cursoRepo;
            _clientRepo = clientRepo;
            _pagamentoRepo = pagamentoRepo;
        }
        // POST: api/pagamento
        [HttpPost]
        public async Task<IActionResult> CreatePagamento([FromBody] PagamentoDTO dto)
        {
            try
            {
                // Buscar curso
                var curso = await _cursoRepo.GetByIdAsync(dto.CursoId);
                if (curso is null)
                    return NotFound(new { message = "Curso não encontrado" });

                // Buscar client
                var client = await _clientRepo.GetByEmailAsync(dto.ClientEmail);
                if (client is null)
                    return NotFound(new { message = "Cliente não encontrado" });

                // Cria pagamento
                var pagamento = await _pagamentoUsecase.AdicionarPagamentoAsync(
                    curso,
                    client,
                    dto.Payment
                );

                return Ok(pagamento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        // GET: api/pagamento/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagamentoById(int id)
        {
            var pagamento = await _pagamentoRepo.GetbyIdAsync(id);
            if (pagamento is null)
                return NotFound(new { message = "Pagamento não encontrado" });

            return Ok(pagamento);
        }

        // GET: api/pagamento/status/{payment}
        [HttpGet("status/{payment}")]
        public async Task<IActionResult> GetPagamentoByPayment(bool payment)
        {
            var pagamento = await _pagamentoRepo.GetbyPaymentAsync(payment);
            if (pagamento is null)
                return NotFound(new { message = "Nenhum pagamento encontrado com esse status" });

            return Ok(pagamento);
        }
    }

    // DTO usado para criar pagamento
    public class PagamentoDTO
    {
        public int CursoId { get; set; }
        public string ClientEmail { get; set; } = string.Empty;
        public bool Payment { get; set; }
    }
}
