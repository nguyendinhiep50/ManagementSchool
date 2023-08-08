using MediatR;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace LearnCQRS.Queries
{
    public class GetManagementListQuery : IRequest<List<Management>>
    {
        public Guid Id { get; set; }
    }
    public class GetManagementListHandler : IRequestHandler<GetManagementListQuery, List<Management>>
    {
        private readonly IBaseRepositories<Management, ManagementDto> _studentRepository;

        public GetManagementListHandler(IBaseRepositories<Management, ManagementDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Management>> Handle(GetManagementListQuery query, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAll();
        }
    }
}
