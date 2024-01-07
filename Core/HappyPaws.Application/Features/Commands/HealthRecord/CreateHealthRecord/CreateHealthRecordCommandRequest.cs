using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HappyPaws.Application.Features.Commands.HealthRecord.CreateHealthRecord
{
    public class CreateHealthRecordCommandRequest :IRequest<CreateHealthRecordCommandResponse>
    {
        public string Description{ get; set; }
        public string VetNotes { get; set; }
        public DateTime VetVisitDate { get; set; }
        public Guid PetId{ get; set; }
    }
}