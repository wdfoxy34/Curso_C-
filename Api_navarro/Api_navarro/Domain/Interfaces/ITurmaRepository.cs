using Api_navarro.Domain.Entities;
namespace Api_navarro.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma?> GetbyIdAsync(int id);

    }

}
