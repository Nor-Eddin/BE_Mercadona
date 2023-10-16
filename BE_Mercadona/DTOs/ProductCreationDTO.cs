using BE_Mercadona.Models;
using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.DTOs
{
    public class ProductCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public string DescriptionProduct { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public float Price { get; set; }
        [Url]
        public string Image { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public Category Cat { get; set; }
       
    }
}
