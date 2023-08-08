using Microsoft.AspNetCore.Mvc;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeachersController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly ITeacher _iTeacher;
        public TeachersController(DbContextSchool context, ITeacher iTeacher)
        {
            _context = context;
            _iTeacher = iTeacher;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAllTeachers()
        {
            return await _iTeacher.GetAll();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetTeacher(Guid id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            return await _iTeacher.Get(id);
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(Guid id, TeacherDto TeacherDto)
        {
            if (id != TeacherDto.TeacherId)
            {
                return BadRequest();
            }
            if (await _iTeacher.Put(id, TeacherDto) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> PostTeacher(TeacherAddDto TeacherDto)
        {
            if (_context.Teachers == null)
                return Problem("Entity set 'DbContextSchool.Teachers'  is null.");
            if (await _iTeacher.Post(TeacherDto))
                return CreatedAtAction("GetTeacher", new { id = TeacherDto.TeacherName }, TeacherDto);
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
            if (await _iTeacher.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
