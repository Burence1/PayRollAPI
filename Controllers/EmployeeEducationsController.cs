using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollAPI.Models;

namespace PayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeEducationsController : ControllerBase
    {
        private readonly PayrollContext _context;

        public EmployeeEducationsController(PayrollContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeEducations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeEducation>>> GetEmployeeEducations()
        {
          if (_context.EmployeeEducations == null)
          {
              return NotFound();
          }
            return await _context.EmployeeEducations.ToListAsync();
        }

        // GET: api/EmployeeEducations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeEducation>> GetEmployeeEducation(int id)
        {
          if (_context.EmployeeEducations == null)
          {
              return NotFound();
          }
            var employeeEducation = await _context.EmployeeEducations.FindAsync(id);

            if (employeeEducation == null)
            {
                return NotFound();
            }

            return employeeEducation;
        }

        // PUT: api/EmployeeEducations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeEducation(int id, EmployeeEducation employeeEducation)
        {
            if (id != employeeEducation.EducationHistId)
            {
                return BadRequest();
            }

            _context.Entry(employeeEducation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeEducationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeEducations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeEducation>> PostEmployeeEducation(EmployeeEducation employeeEducation)
        {
          if (_context.EmployeeEducations == null)
          {
              return Problem("Entity set 'PayrollContext.EmployeeEducations'  is null.");
          }
            _context.EmployeeEducations.Add(employeeEducation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeEducation", new { id = employeeEducation.EducationHistId }, employeeEducation);
        }

        // DELETE: api/EmployeeEducations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeEducation(int id)
        {
            if (_context.EmployeeEducations == null)
            {
                return NotFound();
            }
            var employeeEducation = await _context.EmployeeEducations.FindAsync(id);
            if (employeeEducation == null)
            {
                return NotFound();
            }

            _context.EmployeeEducations.Remove(employeeEducation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeEducationExists(int id)
        {
            return (_context.EmployeeEducations?.Any(e => e.EducationHistId == id)).GetValueOrDefault();
        }
    }
}
