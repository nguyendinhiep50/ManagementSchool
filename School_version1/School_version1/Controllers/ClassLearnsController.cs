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
    public class ClassLearnsController : ControllerBase
    {
        private readonly DbContextSchool _context;

        public ClassLearnsController(DbContextSchool context)
        {
            _context = context;
        }

        // GET: api/ClassLearns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassLearn>>> GetClassLearns()
        {
          if (_context.ClassLearns == null)
          {
              return NotFound();
          }
            return await _context.ClassLearns.ToListAsync();
        }

        // GET: api/ClassLearns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassLearn>> GetClassLearn(Guid id)
        {
          if (_context.ClassLearns == null)
          {
              return NotFound();
          }
            var classLearn = await _context.ClassLearns.FindAsync(id);

            if (classLearn == null)
            {
                return NotFound();
            }

            return classLearn;
        }

        // PUT: api/ClassLearns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassLearn(Guid id, ClassLearn classLearn)
        {
            if (id != classLearn.Id)
            {
                return BadRequest();
            }

            _context.Entry(classLearn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassLearnExists(id))
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

        // POST: api/ClassLearns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassLearn>> PostClassLearn(ClassLearn classLearn)
        {
          if (_context.ClassLearns == null)
          {
              return Problem("Entity set 'DbContextSchool.ClassLearns'  is null.");
          }
            _context.ClassLearns.Add(classLearn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassLearn", new { id = classLearn.Id }, classLearn);
        }

        // DELETE: api/ClassLearns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassLearn(Guid id)
        {
            if (_context.ClassLearns == null)
            {
                return NotFound();
            }
            var classLearn = await _context.ClassLearns.FindAsync(id);
            if (classLearn == null)
            {
                return NotFound();
            }

            _context.ClassLearns.Remove(classLearn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassLearnExists(Guid id)
        {
            return (_context.ClassLearns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
