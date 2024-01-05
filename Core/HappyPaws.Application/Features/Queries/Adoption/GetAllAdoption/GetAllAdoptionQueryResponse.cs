using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adoption.GetAllAdoption
{
    public class GetAllAdoptionQueryResponse
    {
        public DateTime AdoptionDate { get; set; }
        public string AdoptionNotes { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; } //is adoption process done
        public HappyPaws.Domain.Entities.Pet Pet { get; set; }
        public Guid PetId { get; set; }
        public Domain.Entities.Adopter Adopter { get; set; }
        public Guid AdopterId { get; set; }
    }
}
