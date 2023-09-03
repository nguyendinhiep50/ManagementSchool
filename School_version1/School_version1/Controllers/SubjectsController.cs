using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Management")]
    public class SubjectsController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly ISubject _iSubject;
        private readonly ISupportToken _supportToken;
        public SubjectsController(DbContextSchool context, ISubject iSubject, ISupportToken supportToken)
        {
            _context = context;
            _iSubject = iSubject;
            _supportToken = supportToken;
            var currentUser = User; // Thông tin người dùng hiện tại
            _supportToken.SetCurrentUser(currentUser);
        }

        // GET: api/Subjects
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjects(int pages, int size)
        {
            return await _iSubject.GetAll(pages, size);
        }
        //Get Subject for Student with Fauclty 
        // thêm cái kiểm tra xem đăng kí chưa và tạo class mới để có dữ liệu chưa đăng kí
        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iSubject.GetAllCount();
        }
        [HttpGet("TakeSubjectForStudent")]
        [AllowAnonymous]
        public async Task<List<SubjectDto>> GetSubjectInStudent(string tokenStudent)
        {
            try
            { 
                var check = await _supportToken.GetSubjectInStudent(tokenStudent);
                if (check != null)
                    return await _iSubject.GetSubjectStudentFauclty(check);
            }
            catch (SecurityTokenException)
            {
                return null;
            }
            return null;
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<SubjectDto>> GetSubject(Guid id)
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
        public async Task<IActionResult> PutSubject(Guid id, SubjectDto subject)
        {
            if (id != subject.SubjectId)
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
        public async Task<ActionResult<SubjectDto>> PostSubject(SubjectAddDto subjectdto)
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
