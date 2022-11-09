using System.Text.Json.Serialization;

namespace FirstAPI.DTOs.Contact
{
    public class AddContactDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public Guid ClientId { get; set; }
    }
}
