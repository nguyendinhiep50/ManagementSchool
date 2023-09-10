using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Interface;
using System.Data;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher,Management")]

    public class SubjectGradesController : ControllerBase
    {
        private readonly ISubject _iSubject;
        private readonly DbContextSchool _scholl;

        private readonly ISupportToken _supportToken;
        public SubjectGradesController(ISubject iSubject, ISupportToken supportToken,DbContextSchool db)
        {
            _iSubject = iSubject;
            _supportToken = supportToken;
            var currentUser = User; // Thông tin người dùng hiện tại
            _supportToken.SetCurrentUser(currentUser);
            _scholl = db;
        }
        // request AcademicPrograms
        // get SubjectGrades and NameSubject

        // Tự Add vào khi có học sinh trong lớp và kiểm tra nếu học sinh này đã có thì thôi

        // thêm điểm cho học sinh dựa trên academicPrograms and GPA
        //[HttpGet]
        //public async Task<ActionResult<int>> GetTakeCountAll()
        //{

        //    //return await _scholl.ListStudentClassLearns.Where(x=>x.)
        //}
    }
}
