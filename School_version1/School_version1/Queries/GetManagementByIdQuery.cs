using MediatR;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace LearnCQRS.Queries
{
    public class GetManagementByIdQuery : IRequest<Management>
    {
        public Guid Id { get; set; }
    }
    public class GetManagementByIdHandler : IRequestHandler<GetManagementByIdQuery, Management>
    {
        private readonly IBaseRepositories<Management, ManagementDto> _studentRepository;

        public GetManagementByIdHandler(IBaseRepositories<Management, ManagementDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Management> Handle(GetManagementByIdQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.Get(query.Id);
        }
    }
}
