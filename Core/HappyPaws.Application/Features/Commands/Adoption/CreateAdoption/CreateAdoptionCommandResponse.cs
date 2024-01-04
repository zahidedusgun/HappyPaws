using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adoption.CreateAdoption
{
    public class CreateAdoptionCommandResponse
    {
        public bool IsSuccess { get; set; }
        public Guid AdoptionId { get; set; }
        public int StatusCode { get; set; }
    }
}
