using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        [Required(ErrorMessage ="The field with name {0} is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public string DescriptionProduct { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public float Price { get; set; }
        [Url]
        public string Image { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public int CatId { get; set; }
        public Promotion? Promotions { get; set; }
    }
}
