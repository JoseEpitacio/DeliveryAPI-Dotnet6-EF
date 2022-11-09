using System.Text.Json.Serialization;

namespace FirstAPI.DTOs.Address
{
    public class AddAddressDto
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public Guid ClientId { get; set; }
    }
}
