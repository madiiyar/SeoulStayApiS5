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
    public class ServiceTypesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public ServiceTypesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/ServiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypes()
        {
            return await _context.ServiceTypes.ToListAsync();
        }

        // GET: api/ServiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceType(long id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return serviceType;
        }

        // PUT: api/ServiceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceType(long id, ServiceType serviceType)
        {
            if (id != serviceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(id))
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

        // POST: api/ServiceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceType>> PostServiceType(ServiceType serviceType)
        {
            _context.ServiceTypes.Add(serviceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceType", new { id = serviceType.Id }, serviceType);
        }

        // DELETE: api/ServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceType(long id)
        {
            var serviceType = await _context.ServiceTypes.FindAsync(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            _context.ServiceTypes.Remove(serviceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceTypeExists(long id)
        {
            return _context.ServiceTypes.Any(e => e.Id == id);
        }
    }
}
