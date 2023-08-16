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
    [Authorize(Policy = "AdminPolicy")]
    public class TeachersController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly ITeacher _iTeacher;
        public TeachersController(DbContextSchool context, ITeacher iTeacher)
        {
            _context = context;
            _iTeacher = iTeacher;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAllTeachers(int pages)
        {
            return await _iTeacher.GetAll(pages);
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TeacherDto>> GetTeacher(Guid id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            return await _iTeacher.Get(id);
        }
        [HttpGet("InfoFromToken")]
        [AllowAnonymous]
        public async Task<ActionResult<TeacherDto>> GetInfoFromToken(String stringToken)
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
                    return await _iTeacher.Get(userId);
            }
            catch (SecurityTokenException)
            {
                // Nếu giải mã token gặp lỗi, xử lý lỗi tại đây
                return null;
            }
            return null;
        }
        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(Guid id, TeacherDto TeacherDto)
        {
            if (id != TeacherDto.TeacherId)
            {
                return BadRequest();
            }
            if (await _iTeacher.Put(id, TeacherDto) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> PostTeacher(TeacherAddDto TeacherDto)
        {
            if (_context.Teachers == null)
                return Problem("Entity set 'DbContextSchool.Teachers'  is null.");
            if (await _iTeacher.Post(TeacherDto))
                return CreatedAtAction("GetTeacher", new { id = TeacherDto.TeacherName }, TeacherDto);
            return NotFound();
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginStudent(LoginAddDto loginAccount)
        {
            var kqLogin = await _iTeacher.PostLoginToken(loginAccount);
            if (kqLogin != null)
            {
                // Tạo một claim chứa thông tin về người dùng (có thể là id, tên, v.v.)
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, kqLogin.TeacherId.ToString())
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

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            if (_context.Teachers == null)
            {
                return NotFound();
            }
            if (await _iTeacher.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
