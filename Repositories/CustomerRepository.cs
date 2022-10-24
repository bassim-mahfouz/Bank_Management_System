using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank_Management_System.Data;
using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Management_System.Repositories
{
    public class CustomerRepository 
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerAsync(int id,string firstName, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(a => a.FirstName == firstName && a.Id==id && a.Password == password);
        }


        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(a => a.Id==id);
        }
  
  
        public async Task<int> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return  customer.Id;
        }


        public async Task<bool> UpdateCustemer(Customer customer)
        {
            _context.Attach(customer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }


    }
}
