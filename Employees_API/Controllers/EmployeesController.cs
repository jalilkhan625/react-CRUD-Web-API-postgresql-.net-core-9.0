using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employees_API.Data;
using Employees_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            return employee;
        }

        // GET: api/employees/search?name=john
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Search term is required");

            return await _context.Employees
                .Where(e => e.fullname.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        // POST: api/employees/add
        [HttpPost("add")]
        public async Task<ActionResult<Employee>> Create([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure dateofbirth is in UTC
            employee.dateofbirth = employee.dateofbirth.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(employee.dateofbirth, DateTimeKind.Utc)
                : employee.dateofbirth.ToUniversalTime();

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = employee.id }, employee);
        }

        // PUT: api/employees/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            employee.fullname = updatedEmployee.fullname;
            employee.position = updatedEmployee.position;
            // Ensure dateofbirth is in UTC
            employee.dateofbirth = updatedEmployee.dateofbirth.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(updatedEmployee.dateofbirth, DateTimeKind.Utc)
                : updatedEmployee.dateofbirth.ToUniversalTime();
            employee.experience = updatedEmployee.experience;
            employee.skill = updatedEmployee.skill;
            employee.hourlyrate = updatedEmployee.hourlyrate;
            employee.photo = updatedEmployee.photo;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/employees/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Optional: Serve image from DB as HTTP file
        [HttpGet("photo/{id}")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null || employee.photo == null)
                return NotFound();

            return File(employee.photo, "image/jpeg"); // or use dynamic type if stored
        }
    }
}