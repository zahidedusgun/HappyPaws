using HappyPaws.Application.Features.Queries.HealthRecord.GetAllHealthRecord;
using HappyPaws.Persistence.Contexts;
using MediatR;
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
            var healthRecord = _context.HealthRecords.FirstOrDefault(hr =>
                hr.Id == request.Id);
            return new GetByIdHealthRecordQueryResponse
            {
                RecordDate = healthRecord.RecordDate,
                Description = healthRecord.Description,
                VetVisitDate = healthRecord.VetVisitDate,
                VetNotes = healthRecord.VetNotes,
                Pet = healthRecord.Pet,
                PetId = healthRecord.PetId

            };
        }
    }
}
