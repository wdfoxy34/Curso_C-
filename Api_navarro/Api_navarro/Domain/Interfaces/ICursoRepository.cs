using Api_navarro.Domain.Entities;
namespace Api_navarro.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<List<Curso?>> GetByNameAsync(string name);
        Task<Curso?> GetByIdAsync(int id);     
        Task<List<Curso?>> GetByTypeAsync(string type);
        Task<List<Curso?>> GetByPriceAsync(decimal price, string filter);
        Task<List<Curso?>> GetByCompletionAsync(bool status);
        Task AddAsync(Curso curso);
       
    }
}
