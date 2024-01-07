using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HappyPaws.Application.Features.Commands.Adopter.CreateAdopter;
using HappyPaws.Application.Features.Commands.Adopter.RemoveAdopter;
using HappyPaws.Application.Features.Commands.Adopter.UpdateAdopter;
using HappyPaws.Application.Features.Queries.Adopter.GetAllAdopter;
using HappyPaws.Application.Features.Queries.Adopter.GetByIdAdopter;
using MediatR;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdopterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdopterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAdopterQueryRequest getAllAdopterQueryRequest)
        {
            var requestResponse = await _mediator.Send(getAllAdopterQueryRequest);

            return Ok(requestResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdAdopterQueryRequest getByIdAdopterQueryRequest)
        {
            return Ok(await _mediator.Send(getByIdAdopterQueryRequest));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAdopterCommandRequest createAdopterCommandRequest)
        {
            var requestResponse = await _mediator.Send(createAdopterCommandRequest);

            return Ok(StatusCode(requestResponse.StatusCode));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] UpdateAdopterCommandRequest updateAdopterCommandRequest)
        {
            await _mediator.Send(updateAdopterCommandRequest);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] RemoveAdopterCommandRequest removeAdopterCommandRequest)
        {
            await _mediator.Send(removeAdopterCommandRequest);

            return Ok();
        }

    }
}