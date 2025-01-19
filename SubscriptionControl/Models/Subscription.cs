using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SubscriptionControl.Models
{
    public class Subscription
    {
        //IMAGEM (VERIFICANDO A MELHOR FORMA)
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do serviço é obrigatório")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracateres")]
        [Display(Name = "Nome do Serviço")]
        public string ServiceSubscription { get; set; } // Nome do Servico (ex.: Netflix, Spotify).


        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 10000.00, ErrorMessage = "O preço deve estar entre {1} e {2}.")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O tipo do plano é obrigatorio")]
        [Display(Name = "Tipo de Plano")]
        public string PlanType { get; set; } //Tipo de plano (ex.: Básico, Premium).

        [Required(ErrorMessage = "A data de início da assinatura é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida.")]
        [Display(Name = "Data de Início da Assinatura")]
        public DateTime StartSubscription { get; set; }

        [Display(Name = "Data de Expiração")]
        public DateTime DateExpiration { get; set; }

        [Required(ErrorMessage = "O metodo de pagamento é obrigatorio")]
        [Display(Name = "Metodo de Pagamento")]
        public string PaymentMethod { get; set; }


    }
}
