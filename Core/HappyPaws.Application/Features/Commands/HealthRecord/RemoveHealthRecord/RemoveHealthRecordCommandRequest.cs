using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HappyPaws.Application.Features.Commands.HealthRecord.RemoveHealthRecord
{
    public class RemoveHealthRecordCommandRequest: IRequest<RemoveHealthRecordCommandResponse>
    {
        public Guid HealthRecordId { get; set; }
    }
}
