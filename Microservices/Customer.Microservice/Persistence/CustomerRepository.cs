using Customer.Microservice.Model;
using System.Text.Json;

namespace Customer.Microservice.Persistence
{
 
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public CustomerRepository(IWebHostEnvironment env)
        {
            
            _filePath = Path.Combine(env.ContentRootPath, "Data", "Customers.json");

        }

        private async Task<List<CustomerEntity>> LoadCustomersAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<CustomerEntity>();
            }

            await _semaphore.WaitAsync();
            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                return JsonSerializer.Deserialize<List<CustomerEntity>>(json) ?? new List<CustomerEntity>();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task SaveCustomersAsync(List<CustomerEntity> customers)
        {
            await _semaphore.WaitAsync();
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(customers, options);
                await File.WriteAllTextAsync(_filePath, json);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            var customers = await LoadCustomersAsync();
            return customers;
        }

        public async Task<CustomerEntity?> GetByIdAsync(int id)
        {
            var customers = await LoadCustomersAsync();
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public async Task<CustomerEntity> CreateAsync(CustomerEntity customer)
        {
            var customers = await LoadCustomersAsync();
            customer.Id = customers.Any() ? customers.Max(c => c.Id) + 1 : 1;
            customers.Add(customer);
            await SaveCustomersAsync(customers);
            return customer;
        }
    }

}
