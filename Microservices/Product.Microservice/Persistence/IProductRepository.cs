using Product.Microservice.Model;

namespace Product.Microservice.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<ProductEntity?> GetByIdAsync(int id);
        Task<ProductEntity> CreateAsync(ProductEntity product);
    }

}
