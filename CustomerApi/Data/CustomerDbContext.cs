using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class CustomerDbContext  : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) 
        {

        }
        public DbSet<Customer> customers => Set<Customer>();
    }
}
