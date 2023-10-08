using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Interface;
using School_version1.Models.DTOs;
using System.Data;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher,Management")]

    public class SubjectGradesController : ControllerBase
    {
        private readonly ISubjectGrades _iSubjectGrades; 

        private readonly ISupportToken _supportToken;
        public SubjectGradesController(ISubjectGrades iSubjectGrades, ISupportToken supportToken)
        {
            _iSubjectGrades = iSubjectGrades;
            _supportToken = supportToken;
            var currentUser = User; // Thông tin người dùng hiện tại
            _supportToken.SetCurrentUser(currentUser); 
        }
        // request AcademicPrograms
        // get SubjectGrades and NameSubject 

        // thêm điểm cho học sinh dựa trên academicPrograms and GPA
        [AllowAnonymous]
        [HttpGet("GetSubjectGradesAllClassLearn")]
        public async Task<ActionResult<object>> GetSubjectGradesAllClassLearn(string IdClassLearn)
        {
            var result = await _iSubjectGrades.GetSubjectGradesAllClassLearn(IdClassLearn);
            return result;
            // add name student 
        }
        [AllowAnonymous]
        [HttpGet("GetSubjectGradesId")]
        public async Task<ActionResult<SubjectGradesAddDto>> GetSubjectGradesId(string IdSubjectGrades)
        {
            return null;
        }
        [AllowAnonymous]
        [HttpGet("GetSubjectGradesStudentSubject")]
        public async Task<ActionResult<object>> GetSubjectGradesStudentSubject()
        {
            // add student name , add student subject
            //guid bien = new guid(idstudent);
            var UserId = HttpContext.Items["UserId"].ToString();
            var result = _iSubjectGrades.GetSubjectGradesStudentSubject(UserId);
            return null;
        }
        [AllowAnonymous]
        [HttpPut("UpdateSubjectGradesStudent")]
        public async Task<ActionResult<object>> UpdateSubjectGradesStudent(SubjectGradesAddDto SubjectGradesAddDtos)
        {
            var result = await _iSubjectGrades.UpdateSubjectGradesStudent(SubjectGradesAddDtos);
            // add student name , add student subject
            //Guid Bien = new Guid(IdStudent);
            //return await _scholl.SubjectGrades
            //                .Where(x => x.StudentId == Bien)
            //                .Include(x => x.Subject)
            //                .Include(x => x.Student)
            //                .ToListAsync();
            return result;
        }
    }
}
