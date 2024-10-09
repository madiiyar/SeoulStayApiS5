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
    public class CancellationPoliciesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public CancellationPoliciesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/CancellationPolicies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancellationPolicy>>> GetCancellationPolicies()
        {
            return await _context.CancellationPolicies.ToListAsync();
        }

        // GET: api/CancellationPolicies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CancellationPolicy>> GetCancellationPolicy(long id)
        {
            var cancellationPolicy = await _context.CancellationPolicies.FindAsync(id);

            if (cancellationPolicy == null)
            {
                return NotFound();
            }

            return cancellationPolicy;
        }

        // PUT: api/CancellationPolicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancellationPolicy(long id, CancellationPolicy cancellationPolicy)
        {
            if (id != cancellationPolicy.Id)
            {
                return BadRequest();
            }

            _context.Entry(cancellationPolicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancellationPolicyExists(id))
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

        // POST: api/CancellationPolicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CancellationPolicy>> PostCancellationPolicy(CancellationPolicy cancellationPolicy)
        {
            _context.CancellationPolicies.Add(cancellationPolicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancellationPolicy", new { id = cancellationPolicy.Id }, cancellationPolicy);
        }

        // DELETE: api/CancellationPolicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancellationPolicy(long id)
        {
            var cancellationPolicy = await _context.CancellationPolicies.FindAsync(id);
            if (cancellationPolicy == null)
            {
                return NotFound();
            }

            _context.CancellationPolicies.Remove(cancellationPolicy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancellationPolicyExists(long id)
        {
            return _context.CancellationPolicies.Any(e => e.Id == id);
        }
    }
}
