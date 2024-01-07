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
using Microsoft.Extensions.Caching.Memory;
using HappyPaws.API.Services;
using System;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly FakeDataService _fakeDataService;
        private ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;
        private const string PetsCacheKey = "petsList";

        public PetsController(IMediator mediator, FakeDataService fakeDataService, ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _fakeDataService = fakeDataService;
            _context = context;
            _memoryCache = memoryCache;

            _cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                Priority = CacheItemPriority.High,
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(30),

            };

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdPetQueryRequest getByIdPetQueryRequest)
        {
            return Ok(await _mediator.Send(getByIdPetQueryRequest));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePetCommandRequest createPetCommandRequest)
        {
            var requestResponse = await _mediator.Send(createPetCommandRequest);

            return Ok(requestResponse);

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
        
    } 
}