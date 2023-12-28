using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Domain.Common;
using HappyPaws.Domain.Enums;

namespace HappyPaws.Domain.Entities
{
    public class Adoption : EntityBase<Guid>
    {
        public DateTime AdoptionDate { get; set; }
        public string AdoptionNotes { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; } //is adoption process done
        public Pet Pet { get; set; }
        public Guid PetId { get; set; }
        public Adopter Adopter { get; set; }
        public Guid AdopterId { get; set; }


    }

}
