using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly ISemesters _iSemesters;
        public SemestersController(DbContextSchool context, ISemesters iSemesters)
        {
            _context = context;
            _iSemesters = iSemesters;
        }

        // GET: api/Semesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semester>>> GetSemesters()
        {
            return await _iSemesters.GetAll(); 
        }

        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semester>> GetSemester(Guid id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            return await _iSemesters.Get(id);
        }

        // PUT: api/Semesters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemester(Guid id, Semester semester)
        {
            if (id != semester.Id)
            {
                return BadRequest();
            }
            if (await _iSemesters.Put(id, semester) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Semesters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SemesterDto>> PostSemester(SemesterDto semesterDto)
        {
            if (_context.Semesters == null)
                return Problem("Entity set 'DbContextSchool.Semesters'  is null.");
            if (await _iSemesters.Post(semesterDto))
                return CreatedAtAction("GetSemester", new { id = semesterDto.SemesterName }, semesterDto);
            return NotFound();
        }
        // DELETE: api/Semesters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(Guid id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            if (await _iSemesters.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
