using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPaws.Application.Features.Commands.HealthRecord.CreateHealthRecord
{
    public class CreateHealthRecordCommandResponse
    {
        public bool IsSuccess { get; set; }
        public Guid HealthRecordId { get; set; }

        public int StatusCode { get; set; }
    }
}
