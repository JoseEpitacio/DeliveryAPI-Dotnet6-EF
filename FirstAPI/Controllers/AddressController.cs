using FirstAPI.DTOs.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DataContext _context;

        public AddressController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Address>>> Get()
        {
            return Ok(await _context.Address.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(Guid id)
        {
            var address = await _context.Address.Where(a => a.Id == id).ToListAsync();
            if (address == null)
                return NotFound("Erro. Endereco inexistente.");

            return Ok(address);

        }
        [HttpPost]
        public async Task<ActionResult<List<Address>>> AddAddress(AddAddressDto newAddress)
        {
            var address = new Address
            {
                District = newAddress.District,
                Street = newAddress.Street,
                Number = newAddress.Number,
                PostalCode = newAddress.PostalCode,
                Complement = newAddress.Complement,
                ClientId = newAddress.ClientId

            };
            _context.Address.Add(address); ;
            await _context.SaveChangesAsync();

            return Ok(await _context.Address.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Address>>> UpdateAddress(UpdateAddressDto request)
        {
            var dbAddress = await _context.Address.FindAsync(request.Id);
            if (dbAddress == null)
                return BadRequest("Erro. Endereco inexistente.");

            dbAddress.District = request.District;
            dbAddress.Street = request.Street;
            dbAddress.Number = request.Number;
            dbAddress.PostalCode = request.PostalCode;
            dbAddress.Complement = request.Complement;
            dbAddress.ClientId = request.ClientId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Address.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Address>>> Delete(Guid id)
        {
            var dbAddress = await _context.Address.FindAsync(id);
            if (dbAddress == null)
                return BadRequest("Erro. Endereco inexistente.");

            _context.Address.Remove(dbAddress);
            await _context.SaveChangesAsync();

            return Ok(await _context.Address.ToListAsync());
        }
    }
}
