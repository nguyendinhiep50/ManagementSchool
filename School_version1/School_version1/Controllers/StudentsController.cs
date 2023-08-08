using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly IStudent _iStudent;

        public StudentsController(DbContextSchool context, IStudent iStudent)
        {
            _context = context;
            _iStudent = iStudent;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetAll();
        }
        // GET: api/Students
        [HttpGet("Take Name Faculty")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsFaculty()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetAllStudentFaculty();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.Get(id);
        }
        // GET: api/Students/5
        [HttpGet("Faculty{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentFaculty(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetStudentFaculty(id);
        }

        // Get Filter Student if = FacultyId
        [HttpGet("StudentInFaculty{id}")]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudentsInFaculty(Guid id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetAllStudentsInFaculty(id);
        }
        // lấy thông tin thông qua token
        [HttpGet("user")]
        public async Task<ActionResult<StudentDto>> GetUserInfo(String stringToken)
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
                var claimsPrincipal = tokenHandler.ValidateToken(stringToken, tokenValidationParameters, out var validatedToken);
                var userIdClaim = claimsPrincipal.Identities.FirstOrDefault().Name;
                if (userIdClaim != null && Guid.TryParse(userIdClaim, out Guid userId))
                    return await _iStudent.Get(userId);
            }
            catch (SecurityTokenException)
            {
                // Nếu giải mã token gặp lỗi, xử lý lỗi tại đây
                return null;
            }
            return null;
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
            if (_context.Students == null)
                return Problem("Entity set 'DbContextSchool.Students'  is null.");
            if (await _iStudent.Post(StudentAddDto))
                return CreatedAtAction("GetStudent", new { id = StudentAddDto.StudentName }, StudentAddDto);
            return NotFound();
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginStudent(LoginDto loginAccount)
        {
            if (_context.Students == null)
                return Problem("Entity set 'DbContextSchool.Students'  is null.");
            var kqLogin = await _iStudent.PostLoginToken(loginAccount);
            if (kqLogin != null)
            {
                // Tạo một claim chứa thông tin về người dùng (có thể là id, tên, v.v.)
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, kqLogin.StudentId.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nguyendinhiep_key_longdaithonglong"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Tạo access token bằng JWT
                var token = new JwtSecurityToken(
                    issuer: "your-issuer",
                    audience: "your-audience",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Invalid username or password.");
        }
        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            if (await _iStudent.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
