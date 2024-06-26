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
    public class AnalysDocumentTablesController : ControllerBase
    {
        private readonly EmiasContext _context;

        public AnalysDocumentTablesController(EmiasContext context)
        {
            _context = context;
        }

        // GET: api/AnalysDocumentTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysDocumentTable>>> GetAnalysDocumentTables()
        {
            return await _context.AnalysDocumentTables.ToListAsync();
        }

        // GET: api/AnalysDocumentTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysDocumentTable>> GetAnalysDocumentTable(int id)
        {
            var analysDocumentTable = await _context.AnalysDocumentTables.FindAsync(id);

            if (analysDocumentTable == null)
            {
                return NotFound();
            }

            return analysDocumentTable;
        }

        // PUT: api/AnalysDocumentTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysDocumentTable(int id, AnalysDocumentTable analysDocumentTable)
        {
            if (id != analysDocumentTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(analysDocumentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysDocumentTableExists(id))
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

        // POST: api/AnalysDocumentTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnalysDocumentTable>> PostAnalysDocumentTable(AnalysDocumentTable analysDocumentTable)
        {
            _context.AnalysDocumentTables.Add(analysDocumentTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysDocumentTable", new { id = analysDocumentTable.Id }, analysDocumentTable);
        }

        // DELETE: api/AnalysDocumentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysDocumentTable(int id)
        {
            var analysDocumentTable = await _context.AnalysDocumentTables.FindAsync(id);
            if (analysDocumentTable == null)
            {
                return NotFound();
            }

            _context.AnalysDocumentTables.Remove(analysDocumentTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysDocumentTableExists(int id)
        {
            return _context.AnalysDocumentTables.Any(e => e.Id == id);
        }
    }
}
