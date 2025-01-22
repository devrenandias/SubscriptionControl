using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SubscriptionControl.Enums
{
    public enum PlanTypeEnum
    {
        [Display(Name = "Plano Básico")]
        Basico  = 1,

        [Display(Name = "Plano Intermediário")]
        Intermediario = 2,

        [Display(Name = "Plano Premium")]
        Premium = 3
    }

    
}
