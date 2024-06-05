
using SWD392.OutfitBox.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomers(); 
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> Create(Customer user);
        public Task<Customer> UpdateCustomer(Customer user);
        public Task<Customer> ActiveOrDeActive(int id);

        public Task<Customer> GetCustomerByPhoneOrEmail(string phoneOrEmail);

    }
}
