using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Domain.Enums;

namespace HappyPaws.Domain.Entities
{
    public class Adoption
    {
        public Guid Id { get; set; }
        public DateTime AdoptionDate { get; set; }
        public string AdoptionNotes { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public Pet Pet { get; set; }
        public Guid PetId { get; set; }
        public Adopter Adopter { get; set; }
        public Guid AdopterId { get; set; }


    }

}
