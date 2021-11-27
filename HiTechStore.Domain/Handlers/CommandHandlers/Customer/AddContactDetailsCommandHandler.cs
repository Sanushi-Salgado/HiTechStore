using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.RequestModels;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HiTechStore.Domain.Handlers.CommandHandlers
{
    public class AddCustomerContactDetailsCommand : IRequest
    {
        public AddContactDetailsModel Model { get; set; }

        public AddCustomerContactDetailsCommand(AddContactDetailsModel model)
        {
            this.Model = model;
        }

        public class AddCustomerContactDetailsCommandHandler : IRequestHandler<AddCustomerContactDetailsCommand>
        {
            private readonly ICustomerRepository _repository;
            public AddCustomerContactDetailsCommandHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }
            public async Task<Unit> Handle(AddCustomerContactDetailsCommand command, CancellationToken cancellationToken)
            {
                CustomerContactDetail contactDetails = new CustomerContactDetail();
                contactDetails.customer_id = command.Model.CustomerId;
                contactDetails.country_code = command.Model.CountryCode;
                contactDetails.contact_no = command.Model.ContactNo;
                contactDetails.address = command.Model.Address;
                contactDetails.city = command.Model.City;
                contactDetails.postal_code = command.Model.PostalCode;
                contactDetails.state = command.Model.State;
                contactDetails.country = command.Model.Country;

                await _repository.AddCustomerContactDetails(contactDetails);
                return Unit.Value;
            }
        }
    }
}