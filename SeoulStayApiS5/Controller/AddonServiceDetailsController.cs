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
    public class AddonServiceDetailsController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public AddonServiceDetailsController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/AddonServiceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddonServiceDetail>>> GetAddonServiceDetails()
        {
            return await _context.AddonServiceDetails.ToListAsync();
        }

        // GET: api/AddonServiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddonServiceDetail>> GetAddonServiceDetail(long id)
        {
            var addonServiceDetail = await _context.AddonServiceDetails.FindAsync(id);

            if (addonServiceDetail == null)
            {
                return NotFound();
            }

            return addonServiceDetail;
        }

        // PUT: api/AddonServiceDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddonServiceDetail(long id, AddonServiceDetail addonServiceDetail)
        {
            if (id != addonServiceDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(addonServiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddonServiceDetailExists(id))
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

        // POST: api/AddonServiceDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddonServiceDetail>> PostAddonServiceDetail(AddonServiceDetail addonServiceDetail)
        {
            _context.AddonServiceDetails.Add(addonServiceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddonServiceDetail", new { id = addonServiceDetail.Id }, addonServiceDetail);
        }

        // DELETE: api/AddonServiceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddonServiceDetail(long id)
        {
            var addonServiceDetail = await _context.AddonServiceDetails.FindAsync(id);
            if (addonServiceDetail == null)
            {
                return NotFound();
            }

            _context.AddonServiceDetails.Remove(addonServiceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddonServiceDetailExists(long id)
        {
            return _context.AddonServiceDetails.Any(e => e.Id == id);
        }
    }
}
