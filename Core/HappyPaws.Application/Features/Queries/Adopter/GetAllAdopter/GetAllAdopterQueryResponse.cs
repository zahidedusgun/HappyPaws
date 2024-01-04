using HappyPaws.Domain.Entities;
using HappyPaws.Domain.Identity;
using HappyPaws.Domain.Common;
using HappyPaws.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Queries.Adopter.GetAllAdopter
{
    public class GetAllAdopterQueryResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
