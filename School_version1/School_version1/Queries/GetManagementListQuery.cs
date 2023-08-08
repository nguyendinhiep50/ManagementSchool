using MediatR;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace LearnCQRS.Queries
{
    public class GetManagementListQuery : IRequest<List<ManagementDto>>
    {
        public Guid Id { get; set; }
    }
    public class GetManagementListHandler : IRequestHandler<GetManagementListQuery, List<ManagementDto>>
    {
        private readonly IBaseRepositories<Management, ManagementDto, ManagementAddDto> _studentRepository;

        public GetManagementListHandler(IBaseRepositories<Management, ManagementDto, ManagementAddDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<ManagementDto>> Handle(GetManagementListQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAll();
        }
    }
}
