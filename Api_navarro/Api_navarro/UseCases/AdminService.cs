using System.Net.Http.Headers;
using Api_navarro.Domain.Entities;
using Api_navarro.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Api_navarro.UseCases
{
    public class AdminUsecase
    {
        private readonly IAdminRepository _repo;
        public AdminUsecase(IAdminRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Admin?>> BuscarAsync(string tipo, string valor)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentException("Nenhum valor recebido");
            Admin? admin;
            switch (tipo.ToLower())
            {
                case "nome":
                    List<Admin?> admins = await _repo.GetByNameAsync(valor);
                    return admins;
                case "cpf":
                    if (valor.Length != 11)
                        throw new ArgumentException("CPF invalido");
                    admin = await _repo.GetByCPFAsync(valor);
                    return admin is null ? new List<Admin?>() : new List<Admin?> { admin };
                case "telefone":
                    admin = await _repo.GetByTelefoneAsync(valor);
                    return admin is null ? new List<Admin?>() : new List<Admin?> { admin };
                case "email":
                    admin = await _repo.GetByEmailAsync(valor);
                    return admin is null ? new List<Admin?>() : new List<Admin?> { admin };
                default:
                    throw new Exception("Tipo de busca invalido");
            }
        }
        public async Task<Admin> AdicionarAsync(
            string nome,
            string email,
            string cpf,
            string telefone,
            string senha
            )
        {
            List<string> parametros = [nome, email, cpf, telefone, senha];
            foreach (string parametro in parametros)
            {
                if (string.IsNullOrEmpty(parametro))
                    throw new ArgumentException("Parametros faltantes");
            } 
            if (!email.Contains("@"))
                throw new ArgumentException("Email invalido");
            if (cpf.Length != 11)
                throw new ArgumentException("CPF invalido");
            if (senha.Length < 6)
                throw new ArgumentException("Senha muito curta");
            
            var emailExistente = await _repo.GetByEmailAsync(email);
            if (emailExistente != null)
                throw new Exception("Já existe um admin com esse email");
            var cpfExistente = await _repo.GetByCPFAsync(cpf);
            if (cpfExistente != null)
                throw new Exception("Já existe um admin com esse CPF");
            
            Admin novoAdmin = new Admin(nome,email,cpf,telefone,senha);
            await _repo.AddAsync(novoAdmin);
            return novoAdmin;
        }   
    }
}