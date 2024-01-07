using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HappyPaws.Application.Features.Queries.HealthRecord.GetByIdHealthRecord
{
    public class GetByIdHealthRecordQueryRequest : IRequest<GetByIdHealthRecordQueryResponse>
    {
        public string Id { get; set; }
    }
}
