﻿using MediatR;
using School_version1.Entities;
using School_version1.Models.DTOs;
using School_version1.Repositories;

namespace LearnCQRS.Commands
{
    public class UpdateManagementCommand : IRequest<Boolean>
    {
        public Guid Id { get; set; }
        public string ManagementName { get; set; }
        public string ManagementEmail { get; set; }
        public string ManagementPassword { get; set; }

        public UpdateManagementCommand(Guid id,string managementName, string managementEmail, string managementPassword)
        {
            Id = id;
            ManagementName = managementName;
            ManagementEmail = managementEmail;
            ManagementPassword = managementPassword;
        }
    }
    public class UpdateStudentHandler : IRequestHandler<UpdateManagementCommand, Boolean>
    {
        private readonly IBaseRepositories<Management, ManagementDto,ManagementAddDto> _studentRepository;

        public UpdateStudentHandler(IBaseRepositories<Management, ManagementDto, ManagementAddDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Boolean> Handle(UpdateManagementCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.Get(command.Id);
            if (studentDetails == null)
                return default;

            studentDetails.ManagementName = command.ManagementName;
            studentDetails.ManagementEmail = command.ManagementEmail;
            studentDetails.ManagementPassword = command.ManagementPassword; 
            
            return await _studentRepository.Put(command.Id,studentDetails);
        }
    }
}
