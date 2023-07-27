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
    public class AcademicProgramsController : ControllerBase
    {
        private readonly DbContextSchool _context;

        public AcademicProgramsController(DbContextSchool context)
        {
            _context = context;
        }

        // GET: api/AcademicPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicProgram>>> GetAcademicPrograms()
        {
          if (_context.AcademicPrograms == null)
          {
              return NotFound();
          }
            return await _context.AcademicPrograms.ToListAsync();
        }

        // GET: api/AcademicPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicProgram>> GetAcademicProgram(Guid id)
        {
          if (_context.AcademicPrograms == null)
          {
              return NotFound();
          }
            var academicProgram = await _context.AcademicPrograms.FindAsync(id);

            if (academicProgram == null)
            {
                return NotFound();
            }

            return academicProgram;
        }

        // PUT: api/AcademicPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicProgram(Guid id, AcademicProgram academicProgram)
        {
            if (id != academicProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(academicProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicProgramExists(id))
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

        // POST: api/AcademicPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicProgram>> PostAcademicProgram(AcademicProgram academicProgram)
        {
          if (_context.AcademicPrograms == null)
          {
              return Problem("Entity set 'DbContextSchool.AcademicPrograms'  is null.");
          }
            _context.AcademicPrograms.Add(academicProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicProgram", new { id = academicProgram.Id }, academicProgram);
        }

        // DELETE: api/AcademicPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicProgram(Guid id)
        {
            if (_context.AcademicPrograms == null)
            {
                return NotFound();
            }
            var academicProgram = await _context.AcademicPrograms.FindAsync(id);
            if (academicProgram == null)
            {
                return NotFound();
            }

            _context.AcademicPrograms.Remove(academicProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicProgramExists(Guid id)
        {
            return (_context.AcademicPrograms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
