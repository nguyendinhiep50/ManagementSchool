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
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculty()
        {
            return await _faculty.GetAll();
        }

        // GET: api/Faculties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Faculty>> GetFaculty(Guid id)
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
        public async Task<IActionResult> PutFaculty(Guid id, Faculty faculty)
        {
            if (id != faculty.Id)
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
        public async Task<ActionResult<Faculty>> PostFaculty(FacultyDto facultyDto)
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
