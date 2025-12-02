

namespace Api_navarro.Domain.Entities
{
    public class Client: User
    {
        public Client() { }
        public Client(string name, string email, string cpf, string numero, string senha) 
            : base(name, email, cpf, numero, senha)
        {
        }
    }
}
