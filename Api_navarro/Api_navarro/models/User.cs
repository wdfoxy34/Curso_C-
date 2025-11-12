using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api_navarro.models
{
    public abstract class user
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public int CPF { get; private set; }
        public double Numero { get; private set; }
        public string Senha { get; private set; }

        protected user(string name, string email, int cpf, double numero, string senha)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            Numero = numero;
            Senha = senha;
        }


        public virtual string NomeBase(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome não pode ser nulo ou vazio.");
            }
            if (nome.Length < 3)
            {
                throw new ArgumentException("Nome deve ter pelo menos 3 caracteres.");
            }
            return $"Nome do usuário: {nome}";
        }
    }
}
