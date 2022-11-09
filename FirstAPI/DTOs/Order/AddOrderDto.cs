using System.Text.Json.Serialization;

namespace FirstAPI.DTOs.Order
{
    public class AddOrderDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string YourOrder { get; set; } = string.Empty;
        public Guid ClientId { get; set; }
    }
}
