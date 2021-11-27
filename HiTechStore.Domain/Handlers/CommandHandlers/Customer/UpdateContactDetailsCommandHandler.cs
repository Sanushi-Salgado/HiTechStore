using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;

namespace HiTechStore.Domain.Handlers.CommandHandlers
{
    public class UpdateCustomerContactDetailsCommand : IRequest
    {
        public int CustomerId { get; set; }
        public UpdateContactDetailsModel Model { get; set; }

        public UpdateCustomerContactDetailsCommand(int customerId, UpdateContactDetailsModel model)
        {
            this.CustomerId = customerId;
            this.Model = model;
        }

        public class UpdateCustomerContactDetailsCommandHandler : IRequestHandler<UpdateCustomerContactDetailsCommand>
        {
            private readonly ICustomerRepository _repository;
            public UpdateCustomerContactDetailsCommandHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }
            public async Task<Unit> Handle(UpdateCustomerContactDetailsCommand command, CancellationToken cancellationToken)
            {
                CustomerContactDetail contactDetails = new CustomerContactDetail();
                contactDetails.country_code = command.Model.CountryCode;
                contactDetails.contact_no = command.Model.ContactNo;
                contactDetails.address = command.Model.Address;
                contactDetails.city = command.Model.City;
                contactDetails.postal_code = command.Model.PostalCode;
                contactDetails.state = command.Model.State;
                contactDetails.country = command.Model.Country;

                //await _repository.UpdateCustomerContactDetails(command.CustomerId, contactDetails);
                return Unit.Value;
            }
        }
    }
}