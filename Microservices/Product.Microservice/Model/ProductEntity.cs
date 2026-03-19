using System.Text.Json.Serialization;

namespace Product.Microservice.Model
{
    public class ProductEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName ("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}
