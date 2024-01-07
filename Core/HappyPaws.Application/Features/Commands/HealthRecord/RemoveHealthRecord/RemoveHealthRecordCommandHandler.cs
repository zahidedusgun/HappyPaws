using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Application.Features.Commands.Adopter.RemoveAdopter;
using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.Application.Features.Commands.HealthRecord.RemoveHealthRecord
{
    public class RemoveHealthRecordCommandHandler:IRequestHandler<RemoveHealthRecordCommandRequest, RemoveHealthRecordCommandResponse> 
    {
        private readonly ApplicationDbContext _context;

        public RemoveHealthRecordCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RemoveHealthRecordCommandResponse> Handle(RemoveHealthRecordCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.HealthRecord? removeHealthRecord = await _context.HealthRecords.FirstOrDefaultAsync(x => x.Id == request.HealthRecordId);
            _context.HealthRecords.Remove(removeHealthRecord);

            if (removeHealthRecord is not null)
            {
                await _context.SaveChangesAsync();
                return new RemoveHealthRecordCommandResponse
                {
                    IsSuccess = true
                };
            }
            else return new RemoveHealthRecordCommandResponse { IsSuccess = false };
        }
    }
}
