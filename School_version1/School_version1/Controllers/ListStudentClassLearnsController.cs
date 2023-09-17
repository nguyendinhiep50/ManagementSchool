using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Management")]
    public class ListStudentClassLearnsController : ControllerBase
    {
        private readonly IListStudentClassLearn _listStudentClassLearn;
        private readonly ILoginAccountRepository accountRepo;
        public ListStudentClassLearnsController(IListStudentClassLearn listStudentClassLearn, ILoginAccountRepository repo)
        {
            _listStudentClassLearn = listStudentClassLearn;
            accountRepo = repo;
        }
        // GET: api/ListStudentClassLearns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListStudentClassLearnDto>>> GetListStudentClassLearns(int pages, int size)
        {
            return await _listStudentClassLearn.GetAll(pages, size);
        }
        // GET: api/ListStudentClassLearns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListStudentClassLearnDto>> GetListStudentClassLearn(Guid id)
        {
            return await _listStudentClassLearn.Get(id);
        }
        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        { 
            return await _listStudentClassLearn.GetAllCount();
        }
        // PUT: api/ListStudentClassLearns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListStudentClassLearn(Guid id, ListStudentClassLearnDto listStudentClassLearn)
        {
            if (id != listStudentClassLearn.ListStudentClassLearnId)
            {
                return BadRequest();
            }
            if (await _listStudentClassLearn.Put(id, listStudentClassLearn) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/ListStudentClassLearns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListStudentClassLearnDto>> PostListStudentClassLearn(ListStudentClassLearnAddDto listStudentClassLearnDto)
        { 
            if (await _listStudentClassLearn.Post(listStudentClassLearnDto))
                return CreatedAtAction("GetListStudentClassLearn", new { id = listStudentClassLearnDto.StudentId }, listStudentClassLearnDto);
            return NotFound();
        }

        // DELETE: api/ListStudentClassLearns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListStudentClassLearn(Guid id)
        {
            if (await _listStudentClassLearn.Delete(id))
                return NoContent();
            return NotFound();
        }

        // Post Student In Class
        [AllowAnonymous]
        [HttpPost("StudentRegisterClass/{id}")]
        public async Task<ActionResult<string>> StudentRegisterClass(string id)
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
            string token = null;

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                token = authorizationHeader.Substring("Bearer ".Length);
            }
            var ketqua = await accountRepo.TakeInfoAccount(token);
            var StudentInfo = await _listStudentClassLearn.GetStudentId(Guid.Parse(ketqua.Id));
            var AcademicId =await _listStudentClassLearn.GetAcademicProgramDtos(Guid.Parse(id)); 
            var CLassLearnID = await _listStudentClassLearn.AddStudentClassLearn(AcademicId.AcademicProgramId,AcademicId.SubjectId,StudentInfo.StudentId);
            if(CLassLearnID == null) 
                return NotFound(); 
            return Ok(ketqua);
        }

    }
}
