using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.RequestModels;
using System.Threading;
using System.Threading.Tasks;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;

namespace HiTechStore.Domain.Handlers.CommandHandlers
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }
        public UpdateProductModel Model { get; set; }

        public UpdateProductCommand(int customerId, UpdateProductModel model)
        {
            this.ProductId = customerId;
            this.Model = model;
        }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
        {
            private readonly IProductRepository _repository;
            public UpdateProductCommandHandler(IProductRepository repository)
            {
                this._repository = repository;
            }
            public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                Product product = new Product();
                product.type_id = command.Model.TypeId;
                product.name = command.Model.Name;
                product.sku = command.Model.Sku;
                product.price = command.Model.Price;
                product.image_url = command.Model.ImageUrl;

                await _repository.UpdateProduct(command.ProductId, product);
                return Unit.Value;
            }
        }
    }
}
