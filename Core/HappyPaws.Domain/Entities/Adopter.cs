using HappyPaws.Domain.Common;
using HappyPaws.Domain.Identity;
using System;
using System.Collections.Generic;
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
        public int PhoneNumber { get; set; }
        public Adoption Adoption { get; set; }
        public Guid AdoptionId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }

}
