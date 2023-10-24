using System.ComponentModel.DataAnnotations;

namespace BE_Mercadona.DTOs
{
    public class UserCredentials
    {
        #region Properties
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        #endregion
    }
}
