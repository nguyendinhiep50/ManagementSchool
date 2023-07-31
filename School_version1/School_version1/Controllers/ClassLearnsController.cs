using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassLearnsController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly IClassLearn _classLearn;
        public ClassLearnsController(DbContextSchool context, IClassLearn iClassLearn)
        {
            _context = context;
            _classLearn = iClassLearn;
        }
        // GET: api/ClassLearns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassLearn>>> GetClassLearns()
        {
            return await _classLearn.GetAll();
        }

        // GET: api/ClassLearns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassLearn>> GetClassLearn(Guid id)
        {
            if (_context.Faculty == null)
            {
                return NotFound();
            }
            return await _classLearn.Get(id);
        }

        // PUT: api/ClassLearns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassLearn(Guid id, ClassLearn classLearn)
        {
            if (id != classLearn.Id)
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
        public async Task<ActionResult<ClassLearnsDto>> PostClassLearn(ClassLearnsDto classLearnsDto)
        {
            if (_context.ClassLearns == null)
                return Problem("Entity set 'DbContextSchool.Teachers'  is null.");
            if (await _classLearn.Post(classLearnsDto))
                return CreatedAtAction("GetClassLearns", new { id = classLearnsDto.ClassLearnName }, classLearnsDto);
            return NotFound();
        }

        // DELETE: api/ClassLearns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassLearn(Guid id)
        {
            if  (await _classLearn.Delete(id))
                return NoContent();
            return NotFound();

        }

    }
}
