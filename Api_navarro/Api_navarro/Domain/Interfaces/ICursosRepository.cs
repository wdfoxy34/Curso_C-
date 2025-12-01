using Api_navarro.Domain.Entities;
namespace Api_navarro.Domain.Interfaces
{
    public interface ICursosRepository
    {
        Task<Curso?> GetbyIdAsync(int Id);
        Task<List<Curso?>> GetbyNameAsync(string name);
        Task<Curso?> getbyDescriptionAsync(string description);
        Task<Curso?> GetbyTypeAsync(string type);
        Task<Curso?> GetbyPrecoAsync(decimal preco);
        Task<Curso?> GetbyIscompletAsync(bool iscomplet);
        Task AddAsync(Curso curso);

    }
}
