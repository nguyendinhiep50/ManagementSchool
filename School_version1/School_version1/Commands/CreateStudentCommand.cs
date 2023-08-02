using MediatR;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LearnCQRS.Commands
{
    public class CreateManagementCommand : IRequest<ManagementDto>
    {
        public string ManagementName { get; set; }
        public string ManagementEmail { get; set; }
        public string ManagementPassword { get; set; }


        public CreateManagementCommand(string managementName, string managementEmail, string managementPassword)
        {
            ManagementName = managementName;
            ManagementEmail = managementEmail;
            ManagementPassword = managementPassword; 
        }
    }
    public class CreateManagementHandler : IRequestHandler<CreateManagementCommand, ManagementDto>
    {
        private readonly IBaseRepositories<Management, ManagementDto> _studentRepository;

        public CreateManagementHandler(IBaseRepositories<Management, ManagementDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<ManagementDto> Handle(CreateManagementCommand command, CancellationToken cancellationToken)
        {
            var management = new ManagementDto()
            {
                ManagementName = command.ManagementName,
                ManagementEmail = command.ManagementEmail,
                ManagementPassword = command.ManagementPassword
            };

            return await _studentRepository.Post(management);
        }
    }
}
