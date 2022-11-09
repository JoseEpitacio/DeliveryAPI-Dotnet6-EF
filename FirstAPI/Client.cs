using System.Text.Json.Serialization;

namespace FirstAPI
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        [JsonIgnore]
        public List<Address> ClientAddresses { get; set; }
        [JsonIgnore]
        public List<Contact> ClientContacts { get; set; }
        [JsonIgnore]
        public List<Order> ClientOrders { get; set; }
    }
}
