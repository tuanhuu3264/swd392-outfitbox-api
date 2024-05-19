using SWD392.OutfitBox.Core.Models.Requests.Customer;
using SWD392.OutfitBox.Core.Models.Responses.Customer;
using SWD392.OutfitBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.Core.Services.UserService
{
    public interface ICustomerService
    {
       public Task<List<CustomerDTO>> GetAllCustomers();   
       
       public Task<CustomerDTO> GetCustomerById(int id);
       
       public Task<CreateCustomerResponseDTO> CreateCustomer(CreateCustomerRequestDTO user);

       public Task<UpdateCustomerResponseDTO> UpdateCustomer(UpdateCustomerRequestDTO user);
       
       public Task<CustomerDTO> ActiveAndDeactiveCustomer(int id);
    }
}
