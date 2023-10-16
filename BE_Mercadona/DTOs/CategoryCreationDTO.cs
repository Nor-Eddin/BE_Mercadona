using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.DTOs
{
    public class CategoryCreationDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        public string CategoryName { get; set; }
    }
}
