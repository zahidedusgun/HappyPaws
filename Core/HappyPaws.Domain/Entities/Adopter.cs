using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Domain.Entities
{
    public class Adopter
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public Adoption Adoption { get; set; }
        public Guid AdoptionId { get; set; }

        //public User User { get; set; }
    }

}
