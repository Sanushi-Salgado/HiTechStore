using HiTechStore.Data.Repository.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using HiTechStore.Domain.Handlers.QueryHandlers;

namespace HiTechStore.Service.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{v:apiVersion}/products/types")] // Using URL versioning
    [Route("api/products/types")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMediator _mediator;

        public ProductTypeController(IProductRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all product types
        /// </summary>
        /// <remarks>
        ///  Get the details of all product types
        /// </remarks>
        /// <returns>A list of product types</returns> 
        // GET: api/products/types
        [HttpGet]
        public async Task<IActionResult> GetAllProductTypes()
        {
            try
            {
                var result = await _mediator.Send(new GetAllProductTypesQuery());
                if (result != null)
                    return Ok(new { success = true, message = "Product types retreived successfully!", products_list = result });
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while retrieving product type!", exception = ex });
            }
        }

    }
}
