using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Business.Entities
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [HiddenInput]
        public string Location { get; set; } = string.Empty;
        [HiddenInput]
        public string Latitude { get; set; } = string.Empty;
        [HiddenInput]
        public string Longitude { get; set; } = string.Empty;
    }
}
