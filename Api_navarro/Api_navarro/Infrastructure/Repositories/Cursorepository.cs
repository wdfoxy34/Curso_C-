using Api_navarro.Domain.Entities;
using Api_navarro.Domain.Interfaces;
using Api_navarro.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Api_navarro.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly Datacontext _context;

        public CursoRepository(Datacontext context)
        {
            _context = context;
        }

        public async Task<List<Curso?>> GetByNameAsync(string name)
        {
            List<Curso> result = await _context.Cursos.Where(u => u.Name == name).ToListAsync();
            return result;
        }

        public async Task<Curso?> GetByIdAsync(int id)
        {
            return await _context.Cursos.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Curso?>> GetByTypeAsync(string type)
        {
            return await _context.Cursos.Where(u => u.Type == type).ToListAsync();
        }

        public async Task<List<Curso?>> GetByPriceAsync(decimal price, string filter)
        {
            List<Curso?> listaCursos = [];
            if (filter == "maior")
            {
                listaCursos = await _context.Cursos.Where(u => u.Preco > price).ToListAsync();
            }

            if (filter == "menor")
            {
                listaCursos = await _context.Cursos.Where(u => u.Preco < price).ToListAsync();
            }

            return listaCursos;
        }

        public async Task<List<Curso?>> GetByCompletionAsync(bool status)
        {
            return await _context.Cursos.Where(u => u.IsComplete == status).ToListAsync();
        }

        public async Task AddAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }
    }
}
