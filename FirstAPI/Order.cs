using System.Text.Json.Serialization;

namespace FirstAPI
{
    public class Order
    {
        public Guid Id { get; set; }
        public string YourOrder { get; set; } = string.Empty;
        [JsonIgnore]
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        
    }
}
