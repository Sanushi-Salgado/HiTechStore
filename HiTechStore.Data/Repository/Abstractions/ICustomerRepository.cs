using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.ResponseModels.Customer;
using System.Threading.Tasks;

namespace HiTechStore.Data.Repository.Abstractions
{
    public interface ICustomerRepository
    {
        //Task<ContactDetailsResponse> GetContactDetailsByCustomerId(int customerId);

        Task AddCustomerContactDetails(CustomerContactDetail contactDetails);

        //Task UpdateCustomerContactDetails(int customerId, CustomerContactDetail contactDetails);

        //Task DeleteCustomer(int customerId);
    }
}