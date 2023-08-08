using MediatR;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace LearnCQRS.Queries
{
    public class GetManagementByIdQuery : IRequest<ManagementDto>
    {
        public Guid Id { get; set; }
    }
    public class GetManagementByIdHandler : IRequestHandler<GetManagementByIdQuery, ManagementDto>
    {
        private readonly IBaseRepositories<Management, ManagementDto, ManagementAddDto> _studentRepository;

        public GetManagementByIdHandler(IBaseRepositories<Management, ManagementDto, ManagementAddDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ManagementDto> Handle(GetManagementByIdQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.Get(query.Id);
        }
    }
}
