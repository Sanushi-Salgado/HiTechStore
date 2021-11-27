using HiTechStore.Data.Models.RequestModels;
using HiTechStore.Data.Repository.Abstractions;
using HiTechStore.Domain.Handlers.CommandHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using HiTechStore.Domain.Handlers.QueryHandlers;

namespace HiTechStore.Service.Controllers.v1.Customer
{
    [ApiVersion("1.0")]
    [Route("api/customers/contact_details")]
    [ApiController]
    public class CustomerContactDetailsController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerContactDetailsController> _logger; // Indicate the class name from where the error is coming

        public CustomerContactDetailsController(ICustomerRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }



        /// <summary>
        /// Get all contact details
        /// </summary>
        /// <remarks>
        /// Get customer contact details
        /// </remarks>
        /// <param name="id">Refers to the user id</param>
        /// <returns>The contact details of a single customer</returns>
        // GET: api/customers/contact_details/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetContactDetailsById(int id)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(new GetContactDetailsByCustomerIdQuery { CustomerId = id });
        //        if (result != null)
        //            return Ok(new { success = true, message = "Contact details retreived successfully!", contact_details = result });
        //        else
        //            return NotFound(new { success = false, message = "Retreived failed. Customer does not exist!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { success = false, message = "An error occured while retreiving contact details!", exception = ex });
        //    }
        //}



        /// <summary>
        /// Add contact details
        /// </summary>
        /// <remarks>
        /// Add contact details of a particular customer
        /// </remarks>
        /// <returns></returns>
        // POST: api/customers/contact_details
        [HttpPost]
        public async Task<IActionResult> AddContactDetails([FromBody] AddContactDetailsModel model)
        {
            try
            {
                var result = await _mediator.Send(new AddCustomerContactDetailsCommand(model));
                return Ok(new { success = true, message = "Contact details added successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while adding contact details!", exception = ex });
            }
        }



        /// <summary>
        /// Update existing contact details
        /// </summary>
        /// <remarks>
        /// Update existing contact details of a particular customer using the user id
        /// </remarks>
        /// <param name="id">Refers to the user id</param>
        /// <returns></returns>
        // PUT: api/customers/contact_details/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactDetails([FromRoute] int id, [FromBody] UpdateContactDetailsModel model)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCustomerContactDetailsCommand(id, model));
                if (result != null)
                    return Ok(new { success = true, message = "Contact details updated successfully!" });
                else
                    return NotFound(new { success = false, message = "Update failed. Customer does not exist!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "An error occured while updating contact details!", exception = ex });
            }
        }

    }
}