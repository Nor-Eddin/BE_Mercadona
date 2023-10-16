using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.DTOs
{
    public class PromotionDTO
    {
        public int IdPromotion { get; set; }
        public DateOnly DateToStart { get; set; }
        public DateOnly DateToEnd { get; set; }
        public decimal TauxPromotion { get; set; } = 0;
    }
}
