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
    public class SubjectsController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly ISubject _iSubject;
        public SubjectsController(DbContextSchool context, ISubject iSubject)
        {
            _context = context;
            _iSubject = iSubject;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            return await _iSubject.GetAll();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(Guid id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            return await _iSubject.Get(id);
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(Guid id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }
            if (await _iSubject.Put(id, subject) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> PostSubject(SubjectDto subjectdto)
        {
            if (_context.Subjects == null)
                return Problem("Entity set 'DbContextSchool.Subjects'  is null.");
            if (await _iSubject.Post(subjectdto))
                return CreatedAtAction("GetSubject", new { id = subjectdto.SubjectName }, subjectdto);
            return NotFound();
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            if (_context.Subjects == null)
            {
                return NotFound();
            }
            if (await _iSubject.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
