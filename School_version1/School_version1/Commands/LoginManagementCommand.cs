using LearnCQRS.Commands;
using MediatR;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Repositories; 
namespace School_version1.Commands
{
    public class LoginManagementCommand : IRequest<ManagementDto>
    {
        public string ManagementEmail { get; set; }
        public string ManagementPassword { get; set; }
        public LoginManagementCommand(LoginAddDto lo)
        {
            ManagementEmail = lo.LoginEmail;
            ManagementPassword = lo.PassWorld;
        }
    }
    public class LoginManagementHandler : IRequestHandler<LoginManagementCommand, ManagementDto>
    {
        private readonly IBaseRepositories<Management, ManagementDto, ManagementAddDto> _studentRepository;

        public LoginManagementHandler(IBaseRepositories<Management, ManagementDto, ManagementAddDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ManagementDto> Handle(LoginManagementCommand request, CancellationToken cancellationToken)
        {
            var management = new LoginAddDto()
            {
                LoginEmail = request.ManagementEmail,
                PassWorld = request.ManagementPassword,
            };
            var result = await _studentRepository.LoginToken(management); 
            return result;
        }
    }
}
