using Api_navarro.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Api_navarro.Domain.Interfaces;
using Api_navarro.Domain.Entities;
using System.ComponentModel;
using System.Globalization;

namespace Api_navarro.Infrastructure.Repositories
{
    public class Cursorepository: ICursosRepository 
    {
        private readonly Datacontext _context;

        public Cursorepository(Datacontext context) 
        {
            _context = context;
        }

        public async Task<Curso> GetbyIdAsync(int Id) 
        {
            return await _context.Cursos.FirstOrDefaultAsync(u => u.Id == Id);
        }
        public async Task<List<Curso?>> GetbyNameAsync(string name) 
        {
            return await _context.Cursos.Where(u => u.Name == name).ToListAsync();
        }
        public async Task<Curso> getbyDescriptionAsync(String description) 
        {
            return await _context.Cursos.FirstOrDefaultAsync(u => u.Description == description);
        }
        public async Task<Curso?> GetbyTypeAsync(string type) 
        {
            return await _context.Cursos.FirstOrDefaultAsync(u => u.Type == type);
        }
        public async Task<Curso?> GetbyPrecoAsync(decimal preco) 
        {
            return await _context.Cursos.FirstOrDefaultAsync(u => u.Preco == preco);
        }
        public async Task<Curso?> GetbyIscompletAsync(bool iscomplet) 
        {
            return await _context.Cursos.FirstOrDefaultAsync(u => u.IsComplete == iscomplet)
        }
        public async Task AddAsync(Curso curso) 
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }
    }
}
