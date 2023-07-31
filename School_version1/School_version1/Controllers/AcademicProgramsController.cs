using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicProgramsController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly IAcademicProgram _AcademicProgram;
        public AcademicProgramsController(DbContextSchool context, IAcademicProgram iAcademicProgram)
        {
            _context = context;
            _AcademicProgram = iAcademicProgram;
        }

        // GET: api/AcademicPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicProgram>>> GetAcademicPrograms()
        {
            return await _AcademicProgram.GetAll();
        }

        // GET: api/AcademicPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicProgram>> GetAcademicProgram(Guid id)
        {
            if (_context.AcademicPrograms == null)
            {
                return NotFound();
            }
            return await _AcademicProgram.Get(id);
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
            if (await _AcademicProgram.Put(id, academicProgram) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/AcademicPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicProgram>> PostAcademicProgram(AcademicProgramDto academicProgramDto)
        {
            if (_context.Faculty == null)
                return Problem("Entity set 'DbContextSchool.Teachers'  is null.");
            if (await _AcademicProgram.Post(academicProgramDto))
                return CreatedAtAction("GetFaculty", new { id = academicProgramDto.AcademicProgramName }, academicProgramDto);
            return NotFound();
        }

        // DELETE: api/AcademicPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicProgram(Guid id)
        {
            if (_context.AcademicPrograms == null)
            {
                return NotFound();
            }
            if (await _AcademicProgram.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
