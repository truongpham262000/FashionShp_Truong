using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionShop_BE.Entity;
using Microsoft.AspNetCore.Authorization;

namespace FashionShop_BE.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SizeProductsController : ControllerBase
    {
        private readonly FashionShopDbContext _context;

        public SizeProductsController(FashionShopDbContext context)
        {
            _context = context;
        }

        // GET: api/SizeProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeProduct>>> GetSizeProducts()
        {
            return await _context.SizeProducts.ToListAsync();
        }

        // GET: api/SizeProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeProduct>> GetSizeProduct(int id)
        {
            var sizeProduct = await _context.SizeProducts.FindAsync(id);

            if (sizeProduct == null)
            {
                return NotFound();
            }

            return sizeProduct;
        }

        // PUT: api/SizeProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeProduct(int id, SizeProduct sizeProduct)
        {
            if (id != sizeProduct.SizeId)
            {
                return BadRequest();
            }

            _context.Entry(sizeProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeProductExists(id))
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

        // POST: api/SizeProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeProduct>> PostSizeProduct(SizeProduct sizeProduct)
        {
            _context.SizeProducts.Add(sizeProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSizeProduct", new { id = sizeProduct.SizeId }, sizeProduct);
        }

        // DELETE: api/SizeProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeProduct(int id)
        {
            var sizeProduct = await _context.SizeProducts.FindAsync(id);
            if (sizeProduct == null)
            {
                return NotFound();
            }

            _context.SizeProducts.Remove(sizeProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeProductExists(int id)
        {
            return _context.SizeProducts.Any(e => e.SizeId == id);
        }
    }
}
