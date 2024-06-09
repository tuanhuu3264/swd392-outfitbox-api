using AutoMapper;
using SWD392.OutfitBox.BusinessLayer.Models.Requests.Customer;
using SWD392.OutfitBox.BusinessLayer.Models.Responses.Customer;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<CustomerDTO> ActiveAndDeactiveCustomer(int id)
        {
            var condition = await _customerRepository.GetCustomerById(id);
            if (condition == null) throw new Exception("Not found customer has id: "+id);
            var result = await _customerRepository.ActiveOrDeActive(id);
            return _mapper.Map<CustomerDTO>(result);
        }

        public async Task<CreateCustomerResponseDTO> CreateCustomer(CreateCustomerRequestDTO customer)
        {
            var mappingCustomer = _mapper.Map<Customer>(customer);
           /* if(await IsDuplicatedEmailNormal(customer.Email))
            {
                throw new Exception("Email is duplicated.");
            }
            if(await IsDuplicatedPhoneNormal(customer.Phone))
            {
                throw new Exception("Phone is duplicated.");
            }*/

            var result = await _customerRepository.Create(mappingCustomer);
            return _mapper.Map<CreateCustomerResponseDTO>(result);
        }

        public async Task<List<CustomerDTO>> GetAllCustomers()
        {
            var result = (await _customerRepository.GetAllCustomers()).Select(x=>_mapper.Map<CustomerDTO>(x)).ToList();
            return result;
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var result = _mapper.Map<CustomerDTO>(await _customerRepository.GetCustomerById(id));
            return result;
        }

        public async Task<UpdateCustomerResponseDTO> UpdateCustomer(UpdateCustomerRequestDTO user)
        {
            if (await IsDuplicatedEmailUpdateMode(user.Email, user.Id))
            {
                throw new Exception("Email is existed.");
            }
            if (await IsDuplicatedEmailUpdateMode(user.Phone, user.Id))
            {
                throw new Exception("Phone is existed.");
            }
            var mappingCustomer = _mapper.Map<Customer>(user);
            var result = await _customerRepository.UpdateCustomer(mappingCustomer);

            return _mapper.Map<UpdateCustomerResponseDTO>(result);
        }

        public async Task<bool> IsDuplicatedEmailNormal(string email)
        {
            var duplicatedEmail = await _customerRepository.GetCustomerByPhoneOrEmail(email);
            if (duplicatedEmail == null) return false;
            return true;
        }
        public async Task<bool> IsDuplicatedPhoneNormal(string phone)
        {
            var duplicatedPhone = await _customerRepository.GetCustomerByPhoneOrEmail(phone);
            if (duplicatedPhone == null) return false;
            return true;
        }
        public async Task<bool> IsDuplicatedEmailUpdateMode(string email, int id)
        {
            var duplicatedEmail = await _customerRepository.GetCustomerByPhoneOrEmail(email);
            if (duplicatedEmail == null) return false;
            if (duplicatedEmail.Id == id) return false;
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
