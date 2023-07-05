using CustomerApi.Models;

namespace CustomerApi.Repository.Interface
{
    public interface ICustomerSerices
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<bool> CreateCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(int id);

    }
}
