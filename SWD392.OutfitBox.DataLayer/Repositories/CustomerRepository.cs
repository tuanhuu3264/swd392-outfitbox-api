﻿
using Microsoft.EntityFrameworkCore;
using SWD392.OutfitBox.DataLayer.RepoInterfaces;
using SWD392.OutfitBox.DataLayer.Databases.Redis;
using SWD392.OutfitBox.DataLayer.Entities;
using SWD392.OutfitBox.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392.OutfitBox.DataLayer.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context) : base(context)
        {
        }

        public async Task<Customer> ActiveOrDeActive(int id)
        {
            var user = await this.Get().FirstAsync(x=> x.Id == id);
            user.Status = Math.Abs(1 - user.Status); 
            return await this.UpdateCustomer(user);
        }

        public async Task<Customer> Create(Customer user)
        {
             await this.AddAsync(user);
             await this.SaveChangesAsync();
            return await this.Get().OrderBy(x => x.Id).LastAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var result=  await this.Get().FirstOrDefaultAsync(x=>x.Id==id);
            if (result == null) return new Customer();
            return result;
        }

        public async Task<Customer> GetCustomerByPhoneOrEmail(string phoneOrEmail)
        {
            var result = await this.Get().FirstOrDefaultAsync(x=>x.Email.ToLower().Equals(phoneOrEmail.ToLower()) || x.Phone.Equals(phoneOrEmail));
            
            return result;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await this.Get().ToListAsync();
        }

        public async Task<Customer> UpdateCustomer(Customer user)
        {   
            var updateCustomer = await this.Get().FirstOrDefaultAsync(x=>x.Id==user.Id);
            if (updateCustomer == null) throw new ArgumentNullException("There is not found customer.");
            updateCustomer.Name = user.Name;
            updateCustomer.Address = user.Address;

            updateCustomer.Status=user.Status;
            updateCustomer.Phone = user.Phone;
            updateCustomer.MoneyInWallet = user.MoneyInWallet;

           await this.Update(updateCustomer);

            return await GetCustomerById(user.Id);
        }
        public async Task<List<AdminData>> GetNewCustomers()
        {
            
            var data = await this.Get().GroupBy(x=>x.Time.Date).OrderBy(x=>x.Key).Select(g => new AdminData
            {
                Date = g.Key,
                Value = g.Count()
            }
                ).ToListAsync();
            return data;
        }
      
    }
}
