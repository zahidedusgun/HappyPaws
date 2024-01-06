using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Pet.GetByIdPet
{
    public class GetByIdPetQueryResponse
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public short Age { get; set; }
        public Gender Gender { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        public Domain.Entities.Adopter Adopter { get; set; }
        public Guid AdopterId { get; set; }

        public ICollection<HappyPaws.Domain.Entities.Adoption> Adoptions { get; set; }
    }
}
