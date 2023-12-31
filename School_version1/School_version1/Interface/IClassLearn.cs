﻿using School_version1.Entities;
using School_version1.Models.DTOs;

namespace School_version1.Interface
{
    public interface IClassLearn : IEntityService<ClassLearn, ClassLearnsDto,ClassLearnsAddDto>
    {
        Task<List<string>> GetAllStudentInClassLearn(Guid id, int pages, int size);

    }
}
