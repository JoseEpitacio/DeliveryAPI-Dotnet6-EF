namespace FirstAPI.DTOs.Contact
{
    public class UpdateContactDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public Guid ClientId { get; set; }
    }
}
