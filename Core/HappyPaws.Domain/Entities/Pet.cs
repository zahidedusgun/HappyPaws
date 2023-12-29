using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Domain.Common;
using HappyPaws.Domain.Enums;

namespace HappyPaws.Domain.Entities
{
    public class Pet : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public short Age { get; set; }
        public Gender Gender { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        public Adopter Adopter { get; set; }
        public Guid AdopterId { get; set; }

        public ICollection<Adoption> Adoptions { get; set; }
        public ICollection<HealthRecord> HealthRecords { get;}
    }

}
