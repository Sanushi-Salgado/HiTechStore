using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiTechStore.Data.Repository.Abstractions
{
    public interface IProductRepository
    {
        Task<List<ProductTypeResponse>> GetAllProductTypes();
        Task<List<ProductResponse>> GetAllProducts();

        Task<ProductResponse> GetProductById(int productId);

        Task AddProduct(Product product);

        Task UpdateProduct(int productId, Product product);

        Task DeleteProduct(int productId);

    }
}
