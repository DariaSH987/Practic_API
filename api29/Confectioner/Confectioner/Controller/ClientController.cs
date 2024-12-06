using Confectioner.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;

namespace Confectioner.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly Prd2Context _context;
        public ClientController(Prd2Context context)
        {
            _context = context;
        }

        // GET: api/client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

		// GET: api/client/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Client>> GetById(int id)
		{
			var product = await _context.Clients.FindAsync(id);
			if (product is null)
				return NotFound();

			return product;
		}


		// POST: api/clients
		[HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = client.IdClient }, client);
        }
		// PUT: api/clients/5
		// The method below will handle the PUT requests
		[HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.IdClient)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Clients.Any(e => e.IdClient == id);
        }
		// DELETE: api/clients/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
