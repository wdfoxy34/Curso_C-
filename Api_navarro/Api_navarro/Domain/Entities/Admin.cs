namespace Api_navarro.Domain.Entities
{
    public class Admin: User
    {
        public Admin(string name, string email, string cpf, string numero, string senha) : base(name, email, cpf, numero, senha)
        {
        }

        public override string NomeBase(string nome)
        {
            return base.NomeBase(nome);
        }
        public override string EmailBase(string email)
        {
            return base.EmailBase(email);
        }
        public override string SenhaBase(string senha)
        {
            return base.SenhaBase(senha);
        }
        public override int CPFBase(int cpf)
        {
            return base.CPFBase(cpf);
        }
        public override double NumeroBase(double numero)
        {
            return base.NumeroBase(numero);
        }
    }
}
