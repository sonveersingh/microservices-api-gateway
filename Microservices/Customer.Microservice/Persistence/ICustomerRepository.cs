using Customer.Microservice.Model;

namespace Customer.Microservice.Persistence
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerEntity>> GetAllAsync();
        Task<CustomerEntity?> GetByIdAsync(int id);
        Task<CustomerEntity> CreateAsync(CustomerEntity customer);
    }

}
