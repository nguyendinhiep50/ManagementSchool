using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _iStudent;


        public StudentsController(IStudent iStudent)
        {
            _iStudent = iStudent;
        }

        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        {

            return await _iStudent.GetAllCount();
        }
        // GET: api/Students
        [HttpGet("TakeNameFaculty")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsFaculty(int pages, int size)
        {

            return await _iStudent.GetAllStudentFaculty(pages, size);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {

            return await _iStudent.Get(id);
        }
        // GET: api/Students/5
        [HttpGet("Faculty{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentFaculty(Guid id)
        {

            return await _iStudent.GetStudentFaculty(id);
        }

        // Get Filter Student if = FacultyId
        [HttpGet("StudentInFaculty{id}")]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudentsInFaculty(Guid id)
        {

            return await _iStudent.GetAllStudentsInFaculty(id);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, StudentDto student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            if (await _iStudent.Put(id, student) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAddDto>> PostStudent(StudentAddDto StudentAddDto)
        {
            if (await _iStudent.Post(StudentAddDto))
                return CreatedAtAction("GetStudent", new { id = StudentAddDto.StudentName }, StudentAddDto);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {

            if (await _iStudent.Delete(id))
                return NoContent();
            return NotFound();
        }
        [HttpGet("TakeInfoStudent")]
        public async Task<ActionResult<StudentInfo>> GetManagementInfo()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
            string token = null;

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                token = authorizationHeader.Substring("Bearer ".Length);
            }
            return await _iStudent.GetInfoAccountStudent(token);
        }
    }
}
