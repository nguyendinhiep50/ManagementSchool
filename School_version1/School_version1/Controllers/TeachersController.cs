using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly ITeacher  _iTeacher;
        public TeachersController(DbContextSchool context, ITeacher iTeacher)
        {
            _context = context;
            _iTeacher = iTeacher;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
          if (_context.Teachers == null)
          {
              return NotFound();
          }
            return await _iTeacher.GetAllTeacher();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(Guid id)
        {
          if (_context.Teachers == null)
          {
              return NotFound();
          }
            var teacher = await _iTeacher.GetTeacher(id);
            return teacher != null ? teacher : NotFound();
        }
        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(Guid id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }
            if (await _iTeacher.PutTeacher(id, teacher) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            if (_context.Teachers == null)
                return Problem("Entity set 'DbContextSchool.Students'  is null.");
            if (await _iTeacher.PostTeacher(teacher))
                return CreatedAtAction("GetStudent", new { id = teacher.Id }, teacher);
            return NotFound();
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            if (await _iTeacher.DeleteTeacher(id))
                return NoContent();
            return NotFound();
        }

    }
}
