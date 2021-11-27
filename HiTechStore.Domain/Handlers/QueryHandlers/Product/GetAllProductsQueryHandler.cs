using HiTechStore.Data.Models.ResponseModels;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HiTechStore.Domain.Handlers.QueryHandlers
{
    public class GetAllProductsQuery : IRequest<List<ProductResponse>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
        {
            private readonly IProductRepository _repository;
            public GetAllProductsQueryHandler(IProductRepository repository)
            {
                this._repository = repository;
            }

            public async Task<List<ProductResponse>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAllProducts();
            }
        }
    }
}