using HiTechStore.Data.Models.RequestModels;
using HiTechStore.Data.Repository.Abstractions;
using HiTechStore.Domain.Handlers.CommandHandlers.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HiTechStore.Service.Controllers.v1.User
{
    [ApiVersion("1.0")]
    //[Route("api/v{v:apiVersion}/users")] // Using URL versioning
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISystemUserRepository _repository;
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger; // Indicate the class name from where the error is coming

        public UserController(ISystemUserRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }


        ///// <summary>
        ///// Get selected customer
        ///// </summary>
        ///// <remarks>
        ///// Get the details of a particular customer using the customer id
        ///// </remarks>
        ///// <param name="id">Refers to the customer id</param>
        ///// <returns>The details of a single customer</returns>
        //// GET: api/customers/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSystemUserById(int id)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(new GetCustomerByIdQuery { CustomerId = id });
        //        if (result != null)
        //            return Ok(new { success = true, message = "Customer retreived successfully!", customer = result });
        //        else
        //            return NotFound(new { success = false, message = "Retreived failed. Customer does not exist!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { success = false, message = "An error occured while retreiving customer!", exception = ex });
        //    }
        //}


        /// <summary>
        /// Add a new user
        /// </summary>
        /// <remarks>
        /// Create a new user with the relevant details
        /// </remarks>
        /// <returns></returns>
        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> AddSystemUser([FromBody] AddSystemUserModel model)
        {
            try
            {
                var result = await _mediator.Send(new AddSystemUserCommand(model));
                return Ok(new { success = true, message = "User added successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while adding user!", exception = ex });
            }
        }



        ///// <summary>
        ///// Update an existing customer
        ///// </summary>
        ///// <remarks>
        ///// Update the details of an existing customer using the customer id
        ///// </remarks>
        ///// <param name="id">Refers to the customer id</param>
        ///// <returns></returns>
        //// PUT: api/customers/1
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateSystemUser([FromRoute] int id, [FromBody] UpdateSystemUserModel model)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(new UpdateSystemUserCommand(id, model));
        //        if (result != null)
        //            return Ok(new { success = true, message = "User updated successfully!", customer = result });
        //        else
        //            return NotFound(new { success = false, message = "Update failed. User does not exist!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { success = false, message = "An error occured while updating user!", exception = ex });
        //    }

        //}

    }
}
