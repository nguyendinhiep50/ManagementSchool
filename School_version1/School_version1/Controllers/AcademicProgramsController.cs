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
    public class AcademicProgramsController : ControllerBase
    { 
        private readonly IAcademicProgram _AcademicProgram;
        public AcademicProgramsController(IAcademicProgram iAcademicProgram)
        { 
            _AcademicProgram = iAcademicProgram;
        }

        // GET: api/AcademicPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicProgramDto>>> GetAcademicPrograms(int pages,int size)
        { 
            return await _AcademicProgram.GetAll(pages,size);
        }
        // GET: api/AcademicPrograms
        [HttpGet("ProgramLearn")]
        public async Task<ActionResult<IEnumerable<AcademicProgramSPDto>>> GetProgramLearn()
        {
            return await _AcademicProgram.GetProgramLearn();
        }
        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        {
 
            return await _AcademicProgram.GetAllCount();
        }
        [HttpGet("ProgramLearnFaculty")]
        public async Task<ActionResult<IEnumerable<AcademicProgramSPDto>>> GetProgramLearnFaculty(Guid facultyId)
        {
            return await _AcademicProgram.GetProgramLearnFaculty(facultyId);
        }
        // GET: api/AcademicPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicProgramDto>> GetAcademicProgram(Guid id)
        {
 
            return await _AcademicProgram.Get(id);
        }

        // PUT: api/AcademicPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicProgram(Guid id, AcademicProgramDto academicProgram)
        {
            if (id != academicProgram.AcademicProgramId)
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
        public async Task<ActionResult<AcademicProgramDto>> PostAcademicProgram(AcademicProgramAddDto academicProgramDto)
        { 
            if (await _AcademicProgram.Post(academicProgramDto))
                return CreatedAtAction("GetAcademicProgram", new { id = academicProgramDto.FacultyId }, academicProgramDto);
            return NotFound();
        }

        // DELETE: api/AcademicPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicProgram(Guid id)
        {
 
            if (await _AcademicProgram.Delete(id))
                return NoContent();
            return NotFound();
        }

        [HttpGet("GetListAcademicProgram")]
        public async Task<ActionResult<IEnumerable<AcademicProgramListName>>> GetListAcademicProgram(int pages, int size)
        {
            return await _AcademicProgram.GetListAcademicProgramPage(pages, size);
        }
    }
}
