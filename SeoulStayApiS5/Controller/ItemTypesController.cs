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
    public class ItemTypesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public ItemTypesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/ItemTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetItemTypes()
        {
            return await _context.ItemTypes.ToListAsync();
        }

        // GET: api/ItemTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemType>> GetItemType(long id)
        {
            var itemType = await _context.ItemTypes.FindAsync(id);

            if (itemType == null)
            {
                return NotFound();
            }

            return itemType;
        }

        // PUT: api/ItemTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemType(long id, ItemType itemType)
        {
            if (id != itemType.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTypeExists(id))
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

        // POST: api/ItemTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemType>> PostItemType(ItemType itemType)
        {
            _context.ItemTypes.Add(itemType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemType", new { id = itemType.Id }, itemType);
        }

        // DELETE: api/ItemTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemType(long id)
        {
            var itemType = await _context.ItemTypes.FindAsync(id);
            if (itemType == null)
            {
                return NotFound();
            }

            _context.ItemTypes.Remove(itemType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemTypeExists(long id)
        {
            return _context.ItemTypes.Any(e => e.Id == id);
        }
    }
}
