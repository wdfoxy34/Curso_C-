namespace Api_navarro.Domain.Entities

{
    public class Curso
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Preco {  get; set; }
        public bool IsComplete { get; set; }
        public Curso(string name, string description, string type, decimal preco)
        {
            Name = name;
            Description = description;
            Type = type;
            Preco = preco;
            IsComplete = true;
        }
    }
}
