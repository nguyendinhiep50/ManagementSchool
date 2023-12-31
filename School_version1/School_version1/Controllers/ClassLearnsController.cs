﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Management")]
    public class ClassLearnsController : ControllerBase
    { 
        private readonly IClassLearn _classLearn;
        public ClassLearnsController(  IClassLearn iClassLearn)
        { 
            _classLearn = iClassLearn;
        }
        // GET: api/ClassLearns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassLearnsDto>>> GetClassLearns(int pages,int size)
        {
            return await _classLearn.GetAll(pages,size);
        }
        [HttpGet("TakeCountAll")]
        public async Task<ActionResult<int>> GetTakeCountAll()
        {
 
            return await _classLearn.GetAllCount();
        }
        // GET: api/ClassLearns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassLearnsDto>> GetClassLearn(Guid id)
        {
 
            return await _classLearn.Get(id);
        }
        [HttpGet("GetListStudentInClass")]
        public async Task<ActionResult<List<string>>> GetListStudentInClass(Guid id, int pages, int size)
        {
 
            return await _classLearn.GetAllStudentInClassLearn(id,pages,size);
        }

        // PUT: api/ClassLearns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassLearn(Guid id, ClassLearnsDto classLearn)
        {
            if (id != classLearn.ClassLearnsId)
            {
                return BadRequest();
            }
            if (await _classLearn.Put(id, classLearn) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/ClassLearns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassLearnsDto>> PostClassLearn(ClassLearnsAddDto classLearnsDto)
        { 
            if (await _classLearn.Post(classLearnsDto))
                return CreatedAtAction("GetClassLearns", new { id = classLearnsDto.ClassLearnName }, classLearnsDto);
            return NotFound();
        }

        // DELETE: api/ClassLearns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassLearn(Guid id)
        {
            if (await _classLearn.Delete(id))
                return NoContent();
            return NotFound();

        }

    }
}
