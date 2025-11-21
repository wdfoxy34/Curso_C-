namespace Api_navarro.models
{
    public class Turma
    {
        public int Id { get; set; }
        public Curso Curso { get; set; }
        public Admin Ministrante { get; set; }
        public ICollection<Client> Alunos { get; } = new List<Client>();

    }
}
