using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.Models
{
    public class Category
    {
        public int CatId { get; set; }
        [Required(ErrorMessage = "The field with name {0} is required")]
        public string CategoryName { get; set; }
    }
}
