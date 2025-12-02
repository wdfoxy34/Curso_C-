using Api_navarro.Domain.Entities;
using Api_navarro.Domain.Interfaces;
using Azure.Identity;

namespace Api_navarro.UseCases
{
    public class PagamentoUsecase
    {
        private readonly IPagamentoRepository _repo;
        public PagamentoUsecase(IPagamentoRepository repo)
        {
            _repo = repo;
        }
        public async Task<Pagamento> AdicionarPagamentoAsync(
            Curso curso,
            Client pagador,
            bool payment
            )
        {
            if (curso is null)
                throw new ArgumentException("Curso não pode ser Nulo.");

            if (pagador is null)
                throw new ArgumentException("Pagador não pode ser Nulo.");

            Pagamento pagamento = new Pagamento
            {
                Curso = curso,
                Pagador = pagador,
                Payment = payment
            };

            await _repo.AddAsync(pagamento);

            return pagamento;
        }
        public async Task<Pagamento?> BuscarIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            return await _repo.GetbyIdAsync(id);
        }
        public async Task<Pagamento?>BuscarStatusAsync(bool payment)
        {
            return await _repo.GetbyPaymentAsync(payment);
        }
    }
}