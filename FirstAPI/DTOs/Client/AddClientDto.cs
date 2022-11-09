using System.Text.Json.Serialization;

namespace FirstAPI.DTOs.Client
{
    public class AddClientDto
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
    }
}
