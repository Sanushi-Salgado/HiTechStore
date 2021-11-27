using HiTechStore.Data.Models.DatabaseModels;
using System.Threading.Tasks;

namespace HiTechStore.Data.Repository.Abstractions
{
    public interface ISystemUserRepository
    {
        //Task<UserResponse> GetSystemUserByEmaail(string email);

        Task AddSystemUser(SystemUser user);

        Task UpdateSystemUser(int userId, SystemUser user);

    }
}
