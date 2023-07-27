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
    public class ListStudentClassLearnsController : ControllerBase
    {
        private readonly DbContextSchool _context;

        public ListStudentClassLearnsController(DbContextSchool context)
        {
            _context = context;
        }

        // GET: api/ListStudentClassLearns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListStudentClassLearn>>> GetListStudentClassLearns()
        {
          if (_context.ListStudentClassLearns == null)
          {
              return NotFound();
          }
            return await _context.ListStudentClassLearns.ToListAsync();
        }

        // GET: api/ListStudentClassLearns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListStudentClassLearn>> GetListStudentClassLearn(Guid id)
        {
          if (_context.ListStudentClassLearns == null)
          {
              return NotFound();
          }
            var listStudentClassLearn = await _context.ListStudentClassLearns.FindAsync(id);

            if (listStudentClassLearn == null)
            {
                return NotFound();
            }

            return listStudentClassLearn;
        }

        // PUT: api/ListStudentClassLearns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListStudentClassLearn(Guid id, ListStudentClassLearn listStudentClassLearn)
        {
            if (id != listStudentClassLearn.IdListStudentClassLearn)
            {
                return BadRequest();
            }

            _context.Entry(listStudentClassLearn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListStudentClassLearnExists(id))
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

        // POST: api/ListStudentClassLearns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListStudentClassLearn>> PostListStudentClassLearn(ListStudentClassLearn listStudentClassLearn)
        {
          if (_context.ListStudentClassLearns == null)
          {
              return Problem("Entity set 'DbContextSchool.ListStudentClassLearns'  is null.");
          }
            _context.ListStudentClassLearns.Add(listStudentClassLearn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListStudentClassLearn", new { id = listStudentClassLearn.IdListStudentClassLearn }, listStudentClassLearn);
        }

        // DELETE: api/ListStudentClassLearns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListStudentClassLearn(Guid id)
        {
            if (_context.ListStudentClassLearns == null)
            {
                return NotFound();
            }
            var listStudentClassLearn = await _context.ListStudentClassLearns.FindAsync(id);
            if (listStudentClassLearn == null)
            {
                return NotFound();
            }

            _context.ListStudentClassLearns.Remove(listStudentClassLearn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListStudentClassLearnExists(Guid id)
        {
            return (_context.ListStudentClassLearns?.Any(e => e.IdListStudentClassLearn == id)).GetValueOrDefault();
        }
    }
}
