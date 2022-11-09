using System.Text.Json.Serialization;

namespace FirstAPI
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
    }
}
