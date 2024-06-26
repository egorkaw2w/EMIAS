using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A2test.Models;

namespace A2test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTablesController : ControllerBase
    {
        private readonly EmiasContext _context;

        public PatientTablesController(EmiasContext context)
        {
            _context = context;
        }

        // GET: api/PatientTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientTable>>> GetPatientTables()
        {
            return await _context.PatientTables.ToListAsync();
        }

        // GET: api/PatientTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientTable>> GetPatientTable(long id)
        {
            var patientTable = await _context.PatientTables.FindAsync(id);

            if (patientTable == null)
            {
                return NotFound();
            }

            return patientTable;
        }

        // PUT: api/PatientTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientTable(long id, PatientTable patientTable)
        {
            if (id != patientTable.Oms)
            {
                return BadRequest();
            }

            _context.Entry(patientTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientTableExists(id))
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

        // POST: api/PatientTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientTable>> PostPatientTable(PatientTable patientTable)
        {
            _context.PatientTables.Add(patientTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientTable", new { id = patientTable.Oms }, patientTable);
        }

        // DELETE: api/PatientTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientTable(long id)
        {
            var patientTable = await _context.PatientTables.FindAsync(id);
            if (patientTable == null)
            {
                return NotFound();
            }

            _context.PatientTables.Remove(patientTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientTableExists(long id)
        {
            return _context.PatientTables.Any(e => e.Oms == id);
        }
    }
}