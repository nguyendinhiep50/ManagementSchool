using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens; 
using School_version1.Interface; 
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Management,Student")]
    public class SubjectsController : ControllerBase
    { 
        private readonly ISubject _iSubject; 
        public SubjectsController( ISubject iSubject)
        { 
            _iSubject = iSubject;  
        }

        // GET: api/Subjects
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjects(int pages, int size)
        {
            return await _iSubject.GetAll(pages, size);
        }
        //Get Subject for Student with Fauclty 
        // thêm cái kiểm tra xem đăng kí chưa và tạo class mới để có dữ liệu chưa đăng kí
        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        {
 
            return await _iSubject.GetAllCount();
        }
        [HttpGet("TakeSubjectForStudent")] 
        public async Task<List<SubjectDto>> GetSubjectInStudent()
        {
            string username123 = HttpContext.Items["Username"].ToString();

            try
            {  
                if (username123 != null)
                    return await _iSubject.GetSubjectStudentFaucltyAll(username123);
            }
            catch (SecurityTokenException)
            {
                return null;
            }
            return null;
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")] 

        public async Task<ActionResult<SubjectDto>> GetSubject(Guid id)
        {
 
            return await _iSubject.Get(id);
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Management")]
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
        [Authorize(Roles = "Management")]
        public async Task<ActionResult<SubjectDto>> PostSubject(SubjectAddDto subjectdto)
        { 
            if (await _iSubject.Post(subjectdto))
                return CreatedAtAction("GetSubject", new { id = subjectdto.SubjectName }, subjectdto);
            return NotFound();
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            if (await _iSubject.Delete(id))
                return NoContent();
            return NotFound();
        }

        [HttpGet("SubjectNoRegister")] 
        public async Task<List<SubjectDto>> SubjectNoRegister()
        {
            string username123 = HttpContext.Items["Username"].ToString();
            if (username123 != null)
                return await _iSubject.GetSubjectStudentFaucltyNoRegister(username123);
            return null;
        }
        [HttpGet("SubjectRegister")] 
        public async Task<List<SubjectDto>> SubjectRegister()
        {
            string username123 = HttpContext.Items["Username"].ToString();
            if (username123 != null)
                return await _iSubject.GetSubjectStudentFaucltyRegister(username123); 
            return null;
        }
 
    }
}
