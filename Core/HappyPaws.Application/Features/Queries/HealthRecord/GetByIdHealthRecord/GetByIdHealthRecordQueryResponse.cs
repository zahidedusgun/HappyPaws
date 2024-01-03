using HappyPaws.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.HealthRecord.GetByIdHealthRecord
{
    public class GetByIdHealthRecordQueryResponse
    {
        public DateTime RecordDate { get; set; }
        public string Description { get; set; }
        public DateTime VetVisitDate { get; set; }
        public string VetNotes { get; set; }
        public HappyPaws.Domain.Entities.Pet Pet { get; set; }
        public Guid PetId { get; set; }
    }
}
