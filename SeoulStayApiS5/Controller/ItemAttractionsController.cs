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
    public class ItemAttractionsController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public ItemAttractionsController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/ItemAttractions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemAttraction>>> GetItemAttractions()
        {
            return await _context.ItemAttractions.ToListAsync();
        }

        // GET: api/ItemAttractions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemAttraction>> GetItemAttraction(long id)
        {
            var itemAttraction = await _context.ItemAttractions.FindAsync(id);

            if (itemAttraction == null)
            {
                return NotFound();
            }

            return itemAttraction;
        }

        // PUT: api/ItemAttractions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemAttraction(long id, ItemAttraction itemAttraction)
        {
            if (id != itemAttraction.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemAttraction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemAttractionExists(id))
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

        // POST: api/ItemAttractions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemAttraction>> PostItemAttraction(ItemAttraction itemAttraction)
        {
            _context.ItemAttractions.Add(itemAttraction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemAttraction", new { id = itemAttraction.Id }, itemAttraction);
        }

        // DELETE: api/ItemAttractions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAttraction(long id)
        {
            var itemAttraction = await _context.ItemAttractions.FindAsync(id);
            if (itemAttraction == null)
            {
                return NotFound();
            }

            _context.ItemAttractions.Remove(itemAttraction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemAttractionExists(long id)
        {
            return _context.ItemAttractions.Any(e => e.Id == id);
        }
    }
}
