using LearnCQRS.Commands;
using LearnCQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School_version1.Commands;
using School_version1.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManagementsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagementsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/Managements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementDto>>> GetManagements()
        {
            return await mediator.Send(new GetManagementListQuery());
        }

        // GET: api/Managements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagementDto>> GetManagement(Guid id)
        { 
            return await mediator.Send(new GetManagementByIdQuery() { Id = id }); 
        }

        // PUT: api/Managements/5
        [HttpPut]
        public async Task<ManagementDto> UpdateStudentAsync(ManagementDto management)
        {
            var isStudentDetailUpdated = await mediator.Send(new UpdateManagementCommand(
               management.ManagementId,
               management.ManagementName,
               management.ManagementEmail,
               management.ManagementPassword));
            return isStudentDetailUpdated;
        }

        // POST: api/Managements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagementAddDto>> PostManagement(ManagementDto managementDto)
        {
            var studentDetail = await mediator.Send(new CreateManagementCommand(
                managementDto.ManagementName,
                managementDto.ManagementEmail,
                managementDto.ManagementPassword));
            return studentDetail;
        }
        // DELETE: api/Managements/5
        [HttpDelete]
        public async Task<Guid> DeleteStudentAsync(Guid Id)
        {
            return await mediator.Send(new DeleteManagementCommand() { Id = Id });
        }

        // lấy thông tin thông qua token
        [HttpGet("user")]
        public async Task<ActionResult<ManagementDto>> GetUserInfo(String stringToken)
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
                    return await mediator.Send(new GetManagementByIdQuery() { Id = userId });
            }
            catch (SecurityTokenException)
            {
                // Nếu giải mã token gặp lỗi, xử lý lỗi tại đây
                return null;
            }
            return null;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginStudent(LoginAddDto loginAccount)
        {
            var kqLogin = await mediator.Send(new LoginManagementCommand(loginAccount));
            if (kqLogin != null)
            {
                // Tạo một claim chứa thông tin về người dùng (có thể là id, tên, v.v.)
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, kqLogin.LoginId.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
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
    }
}
