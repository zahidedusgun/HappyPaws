using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Domain.Dtos
{
    public class HealthRecordDto
    {
        public DateTime RecordDate { get; set; }
        public string Description { get; set; }
        public DateTime VetVisitDate { get; set; }
        public string VetNotes { get; set; }
        public Guid PetId { get; set; }
    }
}
