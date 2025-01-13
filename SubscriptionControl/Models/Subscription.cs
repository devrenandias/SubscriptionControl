namespace SubscriptionControl.Models
{
    public class Subscription
    {
        //IMAGEM (VERIFICANDO A MELHOR FORMA)
        public int Id { get; set; }
        public string ServiceSubscription { get; set; } // Nome do Servico (ex.: Netflix, Spotify).
        public decimal Price { get; set; }
        public string PlanType { get; set; } //Tipo de plano (ex.: Básico, Premium).

        public DateTime StartSubscription { get; set; }
        public DateTime DateExpiration { get; set; }

        public string PaymentMethod { get; set; }


    }
}
