using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Application.Features.Commands.HealthRecord.CreateHealthRecord;
using HappyPaws.Persistence.Contexts;
using MediatR;

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
            try
            {
                var healthRecord = await _context.HealthRecords.FindAsync(Guid.Parse(request.Id));

                if (healthRecord == null)
                {
                    return new UpdateHealthRecordCommandResponse { IsSuccess = false };
                }

                healthRecord.Description = request.Description;
                healthRecord.VetNotes = request.VetNotes;
                healthRecord.VetVisitDate = request.VetVisitDate;

                
                await _context.SaveChangesAsync();

                return new UpdateHealthRecordCommandResponse { IsSuccess = true };
            }
            catch (Exception)
            {
                return new UpdateHealthRecordCommandResponse { IsSuccess = false };
            }
        }
    }
}


