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

<<<<<<< Updated upstream
        public PetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPetQueryRequest getAllPetQueryRequest)
        {
            var requestResponse = await _mediator.Send(getAllPetQueryRequest);

            return Ok(requestResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdPetQueryRequest getByIdPetQueryRequest)
=======
        public PetsController(IMediator mediator, FakeDataService fakeDataService, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _fakeDataService = fakeDataService;
            _memoryCache = memoryCache;


            _cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                Priority = CacheItemPriority.High,
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(30)
            };

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdPetQueryRequest getByIdPetQueryRequest)
>>>>>>> Stashed changes
        {
            return Ok(await _mediator.Send(getByIdPetQueryRequest));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePetCommandRequest createPetCommandRequest)
        {
            var requestResponse = await _mediator.Send(createPetCommandRequest);

            return Ok(requestResponse);
<<<<<<< Updated upstream
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


=======

        }




        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPetQueryRequest getAllPetQueryRequest)
        {
            var requestResponse = await _mediator.Send(getAllPetQueryRequest);

            return Ok(requestResponse);
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

        [HttpPost("GenerateFakeData")]
        public async Task<IActionResult> GenerateFakeData(CancellationToken cancellationToken)
        {
            await _fakeDataService.GeneratePetDataAsync(cancellationToken);

            var pets = await _context
                .Pets.AsNoTracking()
                .ToListAsync();

            _memoryCache.Set(PetsCacheKey, pets, _cacheEntryOptions);

            return Ok(await _fakeDataService.GeneratePetDataAsync(cancellationToken));
        }

>>>>>>> Stashed changes
    }
}