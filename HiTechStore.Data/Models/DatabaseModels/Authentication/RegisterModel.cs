using System.ComponentModel.DataAnnotations;

namespace HiTechStore.Data.Models.DatabaseModels.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        public string Password { get; set; }

    }
}
