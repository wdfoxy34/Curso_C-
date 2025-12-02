namespace Api_navarro.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public Curso Curso { get; set; }
        public bool Payment { get; set; }
        public Client Pagador { get; set; }

        // EF Core constructor
        public Pagamento()
        {
        }
        public Pagamento(Curso curso, Client pagador, bool payment)
        {
            Curso = curso?? throw new ArgumentNullException(nameof(curso));
            Pagador = pagador?? throw new ArgumentNullException(nameof(pagador));
            Payment = payment;
        }
    }
}
