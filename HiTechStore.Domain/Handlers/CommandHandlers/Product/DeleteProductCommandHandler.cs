using HiTechStore.Data.Repository.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HiTechStore.Domain.Handlers.CommandHandlers
{
    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }

        public class DeleteCustomersQueryHandler : IRequestHandler<DeleteProductCommand>
        {
            private readonly IProductRepository _repository;
            public DeleteCustomersQueryHandler(IProductRepository repository)
            {
                this._repository = repository;
            }

            public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
            {
                await _repository.DeleteProduct(command.ProductId);
                return Unit.Value;
            }
        }
    }
}