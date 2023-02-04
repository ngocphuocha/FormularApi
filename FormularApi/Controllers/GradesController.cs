using System;
using FormularApi.Data;
using FormularApi.Data.DTOs.Requests.Grades;
using FormularApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public GradesController(ApiDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Grades.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateNewGradeRequest request)
        {
            if (ModelState.IsValid)
            {
                Grade grade = new Grade();

                grade.GradeName = request.GradeName;
                grade.Section = request.Section;

                await _context.Grades.AddAsync(grade);
                await _context.SaveChangesAsync();

                return Ok(grade);
            }

            return BadRequest();
        }
    }
}