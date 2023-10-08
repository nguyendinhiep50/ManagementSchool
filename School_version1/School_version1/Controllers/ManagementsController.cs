using LearnCQRS.Commands;
using LearnCQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_version1.Models.DTOs;
using School_version1.Queries;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Management")]
    public class ManagementsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagementsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/Managements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementDto>>> GetManagements(int page,int size)
        {
            return await mediator.Send(new GetManagementListQuery() { Page=page,Size=size});
        }

        // GET: api/Managements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagementDto>> GetManagement(Guid id)
        {
            return await mediator.Send(new GetManagementByIdQuery() { Id = id });
        }

        // PUT: api/Managements/5
        [HttpPut("{id}")]
        public async Task<Boolean> UpdateStudentAsync(Guid id, ManagementDto management)
        {
            var isStudentDetailUpdated = await mediator.Send(new UpdateManagementCommand(
               management.ManagementId = id,
               management.ManagementName,
               management.ManagementEmail,
               management.ManagementPassword));
            return isStudentDetailUpdated;
        }
        // POST: api/Managements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Boolean>> PostManagement(ManagementDto managementDto)
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
        [HttpGet("GetManagementInfo")]
        public async Task<ActionResult<ManagementInfo>> GetManagementInfo()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
            string token = null;

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                token = authorizationHeader.Substring("Bearer ".Length);
            }
            return await mediator.Send(new GetManagementInfoQuery() { token = token });
        }
    }
}
