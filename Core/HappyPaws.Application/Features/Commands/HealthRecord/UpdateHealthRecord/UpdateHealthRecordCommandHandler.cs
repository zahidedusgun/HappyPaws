using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Application.Features.Commands.Adoption.UpdateAdoption;
using HappyPaws.Application.Features.Commands.HealthRecord.CreateHealthRecord;
using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HappyPaws.Application.Features.Commands.HealthRecord.UpdateHealthRecord
{
    public class UpdateHealthRecordCommandHandler: IRequestHandler<UpdateHealthRecordCommandRequest, UpdateHealthRecordCommandResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpdateHealthRecordCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateHealthRecordCommandResponse> Handle(UpdateHealthRecordCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.HealthRecord? healthRecord = await _context.HealthRecords.FirstOrDefaultAsync(x => x.Id.ToString() == request.HealthRecordId);

            if (healthRecord is not null)
            {
                healthRecord.Description = request.Description;
                healthRecord.VetNotes = request.VetNotes;

                await _context.SaveChangesAsync();

                return new UpdateHealthRecordCommandResponse
                {
                    IsSuccess = true
                };
            }
            else return new UpdateHealthRecordCommandResponse { IsSuccess = false };
        }
    }
}


