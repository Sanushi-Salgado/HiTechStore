using System.Threading;
using System.Threading.Tasks;
using HiTechStore.Data.Models.ResponseModels;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;

namespace HiTechStore.Domain.Handlers.QueryHandlers
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int ProductId { get; set; }
        public class GetProductByIdQueryyHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
        {
            private readonly IProductRepository _repository;
            public GetProductByIdQueryyHandler(IProductRepository repository)
            {
                this._repository = repository;
            }

            public async Task<ProductResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetProductById(query.ProductId);
            }
        }
    }
}
