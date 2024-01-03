using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HappyPaws.Application.Features.Commands.HealthRecord.CreateHealthRecord
{
    public class CreateHealthRecordCommandHandler:IRequestHandler<CreateHealthRecordCommandRequest, CreateHealthRecordCommandResponse>
    {
        public async Task<CreateHealthRecordCommandResponse> Handle(CreateHealthRecordCommandRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.HealthRecordList.Add(new()
            {
                RecordDate = DateTime.Now,
                Description = request.Description,
                VetVisitDate = request.VetVisitDate,
                VetNotes = request.VetNotes,


            });

            return new CreateHealthRecordCommandResponse
            {
                IsSuccess = true,
                HealthRecordId = id
            };
        }
    }
}
