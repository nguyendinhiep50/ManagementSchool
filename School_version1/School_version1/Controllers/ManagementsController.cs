using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {
        private readonly DbContextSchool _context;

        public ManagementsController(DbContextSchool context)
        {
            _context = context;
        }

        // GET: api/Managements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Management>>> GetManagement()
        {
          if (_context.Managements == null)
          {
              return NotFound();
          }
            return await _context.Managements.ToListAsync();
        }

        // GET: api/Managements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Management>> GetManagement(Guid id)
        {
          if (_context.Managements == null)
          {
              return NotFound();
          }
            var management = await _context.Managements.FindAsync(id);

            if (management == null)
            {
                return NotFound();
            }

            return management;
        }

        // PUT: api/Managements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagement(Guid id, Management management)
        {
            if (id != management.Id)
            {
                return BadRequest();
            }

            _context.Entry(management).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementExists(id))
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

        // POST: api/Managements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Management>> PostManagement(Management management)
        {
          if (_context.Managements == null)
          {
              return Problem("Entity set 'DbContextSchool.Management'  is null.");
          }
            _context.Managements.Add(management);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagement", new { id = management.Id }, management);
        }

        // DELETE: api/Managements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagement(Guid id)
        {
            if (_context.Managements == null)
            {
                return NotFound();
            }
            var management = await _context.Managements.FindAsync(id);
            if (management == null)
            {
                return NotFound();
            }

            _context.Managements.Remove(management);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagementExists(Guid id)
        {
            return (_context.Managements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
