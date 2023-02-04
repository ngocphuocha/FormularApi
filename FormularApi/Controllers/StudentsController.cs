using System;
using Microsoft.AspNetCore.Mvc;
using FormularApi.Data;
using FormularApi.Models;
using FormularApi.Data.DTOs.Requests.Students;
using Microsoft.EntityFrameworkCore;

namespace FormularApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public StudentsController(ApiDbContext apiDbContext)
        {
            _context = apiDbContext;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.Students.Include("Grade").ToList().Take(5));
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateNewStudentRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();
            var exitsGrades = _context.Grades.FirstOrDefault(x => x.GradeId == request.GradeId);

            if (exitsGrades == null) return BadRequest("Grade not found!!!");

            Student student = new Student()
            {
                Grade = exitsGrades,
                Name = request.Name,
            };

            await _context.AddAsync(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

    }
}
