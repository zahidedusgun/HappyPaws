using HappyPaws.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.Adoption.UpdateAdoption
{
    public class UpdateAdoptionCommandRequest : IRequest<UpdateAdoptionCommandResponse>
    {
        public string AdoptionId { get; set; }
        public string AdoptionNotes { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
    }
}
