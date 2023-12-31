﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class SemesterServices : BaseEntityService<Semester, SemesterDto,SemesterAddDto> ,ISemesters
    {
        public SemesterServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
    }
     
}
