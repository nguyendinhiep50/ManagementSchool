﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;

namespace School_version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DbContextSchool _context;
        private readonly IStudent _iStudent;

        public StudentsController(DbContextSchool context, IStudent iStudent)
        {
            _context = context;
            _iStudent = iStudent;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetAll();
        }
        // GET: api/Students
        [HttpGet("Take Name Faculty")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsFaculty()
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetAllStudentFaculty();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.Get(id);
        }
        // GET: api/Students/5
        [HttpGet("Faculty{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentFaculty(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetStudentFaculty(id);
        }

        // Get Filter Student if = FacultyId
        [HttpGet("StudentInFaculty{id}")]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudentsInFaculty(Guid id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            return await _iStudent.GetAllStudentsInFaculty(id);
        }


        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            if (await _iStudent.Put(id, student) != null)
                return NoContent();
            return NotFound();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAddDto>> PostStudent(StudentAddDto StudentAddDto)
        {
            if (_context.Students == null)
                return Problem("Entity set 'DbContextSchool.Students'  is null.");
            if (await _iStudent.Post(StudentAddDto))
                return CreatedAtAction("GetStudent", new { id = StudentAddDto.StudentName }, StudentAddDto);
            return NotFound();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            if (await _iStudent.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
