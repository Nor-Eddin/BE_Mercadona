using BE_Mercadona.Models;
using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.DTOs
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string DescriptionProduct { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public Category Cat { get; set; }
        public Promotion? Promotions { get; set; }
    }
}
