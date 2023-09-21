using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Services
{
    public class StudentServices : BaseEntityService<Student, StudentDto, StudentAddDto>, IStudent
    {
        private readonly ILoginAccountRepository accountRepo;
        private readonly UserManager<CustomIdentityUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        public StudentServices(DbContextSchool db, UserManager<CustomIdentityUser> _userManager, RoleManager<IdentityRole<Guid>> roleManager, IMapper mapper, ILoginAccountRepository repo) : base(db, mapper)
        {
            accountRepo = repo;
            userManager = _userManager;
        }
        // ghi de phuong thuc Post Sinh vien de tao them tai khoan cho sinh vien trong identity
        public override async Task<bool> Post(StudentAddDto dto)
        {
            try
            {
                var userAdd = new CustomIdentityUser
                {
                    UserName = dto.StudentName,
                    Email = dto.StudentEmail,
                    NormalizedUserName = dto.StudentName.ToUpper(),
                    NormalizedEmail = dto.StudentEmail.ToUpper(),
                    PasswordHash = "123",
                    Student = new Student
                    {
                        StudentName = dto.StudentName,
                        StudentBirthDate = dto.StudentBirthDate,
                        StudentDateCome = DateTime.Now,
                        FacultyId = dto.FacultyId,
                    },
                };
                var a = await userManager.AddToRoleAsync(userAdd, "Student"); 
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
        //private async Task
        public async Task<List<StudentDto>> GetAllStudentFaculty(int page, int size)
        {
            page = page < 1 ? 1 : page;
            int PagesSkip = (page - 1) * size;
            // take all
            if (size < 1)
            {
                var entity2 = await _db.Set<Student>().Include(x => x.Faculty).ToListAsync();
                return _mapper.Map<List<StudentDto>>(entity2).ToList();
            }
            var entity = await _db.Set<Student>().Include(x => x.Faculty).Skip(PagesSkip).Take(size).ToListAsync();
            return _mapper.Map<List<StudentDto>>(entity).ToList();

        }

        public async Task<List<StudentDto>> GetAllStudentsInFaculty(Guid id)
        {
            var students = await _db.Students.Include(s => s.Faculty).Where(x => x.FacultyId == id).ToListAsync();

            return _mapper.Map<List<StudentDto>>(students).ToList();
        }

        public async Task<StudentDto> GetStudentFaculty(Guid id)
        {
            var student = await _db.Students.FindAsync(id);
            student.Faculty = await _db.Faculty.FindAsync(student.FacultyId);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentInfo> GetInfoAccountStudent(string token)
        {
            var student = await accountRepo.TakeInfoAccount(token);
            var result = await _db.Students
                       .Include(x => x.CustomIdentityUser)
                       .Include(x => x.Faculty)
                       .Where(x => x.CustomIdentityUser.Id == student.Id)
                       .FirstOrDefaultAsync();
            return _mapper.Map<StudentInfo>(result);

        }

        public async Task<bool> PostManyStudent(List<StudentAddDto> listStudent)
        {
            //var hasher = new PasswordHasher<IdentityUser>();
            //var usersToAdd = new List<CustomIdentityUser>();

            //foreach (var line in listStudent)
            //{
            //    var user = new CustomIdentityUser
            //    {
            //        UserName = line.StudentNameLogin,
            //        Email = line.StudentEmail,
            //        NormalizedUserName = line.StudentName.ToUpper(),
            //        NormalizedEmail = line.StudentEmail.ToUpper(),
            //        PasswordHash = hasher.HashPassword(null, "123"),
            //        Student = new Student
            //        {
            //            StudentName = line.StudentName,
            //            StudentBirthDate = line.StudentBirthDate,
            //            StudentDateCome = DateTime.Now,
            //            FacultyId = line.FacultyId,
            //        },
            //    };

            //    usersToAdd.Add(user);
            //}

            //// Tạo người dùng và thêm vai trò
            //var createResult = await userManager.CreateAsync(usersToAdd, "123");
            //if (createResult.Succeeded)
            //{
            //    foreach (var user in usersToAdd)
            //    {
            //        await userManager.AddToRoleAsync(user, "Student");
            //    }
            //}

            //await _db.SaveChangesAsync();

            return true;
        }


        public async Task<List<SubjectGradesAddDto>> GetTakeCourseScores(Guid idAccount)
        {
            var subjectGradesList = await _db.SubjectGrades.Include(x => x.Student).Include(x => x.Subject)
                .Where(x => x.Student.CustomIdentityUserID == idAccount)
                .ToListAsync();
            List<SubjectGradesAddDto> listObj = new List<SubjectGradesAddDto>();
            foreach (var item in subjectGradesList)
            {
                SubjectGradesAddDto obj = new SubjectGradesAddDto();
                obj.SubjectGradesId = item.Id;
                obj.GPARank1 = item.GPARank1;
                obj.GPARank2 = item.GPARank2;
                obj.GPARank3 = item.GPARank3;
                obj.GPARank4 = item.GPARank4;
                listObj.Add(obj);
            }
            return listObj;
        }

    }
}
