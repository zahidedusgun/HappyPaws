using HappyPaws.Application.Features.Commands.HealthRecord.CreateHealthRecord;
using HappyPaws.Application.Features.Commands.HealthRecord.RemoveHealthRecord;
using HappyPaws.Application.Features.Commands.HealthRecord.UpdateHealthRecord;
using HappyPaws.Application.Features.Queries.HealthRecord.GetAllHealthRecord;
using HappyPaws.Application.Features.Queries.HealthRecord.GetByIdHealthRecord;
using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRecordsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public HealthRecordsController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllHealthRecordQueryRequest getAllHealthRecordQueryRequest)
        {
            var requestResponse = await _mediator.Send(getAllHealthRecordQueryRequest);

            return Ok(requestResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdHealthRecordQueryRequest getByIdHealthRecordQueryRequest)
        {
            return Ok(await _mediator.Send(getByIdHealthRecordQueryRequest));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateHealthRecordCommandRequest createHealthRecordCommandRequest)
        {
            var requestResponse = await _mediator.Send(createHealthRecordCommandRequest);

            await _context.SaveChangesAsync();

            return Ok(StatusCode(requestResponse.StatusCode));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateHealthRecordCommandRequest updateHealthRecordCommandRequest)
        {
            await _mediator.Send(updateHealthRecordCommandRequest);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveHealthRecordCommandRequest removeHealthRecordCommandRequest)
        {
            await _mediator.Send(removeHealthRecordCommandRequest);

            return Ok();
        }


    }

}

