using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2test.Models;

namespace PRAK10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly EmiasContext _context;

        public DoctorController(EmiasContext context)
        {
            _context = context;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorTable>>> GetDoctors()
        {
            return await _context.DoctorTables.ToListAsync();
        }

        // POST: api/Doctor
        [HttpPost]
        public async Task<ActionResult<DoctorTable>> PostDoctor(DoctorTable doctor)
        {
            _context.DoctorTables.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDoctors), new { id = doctor.Id }, doctor);
        }

        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorTable doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.DoctorTables.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.DoctorTables.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.DoctorTables.Any(e => e.Id == id);
        }
    }
}