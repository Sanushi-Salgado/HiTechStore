using System.ComponentModel.DataAnnotations;

namespace HiTechStore.Data.Models.RequestModels
{
    public class AddSystemUserModel
    {

        [Required]
        public int UserRoleId { get; set; }

        [Required(ErrorMessage = "Fist name is required", AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required", AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        [RegularExpression(@".{4,8}$")]
        public string Password { get; set; }

    }
}
