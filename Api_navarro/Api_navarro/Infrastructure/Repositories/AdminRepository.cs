using Api_navarro.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Api_navarro.Domain.Interfaces;
using Api_navarro.Domain.Entities;
using System.ComponentModel;

namespace Api_navarro.Infrastructure.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly Datacontext _context;
        public AdminRepository(Datacontext context) 
        {
            _context = context;
        }

        public async Task<List<Admin?>> GetByNameAsync(string name)
        {
            return await _context.Admins.Where(u => u.Name == name).ToListAsync();
        }

        public async Task<Admin?> GetByEmailAsync(string email)
        {
            return await _context.Admins.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<Admin?> GetByCPFAsync(string cpf)
        {
            return await _context.Admins.FirstOrDefaultAsync(u => u.CPF == cpf);
        }

        public async Task<Admin?> GetByTelefoneAsync(string telefone)
        {
            return await _context.Admins.FirstOrDefaultAsync(u => u.Telefone == telefone);
        }

        public async Task AddAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

    }
}
