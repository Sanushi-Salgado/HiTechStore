using System;
using System.ComponentModel.DataAnnotations;

namespace HiTechStore.Data.Models.RequestModels
{
    public class AddProductModel
    {
        [Required(ErrorMessage = "Product category is required", AllowEmptyStrings = false)]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Product name is required", AllowEmptyStrings = false)]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Sku { get; set; }

        [Required(ErrorMessage = "Unit price is required", AllowEmptyStrings = false)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
