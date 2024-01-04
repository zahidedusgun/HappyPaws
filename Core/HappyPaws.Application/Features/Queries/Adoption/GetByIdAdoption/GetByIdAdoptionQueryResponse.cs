using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adoption.GetByIdAdoption
{
    public class GetByIdAdoptionQueryResponse
    {
        public DateTime AdoptionDate { get; set; }
        public string AdoptionNotes { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public HappyPaws.Domain.Entities.Pet Pet { get; set; }
        public Guid PetId { get; set; }
        public Adopter Adopter { get; set; }
        public Guid AdopterId { get; set; }
    }
}
