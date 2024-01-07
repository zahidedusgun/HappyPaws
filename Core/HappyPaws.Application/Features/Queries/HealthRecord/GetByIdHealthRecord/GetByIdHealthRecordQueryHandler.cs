using HappyPaws.Application.Features.Queries.HealthRecord.GetAllHealthRecord;
using HappyPaws.Domain.Entities;
using HappyPaws.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.HealthRecord.GetByIdHealthRecord
{
    public class GetByIdHealthRecordQueryHandler : IRequestHandler<GetByIdHealthRecordQueryRequest, GetByIdHealthRecordQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetByIdHealthRecordQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GetByIdHealthRecordQueryResponse> Handle(GetByIdHealthRecordQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.HealthRecord? healthRecord = await _context.HealthRecords.FirstOrDefaultAsync(hr =>
                hr.Id.ToString() == request.Id);

            if (healthRecord is not null)
            {
                return new GetByIdHealthRecordQueryResponse
                {
                    RecordDate = healthRecord.RecordDate,
                    Description = healthRecord.Description,
                    VetVisitDate = healthRecord.VetVisitDate,
                    VetNotes = healthRecord.VetNotes,
                    PetId = healthRecord.PetId
                };
            }
            return new GetByIdHealthRecordQueryResponse();

        }
    }
}