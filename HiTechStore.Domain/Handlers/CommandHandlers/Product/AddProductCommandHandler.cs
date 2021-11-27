using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.RequestModels;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HiTechStore.Domain.Handlers.CommandHandlers
{
    public class AddProductCommand : IRequest
    {
        public AddProductModel Model { get; set; }

        public AddProductCommand(AddProductModel model)
        {
            this.Model = model;
        }

        public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
        {
            private readonly IProductRepository _repository;
            public AddProductCommandHandler(IProductRepository repository)
            {
                this._repository = repository;
            }
            public async Task<Unit> Handle(AddProductCommand command, CancellationToken cancellationToken)
            {
                Product product = new Product();
                product.type_id = command.Model.TypeId;
                product.name = command.Model.Name;
                product.sku = command.Model.Sku;
                product.price = command.Model.Price;
                product.image_url = command.Model.ImageUrl;
                product.created_at = System.DateTime.Now;

                await _repository.AddProduct(product);
                return Unit.Value;
            }
        }
    }
}