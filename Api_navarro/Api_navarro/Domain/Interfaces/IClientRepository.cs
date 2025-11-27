using Api_navarro.Domain.Entities;
namespace Api_navarro.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client?>> GetByNameAsync(string name);
        Task<Client?> GetByEmailAsync(string email);
        Task<Client?> GetByCPFAsync(string email);
        Task<Client?> GetByTelefoneAsync(string email);
        Task AddAsync(Client user);
    }
}
