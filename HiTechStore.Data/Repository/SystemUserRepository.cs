using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Repository.Abstractions;
using System.Threading.Tasks;

namespace HiTechStore.Data.Repository
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly HiTechStoreContext _context;

        public SystemUserRepository(HiTechStoreContext context)
        {
            this._context = context;
        }

        //public async Task<UserResponse> GetSystemUserByEmail(string email)
        //{
        //    SystemUser customer = await _context.SystemUsers.AsQueryable(x => x.email == email);
        //    if (customer == null) return null;
        //    return new UserResponse
        //    {
        //        FirstName = customer.first_name,
        //        LastName = customer.last_name
        //    };
        //}

        public async Task AddSystemUser(SystemUser user)
        {
            // Add the new customer
            await _context.AddAsync(user);

            // Save DB changes
            _context.SaveChanges();
            //return user;
        }

        public async Task UpdateSystemUser(int userId, SystemUser user)
        {
            SystemUser obj = await _context.SystemUsers.FindAsync(userId);
            if (obj != null)
            {
                // Update the relevant fields
                obj.first_name = user.first_name;
                obj.last_name = user.last_name;
                obj.email = user.email;
                obj.password = user.password;

                // Save DB changes
                _context.SaveChanges();
            }
            //return obj;
        }

    }
}