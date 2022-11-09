using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {
            return Ok(await _context.Clients.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(Guid id)
        {
            var newClient = await _context.Clients.FindAsync(id);
            if (newClient == null)
                return BadRequest("Error. Client not found.");
            return Ok(newClient);
        }

        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(Client newClient)
        {
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Client>>> UpdateClient(Client request)
        {
            var dbClient = await _context.Clients.FindAsync(request.Id);
            if (dbClient == null)
                return BadRequest("Error. Client not found.");

            dbClient.FirstName = request.FirstName;
            dbClient.LastName = request.LastName;
            dbClient.Cpf = request.Cpf;

            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Client>>> Delete(Guid id)
        {
            var dbClient = await _context.Clients.FindAsync(id);
            if (dbClient == null)
                return BadRequest("Error. Client not found.");

            _context.Clients.Remove(dbClient);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());
        }
    }
}
