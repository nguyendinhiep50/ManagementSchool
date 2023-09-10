using MediatR; 
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;  

namespace School_version1.Queries
{
    public class GetManagementInfoQuery : IRequest<ManagementInfo>
    {
        public string token { get; set; }
    }

    public class GetManagementInfoHandler : IRequestHandler<GetManagementInfoQuery, ManagementInfo>
    {
        private readonly IManagementRepositories _managementRepository;

        public GetManagementInfoHandler(IManagementRepositories managementRepository)
        {
            _managementRepository = managementRepository;
        }

        public async Task<ManagementInfo> Handle(GetManagementInfoQuery query, CancellationToken cancellationToken)
        {
            // Sử dụng thuộc tính 'token' của đối tượng truy vấn (query) để gọi phương thức GetInfoAccount
            return await _managementRepository.GetInfoAccount(query.token);
        }
    }

}
