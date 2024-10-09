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
    public class CancellationRefundFeesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public CancellationRefundFeesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/CancellationRefundFees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancellationRefundFee>>> GetCancellationRefundFees()
        {
            return await _context.CancellationRefundFees.ToListAsync();
        }

        // GET: api/CancellationRefundFees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CancellationRefundFee>> GetCancellationRefundFee(long id)
        {
            var cancellationRefundFee = await _context.CancellationRefundFees.FindAsync(id);

            if (cancellationRefundFee == null)
            {
                return NotFound();
            }

            return cancellationRefundFee;
        }

        // PUT: api/CancellationRefundFees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancellationRefundFee(long id, CancellationRefundFee cancellationRefundFee)
        {
            if (id != cancellationRefundFee.Id)
            {
                return BadRequest();
            }

            _context.Entry(cancellationRefundFee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancellationRefundFeeExists(id))
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

        // POST: api/CancellationRefundFees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CancellationRefundFee>> PostCancellationRefundFee(CancellationRefundFee cancellationRefundFee)
        {
            _context.CancellationRefundFees.Add(cancellationRefundFee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancellationRefundFee", new { id = cancellationRefundFee.Id }, cancellationRefundFee);
        }

        // DELETE: api/CancellationRefundFees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancellationRefundFee(long id)
        {
            var cancellationRefundFee = await _context.CancellationRefundFees.FindAsync(id);
            if (cancellationRefundFee == null)
            {
                return NotFound();
            }

            _context.CancellationRefundFees.Remove(cancellationRefundFee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancellationRefundFeeExists(long id)
        {
            return _context.CancellationRefundFees.Any(e => e.Id == id);
        }
    }
}
