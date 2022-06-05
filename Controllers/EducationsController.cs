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
    public class EducationsController : ControllerBase
    {
        private readonly PayrollContext _context;

        public EducationsController(PayrollContext context)
        {
            _context = context;
        }

        // GET: api/Educations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> Geteducations()
        {
          if (_context.educations == null)
          {
              return NotFound();
          }
            return await _context.educations.ToListAsync();
        }

        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
          if (_context.educations == null)
          {
              return NotFound();
          }
            var education = await _context.educations.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return education;
        }

        // PUT: api/Educations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation(int id, Education education)
        {
            if (id != education.InstitutionId)
            {
                return BadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/Educations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Education>> PostEducation(Education education)
        {
          if (_context.educations == null)
          {
              return Problem("Entity set 'PayrollContext.educations'  is null.");
          }
            _context.educations.Add(education);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducation", new { id = education.InstitutionId }, education);
        }

        // DELETE: api/Educations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            if (_context.educations == null)
            {
                return NotFound();
            }
            var education = await _context.educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.educations.Remove(education);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationExists(int id)
        {
            return (_context.educations?.Any(e => e.InstitutionId == id)).GetValueOrDefault();
        }
    }
}
