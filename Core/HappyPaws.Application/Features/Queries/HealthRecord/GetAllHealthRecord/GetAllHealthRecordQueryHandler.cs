using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Persistence.Contexts;
using MediatR;

namespace HappyPaws.Application.Features.Queries.HealthRecord.GetAllHealthRecord
{
    public class GetAllHealthRecordQueryHandler:IRequestHandler<GetAllHealthRecordQueryRequest, List<GetAllHealthRecordQueryResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllHealthRecordQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetAllHealthRecordQueryResponse>> Handle(GetAllHealthRecordQueryRequest request, CancellationToken cancellationToken)
        {
            return _context.HealthRecords.Select(healthRecord => new GetAllHealthRecordQueryResponse
            {
                RecordDate = healthRecord.RecordDate,
                Description = healthRecord.Description,
                VetVisitDate = healthRecord.VetVisitDate,
                VetNotes = healthRecord.VetNotes,
                Pet = healthRecord.Pet,
                PetId = healthRecord.PetId

            }).ToList();
        }
    }
}
