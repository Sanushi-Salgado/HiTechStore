namespace HiTechStore.Data.Models.ResponseModels
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

    }
}
