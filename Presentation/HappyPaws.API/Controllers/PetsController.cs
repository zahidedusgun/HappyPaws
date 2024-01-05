using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HappyPaws.Persistence.Contexts;
using HappyPaws.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HappyPaws.Application.Features.Commands.Pet.CreatePet;
using HappyPaws.Application.Features.Commands.Pet.RemovePet;
using HappyPaws.Application.Features.Commands.Pet.UpdatePet;
using HappyPaws.Application.Features.Queries.Pet.GetAllPet;
using HappyPaws.Application.Features.Queries.Pet.GetByIdPet;
using MediatR;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public PetsController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPetQueryRequest getAllPetQueryRequest)
        {
            var requestResponse = await _mediator.Send(getAllPetQueryRequest);

            return Ok(requestResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdPetQueryRequest getByIdPetQueryRequest)
        {
            return Ok(await _mediator.Send(getByIdPetQueryRequest));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePetCommandRequest createPetCommandRequest)
        {
            var requestResponse = await _mediator.Send(createPetCommandRequest);

            await _context.SaveChangesAsync();

            return Ok(StatusCode(requestResponse.StatusCode));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdatePetCommandRequest updatePetCommandRequest)
        {
            await _mediator.Send(updatePetCommandRequest);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemovePetCommandRequest removePetCommandRequest)
        {
            await _mediator.Send(removePetCommandRequest);

            return Ok();
        }


    }
}