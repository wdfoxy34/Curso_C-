using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api_navarro.Domain.Entities;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }

    protected User() { }
    protected User(string name, string email, string cpf, string telefone, string senha)
    {
        Name = name;
        Email = email;
        CPF = cpf;
        Telefone = telefone;
        Senha = senha;
    }
}
