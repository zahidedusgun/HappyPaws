using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Pet.CreatePet
{
    public class CreatePetCommandResponse
    {
        public bool IsSuccess { get; set; }
        public Guid PetId { get; set; }
        public int StatusCode { get; set; }
    }
}
