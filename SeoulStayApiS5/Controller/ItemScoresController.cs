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
    public class ItemScoresController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public ItemScoresController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/ItemScores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemScore>>> GetItemScores()
        {
            return await _context.ItemScores.ToListAsync();
        }

        // GET: api/ItemScores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemScore>> GetItemScore(long id)
        {
            var itemScore = await _context.ItemScores.FindAsync(id);

            if (itemScore == null)
            {
                return NotFound();
            }

            return itemScore;
        }

        // PUT: api/ItemScores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemScore(long id, ItemScore itemScore)
        {
            if (id != itemScore.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemScoreExists(id))
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

        // POST: api/ItemScores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemScore>> PostItemScore(ItemScore itemScore)
        {
            _context.ItemScores.Add(itemScore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemScore", new { id = itemScore.Id }, itemScore);
        }

        // DELETE: api/ItemScores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemScore(long id)
        {
            var itemScore = await _context.ItemScores.FindAsync(id);
            if (itemScore == null)
            {
                return NotFound();
            }

            _context.ItemScores.Remove(itemScore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemScoreExists(long id)
        {
            return _context.ItemScores.Any(e => e.Id == id);
        }
    }
}
