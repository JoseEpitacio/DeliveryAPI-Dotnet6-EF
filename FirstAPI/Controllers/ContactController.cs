using FirstAPI.DTOs.Address;
using FirstAPI.DTOs.Contact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return Ok(await _context.Contact.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(Guid id)
        {
            var contact = await _context.Contact.Where(c => c.Id == id).ToListAsync();
            if (contact == null)
                return NotFound("Contato inexistente");

            return Ok(contact);

        }
        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(AddContactDto newContact)
        {
            var contact = new Contact
            {
                CellNumber = newContact.CellNumber,
                Email = newContact.Email,
                ClientId = newContact.ClientId
            };
            _context.Contact.Add(contact); ;
            await _context.SaveChangesAsync();

            return Ok(await _context.Contact.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Contact>>> UpdateContact(UpdateContactDto request)
        {
            var dbContact = await _context.Contact.FindAsync(request.Id);
            if (dbContact == null)
                return BadRequest("Error. Contact not found.");

            dbContact.CellNumber = request.CellNumber;
            dbContact.Email = request.Email;
            dbContact.ClientId = request.ClientId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Contact.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> Delete(Guid id)
        {
            var dbContact = await _context.Contact.FindAsync(id);
            if (dbContact == null)
                return BadRequest("Error. Client not found.");

            _context.Contact.Remove(dbContact);
            await _context.SaveChangesAsync();

            return Ok(await _context.Contact.ToListAsync());
        }
    }
}
