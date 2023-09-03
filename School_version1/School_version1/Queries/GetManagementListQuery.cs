using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;
using System.Drawing;
using System.Security.Policy;

namespace LearnCQRS.Queries
{
    public class GetManagementListQuery : IRequest<List<ManagementDto>>
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }

    public class GetManagementListHandler : IRequestHandler<GetManagementListQuery, List<ManagementDto>>
    {
        private readonly IBaseRepositories<Management, ManagementDto, ManagementAddDto> _managementRepository;

        public GetManagementListHandler(IBaseRepositories<Management, ManagementDto, ManagementAddDto> studentRepository)
        {
            _managementRepository = studentRepository;
        }

        public async Task<List<ManagementDto>> Handle(GetManagementListQuery query, CancellationToken cancellationToken)
        {
            return await _managementRepository.GetAll(query.Size, query.Page);
        }
    }
}
 