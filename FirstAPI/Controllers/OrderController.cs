using FirstAPI.DTOs.Contact;
using FirstAPI.DTOs.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return Ok(await _context.Order.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            var order = await _context.Order.Where(o => o.Id == id).ToListAsync();
            if (order == null)
                return NotFound("Erro. Contato inexistente");

            return Ok(order);

        }
        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(AddOrderDto newOrder)
        {
            var order = new Order
            {
                YourOrder = newOrder.YourOrder,
                ClientId = newOrder.ClientId
            };
            _context.Order.Add(order); ;
            await _context.SaveChangesAsync();

            return Ok(await _context.Order.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Order>>> UpdateOrder(UpdateOrderDto request)
        {
            var dbOrder = await _context.Order.FindAsync(request.Id);
            if (dbOrder == null)
                return BadRequest("Error. Contact not found.");

            dbOrder.YourOrder = request.YourOrder;
            dbOrder.ClientId = request.ClientId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Order.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Order>>> Delete(Guid id)
        {
            var dbOrder = await _context.Order.FindAsync(id);
            if (dbOrder == null)
                return BadRequest("Error. Client not found.");

            _context.Order.Remove(dbOrder);
            await _context.SaveChangesAsync();

            return Ok(await _context.Order.ToListAsync());
        }
    }
}
