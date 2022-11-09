namespace FirstAPI
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public List<Address> ClientAddresses { get; set; }
        public List<Contact> ClientContacts { get; set; }
        public List<Order> ClientOrders { get; set; }
    }
}
