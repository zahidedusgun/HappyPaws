using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HappyPaws.Persistence.Contexts;
using HappyPaws.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetPets()
        {
            var pets = await _context.Pets.ToListAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(Guid id)
        {
            if (id == null)
                return BadRequest("Id cannot be empty");

            var pet = await _context.Pets.FindAsync(id);

            if (pet is null)
                return NotFound("The pet requested with given Id was not found");
       

            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> CreatePet([FromBody] Pet pet)
        {
            if (pet is null)
                return BadRequest();

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(Guid id, [FromBody] Pet pet)
        {
            if (pet == null || id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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
        public async Task<IActionResult> DeletePet(Guid id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetExists(Guid id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
