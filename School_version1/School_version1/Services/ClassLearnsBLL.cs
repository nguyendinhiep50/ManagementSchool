﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class ClassLearnsBLL : BaseEntityService<ClassLearn, ClassLearnsDto> ,IClassLearn
    {
        public ClassLearnsBLL(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}