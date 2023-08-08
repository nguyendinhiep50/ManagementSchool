using MediatR;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace LearnCQRS.Commands
{
    public class DeleteStudentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Guid>
    {
        private readonly IBaseRepositories<Management, ManagementDto> _studentRepository;

        public DeleteStudentHandler(IBaseRepositories<Management, ManagementDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Guid> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.Get(command.Id);
            if (studentDetails == null)
                return default;

            return await _studentRepository.Delete(studentDetails.Id);
        }
    }
}
