using HiTechStore.Data.Models.DatabaseModels;
using HiTechStore.Data.Models.ResponseModels.Customer;
using HiTechStore.Data.Repository.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace HiTechStore.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HiTechStoreContext _context;

        public CustomerRepository(HiTechStoreContext context)
        {
            this._context = context;
        }
      
        //public async Task<ContactDetailsResponse> GetContactDetailsByCustomerId(int customerId)
        //{
        //    var contactDetails = await _context.CustomerContactDetails.FirstOrDefault(x => x.customer_id == customerId);
        //    if (contactDetails == null) return null;
        //    return new ContactDetailsResponse
        //    {
        //        CountryCode = contactDetails.country_code,
        //        ContactNo = contactDetails.contact_no,
        //        Address = contactDetails.address,
        //        City = contactDetails.city,
        //        PostalCode = contactDetails.postal_code,
        //        State = contactDetails.state,
        //        Country = contactDetails.country
        //    };
        //}

        public async Task AddCustomerContactDetails(CustomerContactDetail contactDetails)
        {
            // Add the new customer
            await _context.AddAsync(contactDetails);

            // Save DB changes
            _context.SaveChanges();
        }

        //public async Task UpdateCustomerContactDetails(int customerId, CustomerContactDetail contactDetails)
        //{
        //    CustomerContactDetail obj = await _context.CustomerContactDetails.Where(x => x.customer_id == customerId);
        //    if (obj != null)
        //    {
        //        // Update the relevant fields
        //        obj.first_name = contactDetails.first_name;
        //        obj.last_name = contactDetails.last_name;
        //        //obj.country_code = customer.country_code;
        //        //obj.contact_no = customer.contact_no;
        //        obj.email = contactDetails.email;
        //        //obj.updated_at = System.DateTime.Now;

        //        // Save DB changes
        //        _context.SaveChanges();
        //    }
        //    //return obj;
        //}

       

    }
}