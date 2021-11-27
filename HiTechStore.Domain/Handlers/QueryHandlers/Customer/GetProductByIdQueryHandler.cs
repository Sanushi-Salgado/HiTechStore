//using System.Threading;
//using System.Threading.Tasks;
//using HiTechStore.Data.Models.ResponseModels.Customer;
//using HiTechStore.Data.Repository.Abstractions;
//using MediatR;

//namespace HiTechStore.Domain.Handlers.QueryHandlers
//{
//    public class GetContactDetailsByCustomerIdQuery : IRequest<ContactDetailsResponse>
//    {
//        public int CustomerId { get; set; }
//        public class GetContactDetailsByCustomerIdQueryHandler : IRequestHandler<GetContactDetailsByCustomerIdQuery, ContactDetailsResponse>
//        {
//            private readonly ICustomerRepository _repository;
//            public GetContactDetailsByCustomerIdQueryHandler(ICustomerRepository repository)
//            {
//                this._repository = repository;
//            }

//            public async Task<ContactDetailsResponse> Handle(GetContactDetailsByCustomerIdQuery query, CancellationToken cancellationToken)
//            {
//                return await _repository.GetContactDetailsByCustomerId(query.CustomerId);
//            }
//        }
//    }
//}