using AutoMapper;
using FirstAPI.DTOs.Client;
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
            var client = await _context.Clients.Where(c => c.Id == id).ToListAsync();
            if(client == null)
                return NotFound("Erro. Cliente inexistente");

            return Ok(client);

        }

        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(AddClientDto newClient)
        {
            var client = new Client
            {
                FirstName = newClient.FirstName,
                LastName = newClient.LastName,
                Cpf = newClient.Cpf
            };
            _context.Clients.Add(client); ;
            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Client>>> UpdateClient(UpdateClientDto request)
        {
            var dbClient = await _context.Clients.FindAsync(request.Id);
            if (dbClient == null)
                return BadRequest("Erro. Cliente inexistente.");

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
                return BadRequest("Erro. Cliente inexistente.");

            _context.Clients.Remove(dbClient);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clients.ToListAsync());
        }
    }
}
