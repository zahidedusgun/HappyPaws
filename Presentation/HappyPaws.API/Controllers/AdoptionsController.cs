using HappyPaws.Application.Features.Commands.Adoption.CreateAdoption;
using HappyPaws.Application.Features.Commands.Adoption.RemoveAdoption;
using HappyPaws.Application.Features.Commands.Adoption.UpdateAdoption;
using HappyPaws.Application.Features.Queries.Adoption.GetAllAdoption;
using HappyPaws.Application.Features.Queries.Adoption.GetByIdAdoption;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdoptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAdoptionQueryRequest getAllAdoptionQueryRequest)
        {
            var requestResponse = await _mediator.Send(getAllAdoptionQueryRequest);

            return Ok(requestResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdAdoptionQueryRequest getByIdAdoptionQueryRequest)
        {
            var requestResponse = await _mediator.Send(getByIdAdoptionQueryRequest);

            return Ok(requestResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAdoptionCommandRequest createAdoptionCommandRequest)
        {
            var requestResponse = await _mediator.Send(createAdoptionCommandRequest);

            return Ok(requestResponse);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateAdoptionCommandRequest updateAdoptionCommandRequest)
        {
            await _mediator.Send(updateAdoptionCommandRequest);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] RemoveAdoptionCommandRequest removeAdoptionCommandRequest)
        {
            await _mediator.Send(removeAdoptionCommandRequest);

            return Ok();
        }
    }
}