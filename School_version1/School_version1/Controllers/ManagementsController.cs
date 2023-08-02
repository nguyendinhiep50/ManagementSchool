using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnCQRS.Commands;
using LearnCQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagementsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        // GET: api/Managements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Management>>> GetManagements()
        {
            return await mediator.Send(new GetManagementListQuery());
        }

        // GET: api/Managements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Management>> GetManagement(Guid id)
        {
            var studentDetails = await mediator.Send(new GetManagementByIdQuery() { Id = id });

            return studentDetails;
        }

        // PUT: api/Managements/5
        [HttpPut]
        public async Task<Management> UpdateStudentAsync(Management management)
        {
            var isStudentDetailUpdated = await mediator.Send(new UpdateStudentCommand(
               management.Id,
               management.ManagementName,
               management.ManagementEmail,
               management.ManagementPassword));
            return isStudentDetailUpdated;
        }

        // POST: api/Managements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagementDto>> PostManagement(ManagementDto managementDto)
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
            return await mediator.Send(new DeleteStudentCommand() { Id = Id });
        }
    }
}
