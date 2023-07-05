using CustomerApi.Data;
using CustomerApi.Models;
using CustomerApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repository
{
    public class CustomerSerices : ICustomerSerices
    {
        private readonly CustomerDbContext _customerDb;
        public CustomerSerices(CustomerDbContext customerDb)
        {
            _customerDb= customerDb;
        }
        public async Task<bool> CreateCustomer(Customer customer)
        {
            var NewCustomer = new Customer
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                CustomerAge = customer.CustomerAge,
                CreatedAt = DateTime.Now,
                Address = customer.Address,
                DelFlag = false,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                UpdatedAt = customer.UpdatedAt

            };
            _customerDb.customers.Add(NewCustomer);
            await _customerDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id).Result;
            if (customer != null)
            {
                customer.DelFlag = true;
                _customerDb.customers.Update(customer);
                await _customerDb.SaveChangesAsync();
            }
            return false;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerDb.customers.Where(c => c.CustomerId == id && c.DelFlag == false).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _customerDb.customers.Where(c => c.DelFlag == false).ToListAsync();
            return customers;

        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var UpdatedCustomer = new Customer
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                CustomerAge = customer.CustomerAge,
                CreatedAt = customer.CreatedAt,
                Address = customer.Address,
                DelFlag = false,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                UpdatedAt = DateTime.Now
            };
            _customerDb.customers.Update(UpdatedCustomer);
            await _customerDb.SaveChangesAsync();
            return true;
        }
    }
}
