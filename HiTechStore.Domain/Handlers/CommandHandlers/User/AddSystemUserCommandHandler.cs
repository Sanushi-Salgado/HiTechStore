using HiTechStore.Common;
using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.RequestModels;
using HiTechStore.Data.Repository.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HiTechStore.Domain.Handlers.CommandHandlers.User
{
    public class AddSystemUserCommand : IRequest
    {
        public AddSystemUserModel Model { get; set; }

        public AddSystemUserCommand(AddSystemUserModel model)
        {
            this.Model = model;
        }

        public class AddSystemUserCommandHandler : IRequestHandler<AddSystemUserCommand>
        {
            private readonly ISystemUserRepository _repository; // Injecting 
            public AddSystemUserCommandHandler(ISystemUserRepository repository)
            {
                this._repository = repository;
            }
            public async Task<Unit> Handle(AddSystemUserCommand command, CancellationToken cancellationToken)
            {
                SystemUser user = new SystemUser();
                //user.user_role_id = command.Model.UserRoleId;
                user.user_role_id = 1;
                user.first_name = command.Model.FirstName;
                user.last_name = command.Model.LastName;
                user.email = command.Model.Email;

                // Encode the password
                user.password = new Utility().CalculateHash(command.Model.Password); ;

                await _repository.AddSystemUser(user);
                return Unit.Value;
            }
        }
    }
}