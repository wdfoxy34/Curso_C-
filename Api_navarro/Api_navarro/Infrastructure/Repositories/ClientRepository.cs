using Api_navarro.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Api_navarro.Domain.Interfaces;
using Api_navarro.Domain.Entities;
using System.ComponentModel;

namespace Api_navarro.Infrastructure.Repositories
{
    public class ClientRepository: IClientRepository
    {
        private readonly Datacontext _context;

        public ClientRepository(Datacontext context) 
        {
            _context = context;
        }

        public async Task<List<Client>> GetByNameAsync(string name)
        {
            return await _context.Clients.Where(u => u.Name == name).ToListAsync();
        }

        public async Task<Client?> GetByEmailAsync(string email)
        {
            return await _context.Clients.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Client?> GetByCPFAsync(string cpf)
        {
            return await _context.Clients.FirstOrDefaultAsync(u => u.CPF == cpf);
        }

        public async Task<Client?> GetByTelefoneAsync(string telefone)
        {
            return await _context.Clients.FirstOrDefaultAsync(u => u.Telefone == telefone);
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }
    }
}
