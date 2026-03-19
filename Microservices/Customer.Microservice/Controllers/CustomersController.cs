using Customer.Microservice.Model;
using Customer.Microservice.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/customers (list all)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerEntity>>> GetCustomers()
        {
            var customers = await _repository.GetAllAsync();
            return Ok(customers);
        }

        // GET: api/customers/5 (single by ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerEntity>> GetCustomer(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // POST: api/customers (create)
        [HttpPost]
        public async Task<ActionResult<CustomerEntity>> CreateCustomer(CustomerEntity customer)
        {
            var created = await _repository.CreateAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = created.Id }, created);
        }
    }


}
