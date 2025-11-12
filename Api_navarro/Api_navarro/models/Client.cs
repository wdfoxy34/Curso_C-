namespace Api_navarro.models
{
    public class Client: user
    {
        public Client(string name, string email, int cpf, double numero, string senha) : base(name, email, cpf, numero, senha)
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
