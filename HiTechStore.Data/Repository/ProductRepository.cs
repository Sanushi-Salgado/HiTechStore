using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.ResponseModels;
using HiTechStore.Data.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiTechStore.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly HiTechStoreContext _context;

        public ProductRepository(HiTechStoreContext context)
        {
            this._context = context;
        }

        public async Task<List<ProductTypeResponse>> GetAllProductTypes()
        {
            return await _context.ProductTypes.Select(x => new ProductTypeResponse
            {
                ProductTypeId = x.product_type_id,
                Name = x.name
            }).ToListAsync();
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            //return await _context.Customers.ToListAsync();
            return await _context.Products.Select(x => new ProductResponse
            {
                ProductId = x.product_id,
                Name = x.name,
                Sku = x.sku,
                Price = x.price,
                ImageUrl = x.image_url
            }).ToListAsync();
        }

        public async Task<ProductResponse> GetProductById(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            if (product == null) return null;
            return new ProductResponse
            {
                ProductId = product.product_id,
                Name = product.name,
                Sku = product.sku,
                Price = product.price,
                ImageUrl = product.image_url
            };
        }

        public async Task AddProduct(Product product)
        {
            // Add the new product
            await _context.AddAsync(product);

            // Save DB changes
            _context.SaveChanges();
            //return product;
        }

        public async Task UpdateProduct(int productId, Product product)
        {
            Product obj = await _context.Products.FindAsync(productId);
            if (obj != null)
            {
                // Update the relevant fields
                obj.type_id = product.type_id;
                obj.name = product.name;
                obj.sku = product.sku;
                obj.price = product.price;
                obj.image_url = product.image_url;

                // Save DB changes
                _context.SaveChanges();
            }
            //return obj;
        }

        public async Task DeleteProduct(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                // Delete the product from the product table
                _context.Remove(product);

                // Save DB changes
                _context.SaveChanges();
            }
            //return customer;
        }

    }
}