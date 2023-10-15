using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.Models
{
    public class Promotion
    {
        public int IdPromotion { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public DateOnly DateToStart { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public DateOnly DateToEnd { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public decimal TauxPromotion { get; set; } = 0;
    }
}
