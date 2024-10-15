using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeoulStayApiS5.Modelss;

namespace SeoulStayApiS5.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAmenitiesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public ItemAmenitiesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/ItemAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemAmenity>>> GetItemAmenities()
        {
            return await _context.ItemAmenities.ToListAsync();
        }

        // GET: api/ItemAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemAmenity>> GetItemAmenity(long id)
        {
            var itemAmenity = await _context.ItemAmenities.FindAsync(id);

            if (itemAmenity == null)
            {
                return NotFound();
            }

            return itemAmenity;
        }

        // PUT: api/ItemAmenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemAmenity(long id, ItemAmenity itemAmenity)
        {
            if (id != itemAmenity.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemAmenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemAmenityExists(id))
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

        // POST: api/ItemAmenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemAmenity>> PostItemAmenity(ItemAmenity itemAmenity)
        {
            _context.ItemAmenities.Add(itemAmenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemAmenity", new { id = itemAmenity.Id }, itemAmenity);
        }

        // DELETE: api/ItemAmenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAmenity(long id)
        {
            var itemAmenity = await _context.ItemAmenities.FindAsync(id);
            if (itemAmenity == null)
            {
                return NotFound();
            }

            _context.ItemAmenities.Remove(itemAmenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemAmenityExists(long id)
        {
            return _context.ItemAmenities.Any(e => e.Id == id);
        }
    }
}
