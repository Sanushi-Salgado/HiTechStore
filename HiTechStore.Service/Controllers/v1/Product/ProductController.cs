using HiTechStore.Data.Models.RequestModels;
using HiTechStore.Data.Repository.Abstractions;
using HiTechStore.Domain.Handlers.CommandHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using HiTechStore.Domain.Handlers.QueryHandlers;
using Microsoft.AspNetCore.Authorization;
using HiTechStore.Common;

namespace HiTechStore.Service.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Route("api/v{v:apiVersion}/products")] // Using URL versioning
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger; // Indicate the class name from where the error is coming

        public ProductController(IProductRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <remarks>
        ///  Get the details of all products
        /// </remarks>
        /// <returns>A list of products</returns> 
        // GET: api/products
        [Authorize(Roles = UserRoles.Admin +"," + UserRoles.User)]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await _mediator.Send(new GetAllProductsQuery());
                if (result != null)
                    return Ok(new { success = true, message = "Products retreived successfully!", products_list = result });
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while retrieving products!", exception = ex });
            }
        }



        /// <summary>
        /// Get a single product
        /// </summary>
        /// <remarks>
        /// Get the details of a particular product using the product id
        /// </remarks>
        /// <param name="id">Refers to the product id</param>
        /// <returns>The details of a single product</returns>
        // GET: api/products/5
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.User)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
                if (result != null)
                    return Ok(new { success = true, message = "Product retreived successfully!", product = result });
                else
                    return NotFound(new { success = false, message = "Retreived failed. Product does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while retreiving product!", exception = ex });
            }
        }



        /// <summary>
        /// Add a new product
        /// </summary>
        /// <remarks>
        /// Create a new product with the relevant details
        /// </remarks>
        /// <returns></returns>
        // POST: api/products
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductModel model)
        {
            try
            {
                var result = await _mediator.Send(new AddProductCommand(model));
                return Ok(new { success = true, message = "Product added successfully!"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while adding product!", exception = ex });
            }
        }



        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <remarks>
        /// Update the details of an existing product using the product id
        /// </remarks>
        /// <param name="id">Refers to the product id</param>
        /// <returns></returns>
        // PUT: api/products/1
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductModel model)
        {
            try
            {
                var result = await _mediator.Send(new UpdateProductCommand(id, model));
                if (result != null)
                    return Ok(new { success = true, message = "Product updated successfully!" });
                else
                    return NotFound(new { success = false, message = "Update failed. Product does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while updating product!", exception = ex });
            }
        }


        /// <summary>
        /// Delete an existing product
        /// </summary>
        /// <remarks>
        /// Delete an existing product using the product id
        /// </remarks>
        /// <param name="id">Refers to the product id</param>
        /// <returns></returns>
        // DELETE: api/products/1
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProductCommand(id));
                if (result != null)
                    return Ok(new { success = true, message = "Product deleted successfully!" });
                else
                    return NotFound(new { success = false, message = "Delete failed. Product does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while deleting product!", exception = ex });
            }
        }

    }
}
