using HappyPaws.Application.Features.Commands.Pet.CreatePet;
using HappyPaws.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Pet.CreatePet
{
    public class CreatePetCommandRequest : IRequest<CreatePetCommandResponse>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public short Age { get; set; }
        public Gender Gender { get; set; }
        public Guid AdopterId { get; set; }

    }
}
