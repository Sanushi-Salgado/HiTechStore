using HiTechStore.Data.Models.ResponseModels;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HiTechStore.Domain.Handlers.QueryHandlers
{
    public class GetAllProductTypesQuery : IRequest<List<ProductTypeResponse>>
    {
        public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, List<ProductTypeResponse>>
        {
            private readonly IProductRepository _repository;
            public GetAllProductTypesQueryHandler(IProductRepository repository)
            {
                this._repository = repository;
            }

            public async Task<List<ProductTypeResponse>> Handle(GetAllProductTypesQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAllProductTypes();
            }
        }
    }
}