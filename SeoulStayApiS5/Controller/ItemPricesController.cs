using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeoulStayApiS5.Models;

namespace SeoulStayApiS5.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPricesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public ItemPricesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/ItemPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPrice>>> GetItemPrices()
        {
            return await _context.ItemPrices.ToListAsync();
        }

        // GET: api/ItemPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPrice>> GetItemPrice(long id)
        {
            var itemPrice = await _context.ItemPrices.FindAsync(id);

            if (itemPrice == null)
            {
                return NotFound();
            }

            return itemPrice;
        }

        // PUT: api/ItemPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPrice(long id, ItemPrice itemPrice)
        {
            if (id != itemPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPriceExists(id))
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

        // POST: api/ItemPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPrice>> PostItemPrice(ItemPrice itemPrice)
        {
            _context.ItemPrices.Add(itemPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPrice", new { id = itemPrice.Id }, itemPrice);
        }

        // DELETE: api/ItemPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPrice(long id)
        {
            var itemPrice = await _context.ItemPrices.FindAsync(id);
            if (itemPrice == null)
            {
                return NotFound();
            }

            _context.ItemPrices.Remove(itemPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPriceExists(long id)
        {
            return _context.ItemPrices.Any(e => e.Id == id);
        }
    }
}
