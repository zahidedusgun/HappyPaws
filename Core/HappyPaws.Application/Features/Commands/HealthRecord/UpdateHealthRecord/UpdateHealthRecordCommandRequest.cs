using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.HealthRecord.UpdateHealthRecord
{
    public class UpdateHealthRecordCommandRequest: IRequest<UpdateHealthRecordCommandResponse>
    {
        public string HealthRecordId { get; set; }
        public string Description { get; set; }
        public string VetNotes { get; set; }
    }
}
