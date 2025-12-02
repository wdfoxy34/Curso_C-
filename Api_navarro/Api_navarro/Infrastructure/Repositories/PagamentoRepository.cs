using Api_navarro.Domain.Entities;
using Api_navarro.Domain.Interfaces;
using Api_navarro.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_navarro.Infrastructure.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly Datacontext _context;

        public PagamentoRepository(Datacontext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();
        }
        public async Task<Pagamento?> GetbyIdAsync(int id)
        {
            return await _context.Pagamentos.Include(p => p.Curso).Include(p => p.Pagador)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Pagamento?> GetbyPaymentAsync(bool payment)
        {
            return await _context.Pagamentos.Include(p => p.Curso).Include(p => p.Pagador)
                .FirstOrDefaultAsync(p => p.Payment == payment);
        }
    }
}
