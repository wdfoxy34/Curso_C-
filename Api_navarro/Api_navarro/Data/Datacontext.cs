using Api_navarro.models;
using Microsoft.EntityFrameworkCore;

namespace Api_navarro.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
    }
}
