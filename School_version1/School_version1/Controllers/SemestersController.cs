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
    public class SemestersController : ControllerBase
    { 
        private readonly ISemesters _iSemesters;
        public SemestersController(DbContextSchool context, ISemesters iSemesters)
        { 
            _iSemesters = iSemesters;
        }

        // GET: api/Semesters
        [HttpGet("GetSemesters")] 
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetSemesters(int pages,int size)
        {
            return await _iSemesters.GetAll(pages,size);
        }
        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        { 
            return await _iSemesters.GetAllCount();
        }
        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> GetSemester(Guid id)
        { 
            return await _iSemesters.Get(id);
        }

        // PUT: api/Semesters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemester(Guid id, SemesterDto SemesterDto)
        {
            if (id != SemesterDto.SemesterId)
            {
                return BadRequest();
            }
            if (await _iSemesters.Put(id, SemesterDto) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Semesters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SemesterDto>> PostSemester(SemesterAddDto semesterDto)
        { 
            if (await _iSemesters.Post(semesterDto))
                return CreatedAtAction("GetSemester", new { id = semesterDto.SemesterName }, semesterDto);
            return NotFound();
        }
        // DELETE: api/Semesters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(Guid id)
        { 
            if (await _iSemesters.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
