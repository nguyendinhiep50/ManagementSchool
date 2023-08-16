using MediatR;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace LearnCQRS.Commands
{
    public class DeleteManagementCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
    public class DeleteStudentHandler : IRequestHandler<DeleteManagementCommand, Guid>
    {
        private readonly IBaseRepositories<Management, ManagementDto,ManagementAddDto> _studentRepository;

        public DeleteStudentHandler(IBaseRepositories<Management, ManagementDto, ManagementAddDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Guid> Handle(DeleteManagementCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.Get(command.Id);
            if (studentDetails == null)
                return default;

            return await _studentRepository.Delete(studentDetails.ManagementId);
        }
    }
}
