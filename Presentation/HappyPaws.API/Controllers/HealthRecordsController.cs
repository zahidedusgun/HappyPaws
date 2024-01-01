using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HealthRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealthRecords()
        {
            var healthRecords = await _context.HealthRecords
                .Include(hr => hr.Pet) 
                .ToListAsync();

            return Ok(healthRecords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHealthRecord(Guid id)
        {
            var healthRecord = await _context.HealthRecords
                .Include(hr => hr.Pet) 
                .FirstOrDefaultAsync(hr => hr.Id == id);

            if (healthRecord == null)
            {
                return NotFound();
            }

            return Ok(healthRecord);
        }

        [HttpPost]
        public async Task<IActionResult> PostHealthRecord([FromBody] HealthRecord healthRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HealthRecords.Add(healthRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHealthRecord", new { id = healthRecord.Id }, healthRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthRecord(Guid id, [FromBody] HealthRecord healthRecord)
        {
            if (id != healthRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(healthRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthRecordExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthRecord(Guid id)
        {
            var healthRecord = await _context.HealthRecords.FindAsync(id);
            if (healthRecord == null)
            {
                return NotFound();
            }

            _context.HealthRecords.Remove(healthRecord);
            await _context.SaveChangesAsync();

            return Ok(healthRecord);
        }

        private bool HealthRecordExists(Guid id)
        {
            return _context.HealthRecords.Any(e => e.Id == id);
        }
    }

}

