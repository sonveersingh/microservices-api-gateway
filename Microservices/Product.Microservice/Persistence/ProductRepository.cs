namespace Product.Microservice.Persistence
{
    using Product.Microservice.Model;
    using System.Text.Json;

    public class ProductRepository : IProductRepository
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public ProductRepository(IWebHostEnvironment env)
        {
            _filePath = Path.Combine(env.ContentRootPath, "Data", "Products.json");
        }

        private async Task<List<ProductEntity>> LoadProductsAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<ProductEntity>();
            }

            await _semaphore.WaitAsync();
            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                return JsonSerializer.Deserialize<List<ProductEntity>>(json) ?? new List<ProductEntity>();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task SaveProductsAsync(List<ProductEntity> products)
        {
            await _semaphore.WaitAsync();
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(products, options);
                await File.WriteAllTextAsync(_filePath, json);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = await LoadProductsAsync();
            return products;
        }

        public async Task<ProductEntity?> GetByIdAsync(int id)
        {
            var products = await LoadProductsAsync();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<ProductEntity> CreateAsync(ProductEntity product)
        {
            var products = await LoadProductsAsync();
            product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            await SaveProductsAsync(products);
            return product;
        }
    }

}
