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


        public virtual string EmailBase(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                throw new ArgumentException("Email inválido.");
            }
            return $"Email do usuário: {email}";
        }


        public virtual int CPFBase(int cpf)
        {
            if (cpf <= 0)
            {
                throw new ArgumentException("CPF inválido.");
            }
            if (cpf > 9)
            {
                throw new ArgumentException("CPF deve ter no máximo 11 dígitos.");
            }
            return cpf;
        }


        public virtual double NumeroBase(double numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("Número inválido.");
            }
            if (numero > 9)
            {
                throw new ArgumentException("Número deve ter no máximo 9 dígitos.");
            }
            return numero;
        }

        public virtual string SenhaBase(string senha)
        {
            if (string.IsNullOrEmpty(senha) || senha.Length < 6)
            {
                throw new ArgumentException("Senha inválida. Deve ter pelo menos 6 caracteres.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(senha, @"[A-Z]"))
            {
                throw new ArgumentException("Senha deve conter pelo menos uma letra maiúscula.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(senha, @"[a-z]"))
            {
                throw new ArgumentException("Senha deve conter pelo menos uma letra minúscula.");
            }
            return $"Senha do usuário: {senha}";
        }
    }
}
