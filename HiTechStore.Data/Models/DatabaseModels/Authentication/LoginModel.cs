using System.ComponentModel.DataAnnotations;

namespace HiTechStore.Data.Models.DatabaseModels.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
