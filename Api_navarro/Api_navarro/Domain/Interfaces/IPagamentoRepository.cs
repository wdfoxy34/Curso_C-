using Api_navarro.Domain.Entities;
namespace Api_navarro.Domain.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<Pagamento?> GetbyIdAsync(int id);
        Task<Pagamento?> GetbyPaymentAsync(bool payment);
        Task AddAsync(Pagamento payment);

    }

}
