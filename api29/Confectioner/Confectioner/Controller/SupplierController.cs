using Confectioner.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Confectioner.Controller
{
    [Route("api/[controller]")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly Prd2Context _context;
		public SupplierController(Prd2Context context)
		{
			_context = context;
		}
		// GET: api/supplier
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
		{
			return await _context.Suppliers.ToListAsync();
		}

		// GET: api/supplier/{id}/{Phone}
		[HttpGet("{SuppliersName}")]
		public async Task<ActionResult<Supplier>> GetById(int IdSuppliers, string SuppliersName)
		{
			var supplier = await _context.Suppliers.FirstOrDefaultAsync(с => с.IdSuppliers == IdSuppliers && с.SuppliersName == SuppliersName);
			if (supplier is null)
				return NotFound();
			return supplier;
		}
		// POST: api/suppliers
		[HttpPost]
		public async Task<IActionResult> Create(Supplier supplier)
		{
			_context.Suppliers.Add(supplier);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = supplier.IdSuppliers }, supplier);
		}
		// PUT: api/suppliers/5
		// The method below will handle the PUT requests
		[HttpPut("{id}")]
		public async Task<IActionResult> PutClient(int id, Supplier supplier)
		{
			if (id != supplier.IdSuppliers)
			{
				return BadRequest();
			}

			_context.Entry(supplier).State = EntityState.Modified;

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
			return _context.Suppliers.Any(e => e.IdSuppliers == id);
		}
		// DELETE: api/products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSupplier(int id)
		{
			var supplier = await _context.Suppliers.FindAsync(id);
			if (supplier == null)
			{
				return NotFound();
			}

			_context.Suppliers.Remove(supplier);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
