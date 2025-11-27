using Api_navarro.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_navarro.Infrastructure.Persistance;

public class Datacontext : DbContext
{
    public Datacontext(DbContextOptions<Datacontext> options) : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Client> Clients { get; set; }

    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<User> Users { get; set; }

}
