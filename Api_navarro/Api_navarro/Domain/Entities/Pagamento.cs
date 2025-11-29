namespace Api_navarro.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public Curso Curso { get; set; }
        public bool Payment { get; set; }
        public Client Pagador { get; set; }
        public Pagamento()
        {
            
        }

    }
}
