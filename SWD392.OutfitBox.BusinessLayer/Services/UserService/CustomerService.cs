using AutoMapper;

using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SWD392.OutfitBox.BusinessLayer.BusinessModels;

namespace SWD392.OutfitBox.BusinessLayer.Services.UserService
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _customerRepository;
        public IMapper _mapper;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerModel> ActiveAndDeactiveCustomer(int id)
        {
            var condition = await _customerRepository.GetCustomerById(id);
            if (condition == null) throw new Exception("Not found customer has id: "+id);
            var result = await _customerRepository.ActiveOrDeActive(id);
            return _mapper.Map<CustomerModel>(result);
        }

        public async Task<CustomerModel> CreateCustomer(CustomerModel customer)
        {
            var mappingCustomer = _mapper.Map<Customer>(customer);
            if(string.IsNullOrEmpty(customer.Email) && await IsDuplicatedEmailNormal(customer.Email))
            {
                throw new Exception("Email is duplicated.");
            }
            if(string.IsNullOrEmpty(customer.Phone) && await IsDuplicatedPhoneNormal(customer.Phone))
            {
                throw new Exception("Phone is duplicated.");
            }

            var result = await _customerRepository.Create(mappingCustomer);
            return _mapper.Map<CustomerModel>(result);
        }

        public async Task<List<CustomerModel>> GetAllCustomers()
        {
            var result = (await _customerRepository.GetAllCustomers()).Select(x=>_mapper.Map<CustomerModel>(x)).ToList();
            return result;
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var result = _mapper.Map<CustomerModel>(await _customerRepository.GetCustomerById(id));
            return result;
        }

        public async Task<CustomerModel> UpdateCustomer(CustomerModel user)
        {
            if (!user.Id.HasValue) throw new Exception("There is no id in model.");
            if (!string.IsNullOrEmpty(user.Phone) && await IsDuplicatedEmailUpdateMode(user.Phone, user.Id.Value))
            {
                throw new Exception("Phone is existed.");
            }
            var updatedCustomer = await _customerRepository.GetCustomerById(user.Id.Value);
            updatedCustomer = new Customer
            {
                Id = updatedCustomer.Id,
                MoneyInWallet = user.MoneyInWallet.HasValue ? user.MoneyInWallet.Value : updatedCustomer.MoneyInWallet,
                Address = !string.IsNullOrEmpty(user.Address) ? user.Address : updatedCustomer.Address,
                Email = !string.IsNullOrEmpty(user.Email) ? user.Email : updatedCustomer.Email,
                Name = !string.IsNullOrEmpty(user.Name) ? user.Name : updatedCustomer.Name,
                Phone = !string.IsNullOrEmpty(user.Phone) ? user.Phone : updatedCustomer.Phone,
                Picture = !string.IsNullOrEmpty(user.Picture) ? user.Picture : updatedCustomer.Picture,
                Status = user.Status.HasValue ? user.Status.Value : updatedCustomer.Status
            };
           
            var result = await _customerRepository.UpdateCustomer(updatedCustomer);
            return _mapper.Map<CustomerModel>(result);
        }

        public async Task<bool> IsDuplicatedEmailNormal(string email)
        {
            var duplicatedEmail = await _customerRepository.GetCustomerByPhoneOrEmail(email);
            return duplicatedEmail != null;
        }
        public async Task<bool> IsDuplicatedPhoneNormal(string phone)
        {
            var duplicatedPhone = await _customerRepository.GetCustomerByPhoneOrEmail(phone);
            return duplicatedPhone != null;
        }
        public async Task<bool> IsDuplicatedEmailUpdateMode(string email, int id)
        {
            var duplicatedEmail = await _customerRepository.GetCustomerByPhoneOrEmail(email);
            if (duplicatedEmail == null || duplicatedEmail.Id == id) return false;
            return true;
        }
        public async Task<bool> IsDuplicatedPhoneUpdateMode(string phone, int id)
        {
            var duplicatedPhone = await _customerRepository.GetCustomerByPhoneOrEmail(phone);
            if (duplicatedPhone == null) return false;
            if(duplicatedPhone.Id==id) return false;
            return true;
        }
    }
}
