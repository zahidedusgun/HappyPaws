using HappyPaws.Application.Features.Commands.Pet.RemovePet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Pet.RemovePet
{
    public class RemovePetCommandRequest : IRequest<RemovePetCommandResponse>
    {
        public Guid PetId { get; set; }
    }
}
