using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Management")]
    public class FacultiesController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly IFaculty _faculty;
        public FacultiesController(DbContextSchool context, IFaculty iFaculty)
        {
            _context = context;
            _faculty = iFaculty;
        }
        // GET: api/Faculties
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetFaculty(int pages, int size)
        {
            return await _faculty.GetAll(pages,size);
        }
        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _faculty.GetAllCount();
        }
        // GET: api/Faculties/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<FacultyDto>> GetFaculty(Guid id)
        {
            if (_context.Faculty == null)
            {
                return NotFound();
            }
            return await _faculty.Get(id);
        }

        // PUT: api/Faculties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaculty(Guid id, FacultyDto faculty)
        {
            if (id != faculty.FacultyId)
            {
                return BadRequest();
            }
            if (await _faculty.Put(id, faculty) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Faculties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacultyDto>> PostFaculty(FacultyAddDto facultyDto)
        {
            if (_context.Faculty == null)
                return Problem("Entity set 'DbContextSchool.Teachers'  is null.");
            if (await _faculty.Post(facultyDto))
                return CreatedAtAction("GetFaculty", new { id = facultyDto.FacultyName }, facultyDto);
            return NotFound();
        }

        // DELETE: api/Faculties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(Guid id)
        {
            if (await _faculty.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
