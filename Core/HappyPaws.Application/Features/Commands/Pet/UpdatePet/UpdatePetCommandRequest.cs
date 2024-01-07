using HappyPaws.Application.Features.Commands.Pet.CreatePet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Pet.UpdatePet
{
    public class UpdatePetCommandRequest : IRequest<UpdatePetCommandResponse>
    {
        public string PetId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public short Age { get; set; }
    }
}
