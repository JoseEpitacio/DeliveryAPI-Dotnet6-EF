using System.Text.Json.Serialization;

namespace FirstAPI
{
    public class Address
    {
        public Guid Id { get; set; }
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        [JsonIgnore]
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        
        
    }
}

