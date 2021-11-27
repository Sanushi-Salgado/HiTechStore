using System.ComponentModel.DataAnnotations;

namespace HiTechStore.Data.Models.RequestModels
{
    public class UpdateContactDetailsModel
    {

        [Required(ErrorMessage = "Country code is required", AllowEmptyStrings = false)]
        [StringLength(6, MinimumLength = 2)]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Contact number is required", AllowEmptyStrings = false)]
        [StringLength(14, MinimumLength = 7)]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Address is required", AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 20)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal code is required", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 3)]
        public string PostalCode { get; set; }

        public string State { get; set; }

        [Required(ErrorMessage = "Country is required", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 3)]
        public string Country { get; set; }

    }
}