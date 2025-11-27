using Api_navarro.Domain.Entities;
namespace Api_navarro.Domain.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Admin?>> GetByNameAsync(string name);
        Task<Admin?> GetByEmailAsync(string email);
        Task<Admin> GetByCPFAsync(string email);
        Task<Admin> GetByTelefoneAsync(string telefone);
        Task AddAsync(Admin admin);
    }
}
