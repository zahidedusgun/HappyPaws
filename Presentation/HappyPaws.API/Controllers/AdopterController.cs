using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdopterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdopterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdopters()
        {
            var adopters = await _context.Adopters.ToListAsync();
            return Ok(adopters);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdopterById(Guid id)
        {
            var adopter = await _context.Adopters.FindAsync(id);

            if (adopter == null)
            {
                return NotFound();
            }

            return Ok(adopter);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdopter([FromBody] Adopter adopter)
        {
            if (ModelState.IsValid)
            {
                _context.Adopters.Add(adopter);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAdopterById), new { id = adopter.Id }, adopter);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdopter(Guid id, [FromBody] Adopter updatedAdopter)
        {
            if (id != updatedAdopter.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedAdopter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopterExists(id))
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
        public async Task<IActionResult> DeleteAdopter(Guid id)
        {
            var adopter = await _context.Adopters.FindAsync(id);

            if (adopter == null)
            {
                return NotFound();
            }

            _context.Adopters.Remove(adopter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdopterExists(Guid id)
        {
            return _context.Adopters.Any(e => e.Id == id);
        }
    }
}