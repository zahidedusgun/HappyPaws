using HappyPaws.Application.Features.Commands.Adoption.CreateAdoption;
using HappyPaws.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adoption.CreateAdoption
{
    public class CreateAdoptionCommandRequest : IRequest<CreateAdoptionCommandResponse>
    {
        public string AdoptionNotes { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
    }
}
