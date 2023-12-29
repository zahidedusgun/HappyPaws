using HappyPaws.Domain.Common;
using HappyPaws.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Domain.Entities
{
    public class Adopter : EntityBase<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<Pet> AdoptedPets { get; set; }
        public ICollection<Adoption> Adoptions { get; set; }

    }

}
