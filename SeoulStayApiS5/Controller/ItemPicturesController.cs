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
    public class ItemPicturesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public ItemPicturesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/ItemPictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPicture>>> GetItemPictures()
        {
            return await _context.ItemPictures.ToListAsync();
        }

        // GET: api/ItemPictures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPicture>> GetItemPicture(long id)
        {
            var itemPicture = await _context.ItemPictures.FindAsync(id);

            if (itemPicture == null)
            {
                return NotFound();
            }

            return itemPicture;
        }

        // PUT: api/ItemPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPicture(long id, ItemPicture itemPicture)
        {
            if (id != itemPicture.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemPicture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPictureExists(id))
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

        // POST: api/ItemPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPicture>> PostItemPicture(ItemPicture itemPicture)
        {
            _context.ItemPictures.Add(itemPicture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPicture", new { id = itemPicture.Id }, itemPicture);
        }

        // DELETE: api/ItemPictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPicture(long id)
        {
            var itemPicture = await _context.ItemPictures.FindAsync(id);
            if (itemPicture == null)
            {
                return NotFound();
            }

            _context.ItemPictures.Remove(itemPicture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPictureExists(long id)
        {
            return _context.ItemPictures.Any(e => e.Id == id);
        }
    }
}
