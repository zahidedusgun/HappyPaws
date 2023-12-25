using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPaws.Domain.Enums;

namespace HappyPaws.Domain.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public Adoption Adoption { get; set; }
        public HealthRecord HealthRecord { get; set; }


        //public User User { get; set; }

    }

}
