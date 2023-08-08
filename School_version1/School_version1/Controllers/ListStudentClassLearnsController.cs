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
    public class ListStudentClassLearnsController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly IListStudentClassLearn _listStudentClassLearn;
        public ListStudentClassLearnsController(DbContextSchool context, IListStudentClassLearn listStudentClassLearn)
        {
            _context = context;
            _listStudentClassLearn = listStudentClassLearn;
        }

        // GET: api/ListStudentClassLearns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListStudentClassLearn>>> GetListStudentClassLearns()
        {
            return await _listStudentClassLearn.GetAll();
        }

        // GET: api/ListStudentClassLearns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListStudentClassLearn>> GetListStudentClassLearn(Guid id)
        {
            if(_context.ListStudentClassLearns == null)
            {
                return NotFound();
            }
            return await _listStudentClassLearn.Get(id);
        }

        // PUT: api/ListStudentClassLearns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListStudentClassLearn(Guid id, ListStudentClassLearn listStudentClassLearn)
        {
            if (id != listStudentClassLearn.Id)
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
        public async Task<ActionResult<ListStudentClassLearnDto>> PostListStudentClassLearn(ListStudentClassLearnDto listStudentClassLearnDto)
        {
            if (_context.ListStudentClassLearns == null)
                return Problem("Entity set 'DbContextSchool.Teachers'  is null.");
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
  
    }
}
