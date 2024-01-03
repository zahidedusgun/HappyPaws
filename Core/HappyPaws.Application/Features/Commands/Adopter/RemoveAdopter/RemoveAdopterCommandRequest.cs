using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adopter.RemoveAdopter
{
    public class RemoveAdopterCommandRequest : IRequest<RemoveAdopterCommandResponse>
    {
        public Guid AdopterId { get; set; }
        
    }
}

