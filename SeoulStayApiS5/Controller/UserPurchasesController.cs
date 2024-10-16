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
    public class UserPurchasesController : ControllerBase
    {
        private readonly SeoulStayMobileS5Context _context;

        public UserPurchasesController(SeoulStayMobileS5Context context)
        {
            _context = context;
        }

        // GET: api/UserPurchases
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<UserPurchase>>> GetUserPurchases()
        {
            return await _context.UserPurchases.ToListAsync();
        }*/

        // GET: api/UserPurchases?userId={userId}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPurchase>>> GetUserPurchases([FromQuery] long userId)
        {
            // Fetch purchases that belong to the specific userId
            var userPurchases = await _context.UserPurchases
                                              .Where(up => up.UserId == userId)
                                              .ToListAsync();

            if (!userPurchases.Any())
            {
                return NotFound(); // No purchases found for the user
            }

            return Ok(userPurchases); // Return the filtered user purchases
        }

        // GET: api/UserPurchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPurchase>> GetUserPurchase(long id)
        {
            var userPurchase = await _context.UserPurchases.FindAsync(id);

            if (userPurchase == null)
            {
                return NotFound();
            }

            return userPurchase;
        }

        // PUT: api/UserPurchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPurchase(long id, UserPurchase userPurchase)
        {
            if (id != userPurchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPurchaseExists(id))
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

        // POST: api/UserPurchases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPurchase>> PostUserPurchase(UserPurchase userPurchase)
        {
            _context.UserPurchases.Add(userPurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPurchase", new { id = userPurchase.Id }, userPurchase);
        }

        // DELETE: api/UserPurchases/ClearCart?userId={userId}
        [HttpDelete("ClearCart")]
        public async Task<IActionResult> ClearCart(long userId)
        {
            var userPurchases = await _context.UserPurchases
                                              .Where(up => up.UserId == userId)
                                              .ToListAsync();

            if (!userPurchases.Any())
            {
                return NotFound("No purchases found for the user.");
            }

            _context.UserPurchases.RemoveRange(userPurchases);
            await _context.SaveChangesAsync();

            return NoContent(); // Cart cleared successfully
        }


        // DELETE: api/UserPurchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPurchase(long id)
        {
            var userPurchase = await _context.UserPurchases.FindAsync(id);
            if (userPurchase == null)
            {
                return NotFound();
            }

            _context.UserPurchases.Remove(userPurchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPurchaseExists(long id)
        {
            return _context.UserPurchases.Any(e => e.Id == id);
        }
    }
}
