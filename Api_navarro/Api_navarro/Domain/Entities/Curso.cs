namespace Api_navarro.Domain.models

{
    public class Curso
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Preco {  get; set; }
        public bool IsComplete { get; set; }
        public Curso(int id, string name, string description, string type, decimal preco)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Preco = preco;
            IsComplete = true;
        }
    }

}
