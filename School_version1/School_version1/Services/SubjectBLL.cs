﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class SubjectBLL : BaseEntityService<Subject, SubjectDto,SubjectAddDto> ,ISubject
    {
        public SubjectBLL(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
    }
    
}
