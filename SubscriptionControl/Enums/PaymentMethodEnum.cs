using System.ComponentModel.DataAnnotations;

namespace SubscriptionControl.Enums
{
    public enum PaymentMethodEnum
    {
        [Display(Name = "Cartão de Crédito")]
        CartaoDeCredito = 1,
        Boleto =2,
        Pix = 3,
        PayPal = 4


    }
}
