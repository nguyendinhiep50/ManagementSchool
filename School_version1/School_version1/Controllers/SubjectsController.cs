using LearnCQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Management")]
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
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjects(int pages,int size)
        {
            return await _iSubject.GetAll(pages,size);
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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nguyendinhiep_key_longdaithonglong"));
            var userIdClaim123 = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var username13 = User.FindFirst(ClaimTypes.Name)?.Value;
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false
            };
            try
            {
                // Giải mã token và trả về thông tin bên trong dưới dạng ClaimsPrincipal
                var claimsPrincipal = tokenHandler.ValidateToken(tokenStudent, tokenValidationParameters, out var validatedToken);
                var userIdClaim = claimsPrincipal.Identities.FirstOrDefault().Name;
                if (userIdClaim != null && Guid.TryParse(userIdClaim, out Guid userId))
                    return await _iSubject.GetSubjectStudentFauclty(userId);
            }
            catch (SecurityTokenException)
            {
                // Nếu giải mã token gặp lỗi, xử lý lỗi tại đây
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
