using HappyPaws.Application.Features.Commands.Adoption.RemoveAdoption;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adoption.RemoveAdoption
{
    public class RemoveAdoptionCommandRequest : IRequest<RemoveAdoptionCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
