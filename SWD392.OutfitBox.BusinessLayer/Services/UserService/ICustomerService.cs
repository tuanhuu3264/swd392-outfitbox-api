
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.BusinessLayer.Services.UserService
{
    public interface ICustomerService
    {
       public Task<List<CustomerModel>> GetAllCustomers();   
       
       public Task<CustomerModel> GetCustomerById(int id);
       
       public Task<CustomerModel> CreateCustomer(CustomerModel user);

       public Task<CustomerModel> UpdateCustomer(CustomerModel user);
       
       public Task<CustomerModel> ActiveAndDeactiveCustomer(int id);
    }
}
