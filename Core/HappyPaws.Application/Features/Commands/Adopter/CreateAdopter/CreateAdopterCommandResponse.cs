using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adopter.CreateAdopter
{
    public class CreateAdopterCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public Guid AdopterId { get; set; }
    }
}
