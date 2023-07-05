using CustomerApi.Models;
using CustomerApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerSerices _customerSerices;
        public CustomerController(ICustomerSerices customerSerices)
        {
            _customerSerices = customerSerices;
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            await _customerSerices.CreateCustomer(customer);
            return Ok("Success!!");
        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerSerices.GetCustomers();

            return Ok(customers);
        }
        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerSerices.GetCustomerById(id);
            if (customer == null)
            {
                return BadRequest("customer not found");
            }

            return Ok(customer);
        }
        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {

            await _customerSerices.UpdateCustomer(customer);

            return Ok("Done");
        }
        [HttpPost]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerSerices.GetCustomerById(id);
            if (customer == null)
            {
                return BadRequest("customer not found");
            };
            await _customerSerices.DeleteCustomer(id);

            return Ok("customer deleted!!!");

        }
    }
}
