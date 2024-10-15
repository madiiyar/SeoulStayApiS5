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
    public class AddonServicesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public AddonServicesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/AddonServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddonService>>> GetAddonServices()
        {
            return await _context.AddonServices.ToListAsync();
        }

        // GET: api/AddonServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddonService>> GetAddonService(long id)
        {
            var addonService = await _context.AddonServices.FindAsync(id);

            if (addonService == null)
            {
                return NotFound();
            }

            return addonService;
        }

        // PUT: api/AddonServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddonService(long id, AddonService addonService)
        {
            if (id != addonService.Id)
            {
                return BadRequest();
            }

            _context.Entry(addonService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddonServiceExists(id))
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

        // POST: api/AddonServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddonService>> PostAddonService(AddonService addonService)
        {
            _context.AddonServices.Add(addonService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddonService", new { id = addonService.Id }, addonService);
        }

        // DELETE: api/AddonServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddonService(long id)
        {
            var addonService = await _context.AddonServices.FindAsync(id);
            if (addonService == null)
            {
                return NotFound();
            }

            _context.AddonServices.Remove(addonService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddonServiceExists(long id)
        {
            return _context.AddonServices.Any(e => e.Id == id);
        }
    }
}
