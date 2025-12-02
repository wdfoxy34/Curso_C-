namespace Api_navarro.Domain.Entities
{
    public class Admin: User
    {
        public Admin() { }
        public Admin(string name, string email, string cpf, string numero, string senha) 
            : base(name, email, cpf, numero, senha)
        {
        }
    }
}
