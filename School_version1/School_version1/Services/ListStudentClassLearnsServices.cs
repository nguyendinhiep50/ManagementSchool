using AutoMapper;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class ListStudentClassLearnsServices : BaseEntityService<ListStudentClassLearn, ListStudentClassLearnDto,ListStudentClassLearnAddDto>, IListStudentClassLearn
    {
        public ListStudentClassLearnsServices(DbContextSchool db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
