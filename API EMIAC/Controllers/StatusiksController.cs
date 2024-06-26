using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_EMIAC.Models;

namespace API_EMIAC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusiksController : ControllerBase
    {
        private readonly EmiacContext _context;

        public StatusiksController(EmiacContext context)
        {
            _context = context;
        }

        // GET: api/Statusiks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statusik>>> GetStatusik()
        {
            return await _context.Statusik.ToListAsync();
        }

        // GET: api/Statusiks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statusik>> GetStatusik(int? id)
        {
            var statusik = await _context.Statusik.FindAsync(id);

            if (statusik == null)
            {
                return NotFound();
            }

            return statusik;
        }

        // PUT: api/Statusiks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusik(int? id, Statusik statusik)
        {
            if (id != statusik.IdStatusik)
            {
                return BadRequest();
            }

            _context.Entry(statusik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusikExists(id))
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

        // POST: api/Statusiks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statusik>> PostStatusik(Statusik statusik)
        {
            _context.Statusik.Add(statusik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusik", new { id = statusik.IdStatusik }, statusik);
        }

        // DELETE: api/Statusiks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusik(int? id)
        {
            var statusik = await _context.Statusik.FindAsync(id);
            if (statusik == null)
            {
                return NotFound();
            }

            _context.Statusik.Remove(statusik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusikExists(int? id)
        {
            return _context.Statusik.Any(e => e.IdStatusik == id);
        }
    }
}
