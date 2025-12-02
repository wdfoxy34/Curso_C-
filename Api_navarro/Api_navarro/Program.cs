using Microsoft.EntityFrameworkCore;
using Api_navarro.Infrastructure.Persistance;
using Api_navarro.Infrastructure.Repositories;
using Api_navarro.Domain.Interfaces;
using Api_navarro.UseCases;

namespace Api_navarro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<AdminUsecase>();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ClientUsecase>();
            
            builder.Services.AddScoped<ICursoRepository, CursoRepository>();
            builder.Services.AddScoped<CursoUsecase>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<Datacontext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                u => u.MigrationsAssembly("Api_navarro")
                     .MigrationsHistoryTable("__EFMigrationsHistory", "Infrastructure")
                     )
                );

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
